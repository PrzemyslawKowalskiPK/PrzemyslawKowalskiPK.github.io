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
    <a href=""PrzemyslawKowalskiResume.pdf"" download style=""display: inline-block; padding: 12px 24px; background-color: #0066cc; color: white; text-decoration: none; border-radius: 5px; font-weight: bold; transition: background-color 0.3s; box-shadow: 0 2px 4px rgba(0,0,0,0.1);"" aria-label=""Download resume as PDF"">
        Download PDF
    </a>
</div>";

        return $@"<!DOCTYPE html>
<html lang=""en"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
    
    <!-- Primary Meta Tags -->
    <title>{title} - Przemyslaw Kowalski</title>
    <meta name=""title"" content=""{title} - Przemyslaw Kowalski"">
    <meta name=""description"" content=""Professional resume and portfolio of Przemyslaw Kowalski. View online or download as PDF."">
    <meta name=""keywords"" content=""resume, cv, portfolio, Przemyslaw Kowalski, professional"">
    <meta name=""author"" content=""Przemyslaw Kowalski"">
    <meta name=""robots"" content=""index, follow"">
    <meta name=""language"" content=""English"">
    <meta name=""revisit-after"" content=""7 days"">
    
    <!-- Open Graph / Facebook -->
    <meta property=""og:type"" content=""profile"">
    <meta property=""og:url"" content=""https://przemyslawkowalskipk.github.io/"">
    <meta property=""og:title"" content=""{title} - Przemyslaw Kowalski"">
    <meta property=""og:description"" content=""Professional resume and portfolio of Przemyslaw Kowalski. View online or download as PDF."">
    <meta property=""og:site_name"" content=""Przemyslaw Kowalski - Resume"">
    <meta property=""og:image"" content=""https://przemyslawkowalskipk.github.io/assets/icons/android-chrome-512x512.png"">
    <meta property=""og:image:width"" content=""512"">
    <meta property=""og:image:height"" content=""512"">
    <meta property=""og:image:type"" content=""image/png"">
    
    <!-- Twitter -->
    <meta property=""twitter:card"" content=""summary"">
    <meta property=""twitter:url"" content=""https://przemyslawkowalskipk.github.io/"">
    <meta property=""twitter:title"" content=""{title} - Przemyslaw Kowalski"">
    <meta property=""twitter:description"" content=""Professional resume and portfolio of Przemyslaw Kowalski. View online or download as PDF."">
    <meta property=""twitter:image"" content=""https://przemyslawkowalskipk.github.io/assets/icons/android-chrome-512x512.png"">
    
    <!-- Canonical URL -->
    <link rel=""canonical"" href=""https://przemyslawkowalskipk.github.io/PrzemyslawKowalskiResume.html"">
    
    <!-- Favicons -->
    <link rel=""icon"" type=""image/x-icon"" href=""/favicon.ico"">
    <link rel=""icon"" type=""image/png"" sizes=""16x16"" href=""/assets/icons/favicon-16x16.png"">
    <link rel=""icon"" type=""image/png"" sizes=""32x32"" href=""/assets/icons/favicon-32x32.png"">
    <link rel=""apple-touch-icon"" sizes=""180x180"" href=""/assets/icons/apple-touch-icon.png"">
    
    <!-- PWA Manifest -->
    <link rel=""manifest"" href=""/manifest.json"">
    <meta name=""theme-color"" content=""#ffaa33"">
    <meta name=""apple-mobile-web-app-capable"" content=""yes"">
    <meta name=""apple-mobile-web-app-status-bar-style"" content=""black-translucent"">
    <meta name=""apple-mobile-web-app-title"" content=""PK Resume"">
    <meta name=""mobile-web-app-capable"" content=""yes"">
    <meta name=""application-name"" content=""PK Resume"">
    
    <!-- Additional Resources -->
    <link rel=""alternate"" type=""application/pdf"" href=""/PrzemyslawKowalskiResume.pdf"">
    
    <!-- DNS Prefetch for performance -->
    <link rel=""dns-prefetch"" href=""//github.com"">
    
    <!-- Schema.org JSON-LD -->
    <script type=""application/ld+json"">
    {{
        ""@context"": ""https://schema.org"",
        ""@type"": ""Person"",
        ""name"": ""Przemyslaw Kowalski"",
        ""url"": ""https://przemyslawkowalskipk.github.io"",
        ""sameAs"": [
            ""https://github.com/PrzemyslawKowalskiPK""
        ],
        ""jobTitle"": ""Professional"",
        ""description"": ""Professional resume and portfolio""
    }}
    </script>
    
    <style>
{GetStyles()}
    </style>
</head>
<body>
    <a href=""#main-content"" class=""skip-link"">Skip to main content</a>
    {downloadLink}
    <main id=""main-content"" role=""main"">
        {htmlBody}
    </main>
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

        /* Skip link for accessibility */
        .skip-link {
            position: absolute;
            top: -40px;
            left: 0;
            background: #0066cc;
            color: white;
            padding: 8px;
            text-decoration: none;
            z-index: 100;
        }

        .skip-link:focus {
            top: 0;
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

        main {
            min-height: 50vh;
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
            color: #0066cc;
            text-decoration: underline;
            font-weight: 500;
        }

        a:hover {
            color: #004499;
            text-decoration: underline;
        }

        a:focus {
            outline: 3px solid #0066cc;
            outline-offset: 2px;
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
