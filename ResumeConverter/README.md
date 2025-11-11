# Resume Converter

A simple .NET 10 console application that converts Markdown resumes to HTML and PDF formats.

## Features

- ✅ Converts `RESUME.md` to styled `RESUME.html`
- ✅ Generates professional `RESUME.pdf` with proper formatting
- ✅ Uses industry-standard open-source packages
- ✅ Professional styling optimized for resumes
- ✅ Supports all Markdown features (tables, lists, code blocks, etc.)

## Technologies Used

### NuGet Packages

1. **Markdig** (v0.38.0)

   - MIT License
   - Actively maintained
   - Fast and extensible Markdown processor
   - Commercial use allowed
   - GitHub: https://github.com/xoofx/markdig

2. **PuppeteerSharp** (v20.0.0)
   - MIT License
   - Actively maintained
   - Headless Chrome/Chromium automation
   - Commercial use allowed
   - GitHub: https://github.com/hardkoded/puppeteer-sharp

## Requirements

- .NET 10 SDK
- Internet connection (first run only, to download Chromium)

## Usage

1. **Prepare your resume:**

   - Create or edit `RESUME.md` in the root directory

2. **Build the project:**

   ```powershell
   cd ResumeConverter
   dotnet build
   ```

3. **Run the converter:**

   ```powershell
   dotnet run
   ```

4. **Output files will be created in the root directory:**
   - `RESUME.html` - Styled HTML version
   - `RESUME.pdf` - PDF version ready to print or share

## How It Works

1. Reads `RESUME.md` from the workspace root
2. Parses Markdown using Markdig with advanced extensions
3. Wraps content in a professional HTML template with CSS styling
4. Saves the HTML file
5. Uses PuppeteerSharp to render HTML and generate PDF with Chromium

## Customization

### Styling

Edit the CSS in the `CreateStyledHtmlDocument` method in `Program.cs` to customize:

- Colors
- Fonts
- Spacing
- Layout

### PDF Options

Modify PDF settings in `Program.cs`:

- Paper size (A4, Letter, etc.)
- Margins
- Print background
- Orientation

## License

This project uses packages with MIT licenses, which allow commercial use.

## Notes

- First run downloads Chromium (~150 MB) automatically
- Subsequent runs use the cached browser
- Generated files are placed in the workspace root directory
