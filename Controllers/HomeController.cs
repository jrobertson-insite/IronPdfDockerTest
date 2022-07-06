using System;
using System.IO;
using System.Web.Mvc;

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

            var renderer = new IronPdf.ChromePdfRenderer();
            using var pdf = renderer.RenderHtmlAsPdf("<h1>Hello World</h1>");
            var path = Path.GetTempFileName().Replace(".tmp", ".pdf");
            Console.WriteLine(path);
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
