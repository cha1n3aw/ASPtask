using ASPtask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace ASPtask.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult AdminPasswordCheck(string pass)
        {
            if (pass != null)
            using (System.Security.Cryptography.SHA512 shaM = new System.Security.Cryptography.SHA512Managed())
            {
                string hashedpass = string.Empty;
                var hash = shaM.ComputeHash(System.Text.Encoding.UTF8.GetBytes(pass));
                var hashToString = new System.Text.StringBuilder(128);
                foreach (var @byte in hash) hashToString.Append(@byte.ToString("X2"));
                hashedpass = hashToString.ToString();
                if (hashedpass != null && hashedpass == "B48327F35BCB9A8D1352819E8686B8ADBFB3F9A91A23F1463CDDFEB416EF3321E9E4D896522BF2E0237E11D6261622B1DDC2C9F98BFD906110BD11BFADA8A299")
                    return RedirectToAction("AdminPanel", "Home");
                else return View();
            }
            else return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult AdminPanel()
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
