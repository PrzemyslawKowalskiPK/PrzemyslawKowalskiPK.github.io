namespace ResumeConverter;

/// <summary>
/// Provides HTML template and styling for the generated resume
/// </summary>
public static class HtmlTemplate
{
    /// <summary>
    /// Creates a complete HTML document with professional styling
    /// </summary>
    /// <param name="htmlBody">The converted HTML content from Markdown</param>
    /// <param name="title">The page title for SEO</param>
    /// <returns>Complete HTML document as string</returns>
    public static string CreateDocument(string htmlBody, string title = "Resume")
    {
        var downloadLink = @"<div class=""download-button"" style=""text-align: center; margin: 20px 0; padding: 15px; background-color: #f8f9fa; border-radius: 5px;"">
    <a href=""PrzemyslawKowalskiResume.pdf"" download style=""display: inline-block; padding: 12px 24px; background-color: #3498db; color: white; text-decoration: none; border-radius: 5px; font-weight: bold; transition: background-color 0.3s;"">
        Download PDF
    </a>
</div>";

        return $@"<!DOCTYPE html>
<html lang=""en"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>{title}</title>
    <style>
{GetStyles()}
    </style>
</head>
<body>
{downloadLink}
{htmlBody}
{downloadLink}
</body>
</html>";
    }

    /// <summary>
    /// Gets the CSS styles for the HTML document
    /// </summary>
    private static string GetStyles()
    {
        return @"        * {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
        }

        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            line-height: 1.6;
            color: #333;
            max-width: 900px;
            margin: 0 auto;
            padding: 40px 20px;
            background-color: #ffffff;
        }

        h1 {
            font-size: 2.5em;
            margin-bottom: 0.5em;
            color: #2c3e50;
            border-bottom: 3px solid #3498db;
            padding-bottom: 10px;
        }

        h2 {
            font-size: 1.8em;
            margin-top: 1.5em;
            margin-bottom: 0.5em;
            color: #34495e;
            border-bottom: 2px solid #95a5a6;
            padding-bottom: 5px;
        }

        h3 {
            font-size: 1.3em;
            margin-top: 1em;
            margin-bottom: 0.5em;
            color: #2c3e50;
        }

        h4, h5, h6 {
            margin-top: 1em;
            margin-bottom: 0.5em;
            color: #34495e;
        }

        p {
            margin-bottom: 1em;
        }

        ul, ol {
            margin-left: 2em;
            margin-bottom: 1em;
        }

        li {
            margin-bottom: 0.5em;
        }

        a {
            color: #3498db;
            text-decoration: underline;
        }

        a:hover {
            opacity: 0.8;
        }

        code {
            background-color: #f4f4f4;
            padding: 2px 6px;
            border-radius: 3px;
            font-family: 'Courier New', Courier, monospace;
            font-size: 0.9em;
        }

        pre {
            background-color: #f4f4f4;
            padding: 15px;
            border-radius: 5px;
            overflow-x: auto;
            margin-bottom: 1em;
        }

        pre code {
            background-color: transparent;
            padding: 0;
        }

        blockquote {
            border-left: 4px solid #3498db;
            padding-left: 20px;
            margin: 1em 0;
            color: #555;
            font-style: italic;
        }

        table {
            border-collapse: collapse;
            width: 100%;
            margin-bottom: 1em;
        }

        th, td {
            border: 1px solid #ddd;
            padding: 10px;
            text-align: left;
        }

        th {
            background-color: #3498db;
            color: white;
            font-weight: bold;
        }

        tr:nth-child(even) {
            background-color: #f9f9f9;
        }

        hr {
            border: none;
            border-top: 1px solid #ddd;
            margin: 2em 0;
        }

        @media print {
            body {
                padding: 20px;
            }
            
            .download-button {
                display: none !important;
            }
        }";
    }
}
