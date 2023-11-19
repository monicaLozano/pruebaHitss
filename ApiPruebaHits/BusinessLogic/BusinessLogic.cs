using DataLayer;
using DataObjects;

namespace BusinessLogic
{
    public class BusinessLogic
    {
        private string _conn { get; set; }
        private Product_DL pd { get; set; }
        private Client_DL cd { get; set; }
        public BusinessLogic(string conn)
        {
            _conn = conn;
            pd = new Product_DL(_conn);
            cd = new Client_DL(_conn);
        }
        public Product GetProduct(int idProduct)
        {
            return pd.GetProduct(idProduct);
        }
        public List<Product> GetProducts()
        {
            return pd.GetProducts();
        }
        public void DelProducts(int idProduct)
        {
            pd.DelProducts(idProduct);
        }
        public void updProducts(Product c)
        {
            pd.updProducts(c);
        }
        public void insProduct(Product c)
        {
            pd.insProduct(c);
        }
        public Client GetClient(int idClient)
        {
            return cd.GetClient(idClient);
        }

        public List<Client> GetClients()
        {
            return cd.GetClients();
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