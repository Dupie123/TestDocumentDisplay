using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestDocumentDisplay.Models;

namespace TestDocumentDisplay.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment hostingEnvironment)
        {
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Document()
        {
            DocumentModel model = new DocumentModel();
            string RelPath = "\\content\\Test.docx";
            string FullPath = _hostingEnvironment.WebRootPath + RelPath;
            if (System.IO.File.Exists(FullPath))
            {
                MemoryStream memoryStream = new MemoryStream();
                using (FileStream stream = System.IO.File.OpenRead(FullPath))
                {
                    stream.CopyTo(memoryStream);
                }
                model.DocumentBytes = memoryStream.ToArray();
                model.DocumentName = "Test.docx";
                model.SetFormat();
            }

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}