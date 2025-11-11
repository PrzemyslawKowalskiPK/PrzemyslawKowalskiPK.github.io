namespace ResumeConverter;

/// <summary>
/// Manages file path resolution for the application
/// </summary>
public class PathResolver
{
    private readonly string _workspaceRoot;

    public PathResolver()
    {
        _workspaceRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", ".."));
    }

    /// <summary>
    /// Gets the full path for the input Markdown file
    /// </summary>
    public string InputPath => Path.Combine(_workspaceRoot, AppConstants.FileNames.InputMarkdown);

    /// <summary>
    /// Gets the full path for the output HTML file
    /// </summary>
    public string HtmlOutputPath => Path.Combine(_workspaceRoot, AppConstants.FileNames.OutputHtml);

    /// <summary>
    /// Gets the full path for the output PDF file
    /// </summary>
    public string PdfOutputPath => Path.Combine(_workspaceRoot, AppConstants.FileNames.OutputPdf);

    /// <summary>
    /// Gets the workspace root directory
    /// </summary>
    public string WorkspaceRoot => _workspaceRoot;
}
