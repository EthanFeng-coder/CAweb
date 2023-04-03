using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.IO;

namespace CA.Pages
{	

    public class IssuesModel : PageModel
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public IssuesModel(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public List<PdfFile> PdfFiles { get; set; }

        public void OnGet()
        {
            var rootPath = _webHostEnvironment.ContentRootPath;
            var pdfs = new List<PdfFile>
            {
                new PdfFile { Name = "Economic Report Q1", Category = "Economic", FilePath = Path.Combine(rootPath, "pdfs/CapitalAnalyst-Issue1.pdf") },
                new PdfFile { Name = "Economic Report Q2", Category = "Economic", FilePath = Path.Combine(rootPath, "pdfs/CapitalAnalyst-Issue2.pdf") },
                new PdfFile { Name = "Political Analysis 2021", Category = "Political", FilePath = Path.Combine(rootPath, "pdfs/CapitalAnalyst-Issue3.pdf") },
                new PdfFile { Name = "Political Analysis 2022", Category = "Political", FilePath = Path.Combine(rootPath, "pdfs/CapitalAnalyst-Issue4.pdf") },
                new PdfFile { Name = "Industry Trends", Category = "Other", FilePath = Path.Combine(rootPath, "pdfs/CapitalAnalyst-Issue5.pdf") }
            };

            PdfFiles = pdfs;
        }
        public class PdfFile
{
    public string Name { get; set; }
    public string Category { get; set; }
    public string FilePath { get; set; }
    public string WebPath => $"/pdfs/{Path.GetFileName(FilePath)}";
}
    }
}

