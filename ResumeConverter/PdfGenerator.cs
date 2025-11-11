using PuppeteerSharp;

namespace ResumeConverter;

/// <summary>
/// Handles PDF generation from HTML content using PuppeteerSharp
/// </summary>
public class PdfGenerator
{
    /// <summary>
    /// Generates a PDF file from HTML content
    /// </summary>
    /// <param name="htmlContent">The complete HTML document content</param>
    /// <param name="outputPath">The path where the PDF should be saved</param>
    public async Task GenerateAsync(string htmlContent, string outputPath)
    {
        // Download Chromium browser if not already present
        var browserFetcher = new BrowserFetcher();
        await browserFetcher.DownloadAsync();

        // Launch browser
        await using var browser = await Puppeteer.LaunchAsync(new LaunchOptions
        {
            Headless = true
        });

        // Create page and set content
        await using var page = await browser.NewPageAsync();
        await page.SetContentAsync(htmlContent);

        // Generate PDF with specified options
        await page.PdfAsync(outputPath, CreatePdfOptions());
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
