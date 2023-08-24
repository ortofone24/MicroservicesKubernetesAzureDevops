using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shopping.Client.Models;
using System.Diagnostics;

namespace Shopping.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient httpClient;
        private readonly HttpClient httpClient2;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClient)
        {
            _logger = logger;
            this.httpClient = httpClient.CreateClient("test");
            this.httpClient2 = httpClient.CreateClient("diupa");
        }

        public async Task<IActionResult> Index()
        {
            var response = await httpClient2.GetAsync("/Product/GetData");
            var content = await response.Content.ReadAsStringAsync();
            var productList = JsonConvert.DeserializeObject<List<Product>>(content);
            return View(productList);
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