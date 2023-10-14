using Microsoft.AspNetCore.Mvc;
using ProductManagementWebClient.Models;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace ProductManagementWebClient.Controllers
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
            //HttpClient client = new HttpClient();
            //var data = await client.GetAsync("https://localhost:7001/api/Product/GetAllProducts");

            //var res = await data.Content.ReadAsStreamAsync();

            ////var dataJson = JsonConvert

            //return View(data);
            return View();
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