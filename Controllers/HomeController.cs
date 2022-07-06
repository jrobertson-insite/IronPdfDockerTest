using System;
using System.IO;
using System.Web.Mvc;
using IronPdf;
using IronPdf.Rendering;

namespace IronPdfDockerTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IronPdf.Logging.Logger.EnableDebugging = true;
            IronPdf.Logging.Logger.LogFilePath = @"C:\temp\Default.log";
            IronPdf.Logging.Logger.LoggingMode = IronPdf.Logging.Logger.LoggingModes.All;
            IronPdf.Installation.TempFolderPath = @"C:\temp";
            IronPdf.Installation.CustomDeploymentDirectory = @"C:\inetpub\wwwroot\bin";

            var renderer = new IronPdf.HtmlToPdf(new PdfPrintOptions
            {
                RenderingEngine = PdfRenderingEngine.WebKit 
            });
            using var pdf = renderer.RenderHtmlAsPdf("<h1>Hello World</h1>");
            const string path = @"C:\inetpub\wwwroot\test.pdf";;
            pdf.SaveAs(path);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}
