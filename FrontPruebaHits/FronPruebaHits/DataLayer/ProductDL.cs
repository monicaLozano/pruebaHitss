using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ProductDL
    {
        private string _urlAPI { get; set; }
        public ProductDL(string urlAPI)
        {
            _urlAPI = urlAPI;
        }

        public async Task<Product> GetProduct(int idProduct)
        {
            Product Product = new Product();
            try
            {
                HttpClient HttpClient = new HttpClient();

                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12 | System.Net.SecurityProtocolType.Tls11;

                var response = await HttpClient.GetAsync(_urlAPI + "Product/" + idProduct);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Product = JsonSerializer.Deserialize<Product>(content);
                }
                else
                {
                    Console.WriteLine($"Error en la solicitud: {response.Content}");
                }

                return Product;
            }
            catch (Exception e)
            {
                throw new Exception("Could not do the transaction in SQL, check the connection string, that the integrity of the queried databases ****** System error : " + e.ToString());
            }
            return Product;
        }

        public async Task<List<Product>> GetProducts()
        {
            List<Product> Products = new List<Product>();
            try
            {
                HttpClient HttpClient = new HttpClient();

                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12 | System.Net.SecurityProtocolType.Tls11;

                var response = await HttpClient.GetAsync(_urlAPI + "Product");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Products = JsonSerializer.Deserialize<List<Product>>(content);
                }
                else
                {
                    Console.WriteLine($"Error en la solicitud: {response.Content}");
                }

                return Products;
            }
            catch (Exception e)
            {
                throw new Exception("Could not do the transaction in SQL, check the connection string, that the integrity of the queried databases ****** System error : " + e.ToString());
            }
            return Products;
        }
        public void DelProducts(int idProduct)
        {
            try
            {
                HttpClient HttpClient = new HttpClient();

                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12 | System.Net.SecurityProtocolType.Tls11;

                HttpClient.DeleteAsync(_urlAPI + "Product/" + idProduct);

            }
            catch (Exception e)
            {
                throw new Exception("Could not do the transaction in SQL, check the connection string, that the integrity of the queried databases ****** System error : " + e.ToString());
            }
        }
        public void updProducts(Product c)
        {
            try
            {
                HttpClient HttpClient = new HttpClient();

                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12 | System.Net.SecurityProtocolType.Tls11;
                var jsonRequest = JsonSerializer.Serialize(c);
                var httpContent = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");
                HttpClient.PutAsync(_urlAPI + "Product", httpContent);

            }
            catch (Exception e)
            {
                throw new Exception("Could not do the transaction in SQL, check the connection string, that the integrity of the queried databases ****** System error : " + e.ToString());
            }
        }
        public void insProducts(Product c)
        {
            try
            {
                try
                {
                    HttpClient HttpClient = new HttpClient();

                    System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12 | System.Net.SecurityProtocolType.Tls11;
                    var jsonRequest = JsonSerializer.Serialize(c);
                    var httpContent = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");
                    HttpClient.PostAsync(_urlAPI + "Product", httpContent);

                }
                catch (Exception e)
                {
                    throw new Exception("Could not do the transaction in SQL, check the connection string, that the integrity of the queried databases ****** System error : " + e.ToString());
                }
            }
            catch (Exception e)
            {
                throw new Exception("Could not do the transaction in SQL, check the connection string, that the integrity of the queried databases ****** System error : " + e.ToString());
            }
        }
    }
}
