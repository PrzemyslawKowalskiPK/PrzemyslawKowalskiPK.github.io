namespace ResumeConverter;

/// <summary>
/// Orchestrates the resume conversion process
/// </summary>
public class ResumeConverterService
{
    private readonly PathResolver _pathResolver;
    private readonly MarkdownConverter _markdownConverter;
    private readonly PdfGenerator _pdfGenerator;

    public ResumeConverterService()
    {
        _pathResolver = new PathResolver();
        _markdownConverter = new MarkdownConverter();
        _pdfGenerator = new PdfGenerator();
    }

    /// <summary>
    /// Executes the complete conversion process
    /// </summary>
    public async Task ConvertAsync()
    {
        PrintHeader();

        // Validate input file exists
        if (!File.Exists(_pathResolver.InputPath))
        {
            PrintError(_pathResolver.InputPath);
            return;
        }

        try
        {
            // Read Markdown file
            Console.WriteLine(AppConstants.Messages.ReadingFile, _pathResolver.InputPath);
            var markdownContent = await File.ReadAllTextAsync(_pathResolver.InputPath);

            // Extract title from markdown for SEO
            var title = ExtractTitle(markdownContent);

            // Convert to HTML
            Console.WriteLine(AppConstants.Messages.ConvertingToHtml);
            var htmlBody = _markdownConverter.ConvertToHtml(markdownContent);
            var htmlDocument = HtmlTemplate.CreateDocument(htmlBody, title);

            // Save HTML file
            Console.WriteLine(AppConstants.Messages.SavingHtml, _pathResolver.HtmlOutputPath);
            await File.WriteAllTextAsync(_pathResolver.HtmlOutputPath, htmlDocument);
            Console.WriteLine(AppConstants.Messages.HtmlSuccess);

            // Generate PDF
            Console.WriteLine(AppConstants.Messages.GeneratingPdf);
            Console.WriteLine(AppConstants.Messages.DownloadingChromium);

            Console.WriteLine(AppConstants.Messages.SavingPdf, _pathResolver.PdfOutputPath);
            await _pdfGenerator.GenerateAsync(htmlDocument, _pathResolver.PdfOutputPath);

            Console.WriteLine(AppConstants.Messages.PdfSuccess);
            PrintSuccess();
        }
        catch (Exception ex)
        {
            Console.WriteLine(AppConstants.Messages.ErrorPrefix, ex.Message);
            Console.WriteLine(AppConstants.Messages.ErrorDetails, ex);
        }
    }

    private static void PrintHeader()
    {
        Console.WriteLine(AppConstants.Messages.AppTitle);
        Console.WriteLine(AppConstants.Messages.Separator);
        Console.WriteLine();
    }

    private void PrintSuccess()
    {
        Console.WriteLine(AppConstants.Messages.CompletionTitle);
        Console.WriteLine(AppConstants.Messages.HtmlOutput, _pathResolver.HtmlOutputPath);
        Console.WriteLine(AppConstants.Messages.PdfOutput, _pathResolver.PdfOutputPath);
    }

    private static void PrintError(string inputPath)
    {
        Console.WriteLine(AppConstants.Messages.FileNotFound, inputPath);
        Console.WriteLine(AppConstants.Messages.CreateFilePrompt);
    }

    /// <summary>
    /// Extracts the title from markdown content for SEO purposes
    /// Looks for the first H1 heading and optional subtitle
    /// </summary>
    private static string ExtractTitle(string markdownContent)
    {
        var lines = markdownContent.Split('\n');
        string? name = null;
        string? subtitle = null;

        foreach (var line in lines)
        {
            var trimmedLine = line.Trim();

            // First H1 heading (# Title)
            if (trimmedLine.StartsWith("# ") && name == null)
            {
                name = trimmedLine.Substring(2).Trim();
            }
            // Bold text on next lines (typically the subtitle/role)
            else if (name != null && trimmedLine.StartsWith("**") && trimmedLine.EndsWith("**"))
            {
                subtitle = trimmedLine.Trim('*').Trim();
                break;
            }
            // Stop at first horizontal rule or empty content section
            else if (!string.IsNullOrWhiteSpace(trimmedLine) && trimmedLine.StartsWith("---"))
            {
                break;
            }
        }

        // Construct the title
        if (name != null && subtitle != null)
        {
            return $"{name} - {subtitle}";
        }
        else if (name != null)
        {
            return name;
        }

        return "Resume";
    }
}
