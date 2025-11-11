namespace ResumeConverter;

/// <summary>
/// Configuration constants for the Resume Converter application
/// </summary>
public static class AppConstants
{
    /// <summary>
    /// Input/Output file names
    /// </summary>
    public static class FileNames
    {
        public const string InputMarkdown = "RESUME.md";
        public const string OutputHtml = "RESUME.html";
        public const string OutputPdf = "PrzemyslawKowalskiResume.pdf";
    }

    /// <summary>
    /// PDF generation settings
    /// </summary>
    public static class PdfSettings
    {
        public const string MarginTop = "20mm";
        public const string MarginRight = "20mm";
        public const string MarginBottom = "20mm";
        public const string MarginLeft = "20mm";
    }

    /// <summary>
    /// Application messages
    /// </summary>
    public static class Messages
    {
        public const string AppTitle = "Resume Converter - Markdown to HTML & PDF";
        public const string Separator = "==========================================";
        public const string ReadingFile = "Reading: {0}";
        public const string ConvertingToHtml = "Converting Markdown to HTML...";
        public const string SavingHtml = "Saving HTML: {0}";
        public const string HtmlSuccess = "✓ HTML file created successfully!";
        public const string GeneratingPdf = "\nGenerating PDF...";
        public const string DownloadingChromium = "Downloading Chromium browser (first run only)...";
        public const string SavingPdf = "Saving PDF: {0}";
        public const string PdfSuccess = "✓ PDF file created successfully!";
        public const string CompletionTitle = "\n==========================================\nConversion completed!";
        public const string HtmlOutput = "HTML: {0}";
        public const string PdfOutput = "PDF:  {0}";
        public const string FileNotFound = "Error: RESUME.md not found at: {0}";
        public const string CreateFilePrompt = "Please create a RESUME.md file in the root directory.";
        public const string ErrorPrefix = "\nError: {0}";
        public const string ErrorDetails = "Details: {0}";
    }
}
