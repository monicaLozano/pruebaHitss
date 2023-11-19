using Dapper;
using DataObjects;
using System.Data;
using System.Data.SqlClient;
using System.Text.Json;

namespace DataLayer
{
    public class Client_DL
    {
        private string _urlAPI { get; set; }
        public Client_DL (string urlAPI)
        {
            _urlAPI = urlAPI;
        }

        public async Task<Client> GetClient(int idClient)
        {
            Client client = new Client();
            try
            {
                HttpClient httpClient = new HttpClient();

                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12 | System.Net.SecurityProtocolType.Tls11;

                var response = await httpClient.GetAsync(_urlAPI + "Client/" + idClient);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    client = JsonSerializer.Deserialize<Client>(content);
                }
                else
                {
                    Console.WriteLine($"Error en la solicitud: {response.Content}");
                }

                return client;
            }
            catch (Exception e)
            {
                throw new Exception("Could not do the transaction in SQL, check the connection string, that the integrity of the queried databases ****** System error : " + e.ToString());
            }
            return client;
        }

        public async Task<List<Client>> GetClients()
        {
            List<Client> clients = new List<Client>();
            try
            {
                HttpClient httpClient = new HttpClient();

                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12 | System.Net.SecurityProtocolType.Tls11;

                var response = await httpClient.GetAsync(_urlAPI + "Client" );
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    clients = JsonSerializer.Deserialize<List<Client>>(content);
                }
                else
                {
                    Console.WriteLine($"Error en la solicitud: {response.Content}");
                }

                return clients;
            }
            catch (Exception e)
            {
                throw new Exception("Could not do the transaction in SQL, check the connection string, that the integrity of the queried databases ****** System error : " + e.ToString());
            }
            return clients;
        }
        public void DelClients(int idClient)
        {
            try
            {
                HttpClient httpClient = new HttpClient();

                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12 | System.Net.SecurityProtocolType.Tls11;

                httpClient.DeleteAsync(_urlAPI + "Client/" + idClient);
                
            }
            catch (Exception e)
            {
                throw new Exception("Could not do the transaction in SQL, check the connection string, that the integrity of the queried databases ****** System error : " + e.ToString());
            }
        }
        public void updClients(Client c)
        {
            try
            {
                HttpClient httpClient = new HttpClient();

                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12 | System.Net.SecurityProtocolType.Tls11;
                var jsonRequest = JsonSerializer.Serialize(c);
                var httpContent = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");
                httpClient.PutAsync(_urlAPI + "Client", httpContent);

            }
            catch (Exception e)
            {
                throw new Exception("Could not do the transaction in SQL, check the connection string, that the integrity of the queried databases ****** System error : " + e.ToString());
            }
        }
        public void insClients(Client c)
        {
            try
            {
                try
                {
                    HttpClient httpClient = new HttpClient();

                    System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12 | System.Net.SecurityProtocolType.Tls11;
                    var jsonRequest = JsonSerializer.Serialize(c);
                    var httpContent = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");
                    httpClient.PostAsync(_urlAPI + "Client", httpContent);

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