using DataObjects;
using FronPruebaHits.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FronPruebaHits.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BusinessLogic.BusinessLogic bl { get; set; }
        private string _urlAPI { get; set; }
        public HomeController(ILogger<HomeController> logger)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
            _logger = logger;

            _urlAPI = configuration["UrlAPI"].ToString();


            bl = new BusinessLogic.BusinessLogic(_urlAPI);
        }

        public async Task<IActionResult> Index()
        {
            List<Product> products = new List<Product>();
            products = await bl.GetProducts();
            return View(products);
        }

        public async Task<IActionResult> Privacy()
        {
            List<Client> clients = new List<Client>();
            clients = await bl.GetClients();
            return View(clients);
        }


        [HttpPost]
        public IActionResult AddOrUpdateClient(Client client)
        {
            bool success = false;
            string message = "";
            if (client.idClient == 0)
            {
                bl.insClients(client);
                success = true;
                message = "Cliente creado con éxito.";

                return RedirectToAction("Privacy");
            }
            else
            {
                bl.updClients(client);
                success = true;
                message = "Cliente actualizado con éxito.";

                return Json(new { success = success, message = message });
            }

        }

        public IActionResult DeleteClient(int id)
        {
            bool success = false;
            string message = "";
            bl.DelClients(id);


            success = true;
            message = "Cliente eliminado con éxito.";

            return Json(new { success = success, message = message });
        }

        [HttpPost]
        public IActionResult AddOrUpdateProduct(Product product)
        {
            bool success = false;
            string message = "";
            if (product.idProduct == 0)
            {
                bl.insProduct(product);
                success = true;
                message = "Cliente creado con éxito.";

                return RedirectToAction("Index");
            }
            else
            {
                bl.updProducts(product);
                success = true;
                message = "Producto actualizado con éxito.";

                return Json(new { success = success, message = message });
            }

        }

        public IActionResult DeleteProduct(int id)
        {
            bool success = false;
            string message = "";
            bl.DelProducts(id);


            success = true;
            message = "Producto eliminado con éxito.";

            return Json(new { success = success, message = message });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}