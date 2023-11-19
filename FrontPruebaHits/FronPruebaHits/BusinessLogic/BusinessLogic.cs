using DataLayer;
using DataObjects;

namespace BusinessLogic
{
    public class BusinessLogic
    {
        private string _urlAPI { get; set; }
        private ProductDL pd { get; set; }
        private Client_DL cd { get; set; }
        public BusinessLogic(string urlAPI)
        {
            _urlAPI = urlAPI;
            pd = new ProductDL(_urlAPI);
            cd = new Client_DL(_urlAPI);
        }
        public async Task<Product> GetProduct(int idProduct)
        {
            return await pd.GetProduct(idProduct);
        }
        public async Task<List<Product>> GetProducts()
        {
            return await pd.GetProducts();
        }
        public void DelProducts(int idProduct)
        {
            pd.DelProducts(idProduct);
        }
        public void updProducts(Product c)
        {
            pd.updProducts(c);
        }
        public async void insProduct(Product c)
        {
            pd.insProducts(c);
        }
        public async Task<Client> GetClient(int idClient)
        {
            return await cd.GetClient(idClient);
        }

        public async Task<List<Client>> GetClients()
        {
            return await cd.GetClients();
        }

        public void DelClients(int idClient)
        {
            cd.DelClients(idClient);
        }

        public void updClients(Client c)
        {
            cd.updClients(c);
        }
        public void insClients(Client c)
        {
            cd.insClients(c);
        }
    }
}