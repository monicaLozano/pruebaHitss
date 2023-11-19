using DataObjects;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiPruebaHits.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private string _conn { get; set; }
        private BusinessLogic.BusinessLogic bl { get; set; }

        public ClientController()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
            _conn = configuration.GetConnectionString("dbConnecion");
            bl = new BusinessLogic.BusinessLogic(_conn);
        }
        [HttpGet]
        public IEnumerable<Client> Get()
        {
            return bl.GetClients();
        }

        [HttpGet("{id}")]
        public Client Get(int id)
        {
            return bl.GetClient(id);
        }

        [HttpPost]
        public void Post([FromBody] Client c)
        {
            bl.insClients(c);
        }

        [HttpPut]
        public void Put([FromBody] Client p)
        {
            bl.updClients(p);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            bl.DelClients(id);
        }
    }
}
