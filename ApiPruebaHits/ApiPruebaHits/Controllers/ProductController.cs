using BusinessLogic;
using DataObjects;
using Microsoft.AspNetCore.Mvc;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiPruebaHits.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private string _conn { get; set; }
        private BusinessLogic.BusinessLogic bl { get; set; }

        public ProductController() 
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
            _conn = configuration.GetConnectionString("dbConnecion");
            bl = new BusinessLogic.BusinessLogic(_conn);
        }
        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return bl.GetProducts();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return bl.GetProduct(id);
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] Product p)
        {
            bl.insProduct(p);
        }

        // PUT api/<ProductController>/5
        [HttpPut]
        public void Put([FromBody]  Product p)
        {
            bl.updProducts(p);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            bl.DelProducts(id);
        }
    }
}
