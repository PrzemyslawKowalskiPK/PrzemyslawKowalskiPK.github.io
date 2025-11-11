using Markdig;

namespace ResumeConverter;

/// <summary>
/// Handles conversion of Markdown content to HTML
/// </summary>
public class MarkdownConverter
{
    private readonly MarkdownPipeline _pipeline;

    public MarkdownConverter()
    {
        _pipeline = new MarkdownPipelineBuilder()
            .UseAdvancedExtensions()
            .Build();
    }

    /// <summary>
    /// Converts Markdown content to HTML
    /// </summary>
    /// <param name="markdownContent">The Markdown content to convert</param>
    /// <returns>HTML content</returns>
    public string ConvertToHtml(string markdownContent)
    {
        return Markdown.ToHtml(markdownContent, _pipeline);
    }
}
