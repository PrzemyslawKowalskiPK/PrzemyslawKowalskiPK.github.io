using PuppeteerSharp;

namespace ResumeConverter;

/// <summary>
/// Handles PDF generation from HTML content using PuppeteerSharp
/// </summary>
public class PdfGenerator
{
    /// <summary>
    /// Generates a PDF file from HTML file
    /// </summary>
    /// <param name="htmlFilePath">The path to the input HTML file</param>
    /// <param name="outputPath">The path where the PDF should be saved</param>
    public async Task GenerateAsync(string htmlFilePath, string outputPath)
    {
        // Download Chromium browser if not already present
        var browserFetcher = new BrowserFetcher();
        await browserFetcher.DownloadAsync();

        // Launch browser with appropriate options
        await using var browser = await Puppeteer.LaunchAsync(CreateLaunchOptions());

        // Create page and go to file
        await using var page = await browser.NewPageAsync();

        var fileUri = new Uri(htmlFilePath).AbsoluteUri;
        await page.GoToAsync(fileUri, new NavigationOptions { WaitUntil = new[] { WaitUntilNavigation.Networkidle0 } });

        // Generate PDF with specified options
        await page.PdfAsync(outputPath, CreatePdfOptions());
    }

    /// <summary>
    /// Creates browser launch options, detecting CI/CD environment
    /// </summary>
    private static LaunchOptions CreateLaunchOptions()
    {
        var options = new LaunchOptions
        {
            Headless = true
        };

        // Detect CI/CD environment (GitHub Actions, GitLab CI, etc.)
        var isCI = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("CI")) ||
                   !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("GITHUB_ACTIONS")) ||
                   !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("GITLAB_CI"));

        if (isCI)
        {
            // CI/CD environments require --no-sandbox flag
            options.Args = new[] { "--no-sandbox", "--disable-setuid-sandbox" };
        }

        return options;
    }

    /// <summary>
    /// Creates PDF generation options
    /// </summary>
    private static PdfOptions CreatePdfOptions()
    {
        return new PdfOptions
        {
            Format = PuppeteerSharp.Media.PaperFormat.A4,
            PrintBackground = true,
            MarginOptions = new PuppeteerSharp.Media.MarginOptions
            {
                Top = AppConstants.PdfSettings.MarginTop,
                Right = AppConstants.PdfSettings.MarginRight,
                Bottom = AppConstants.PdfSettings.MarginBottom,
                Left = AppConstants.PdfSettings.MarginLeft
            }
        };
    }
}
