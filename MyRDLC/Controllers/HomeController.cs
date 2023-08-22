using Microsoft.AspNetCore.Mvc;
using Microsoft.Reporting.NETCore;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using MyRDLC.Models;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace MyRDLC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly List<ClassLibrary2.ReportItem> _items;
        public HomeController(ILogger<HomeController> logger)
        {
            //Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            _logger = logger;
            _items = new List<ClassLibrary2.ReportItem> {
                new ClassLibrary2.ReportItem { Description = "Widget 6000", Price = 108, Qty = 1 },
                new ClassLibrary2.ReportItem { Description = "Gizmo MAX", Price = 108, Qty = 25 }
            };
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Export()
        {
            var report = new LocalReport();
            var parameters = new[] { new ReportParameter("Title", "Hello ReportViewCore") };

            var assembly = typeof(MyReports.Const).Assembly;
            using var rs = assembly.GetManifestResourceStream("MyReports.RDLCs.Report1.rdlc");
            report.LoadReportDefinition(rs);
            report.DataSources.Add(new ReportDataSource("ReportItem", _items));
            report.SetParameters(parameters);
            var result = report.Render("EXCEL");
            return File(result, "application/msexcel", "Export.xls");
        }

        public IActionResult Print()
        {
            var report = new LocalReport();
            var parameters = new[] { new ReportParameter("Title", "Hello ReportViewCore") };

            var assembly = typeof(MyReports.Const).Assembly;
            using var rs = assembly.GetManifestResourceStream("MyReports.RDLCs.Report1.rdlc");
            report.LoadReportDefinition(rs);
            report.DataSources.Add(new ReportDataSource("ReportItem", _items));
            report.SetParameters(parameters);
            var result = report.Render("PDF");
            return File(result, "application/pdf");
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