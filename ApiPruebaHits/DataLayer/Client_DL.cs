using Dapper;
using DataObjects;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    public class Client_DL
    {
        private string _conn { get; set; }
        public Client_DL(string conn) 
        {
            _conn = conn;
        }
        public Client GetClient(int idClient)
        {
            Client message = new Client();
            try
            {
                using (IDbConnection db = new SqlConnection(_conn))
                {
                    db.Open();
                    message = db.Query<Client>("sel_OnlyClient", new { idClient = idClient }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    db.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Could not do the transaction in SQL, check the connection string, that the integrity of the queried databases ****** System error : " + e.ToString());
            }
            return message;
        }

        public List<Client> GetClients()
        {
            List<Client> clients = new List<Client>();
            try
            {
                using (IDbConnection db = new SqlConnection(_conn))
                {
                    db.Open();
                    clients = db.Query<Client>("sel_Clients", commandType: CommandType.StoredProcedure).ToList();
                    db.Close();
                }
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
                using (IDbConnection db = new SqlConnection(_conn))
                {
                    db.Open();
                    db.Execute("del_Client", new { idClient = idClient }, commandType: CommandType.StoredProcedure);
                    db.Close();
                }
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
                using (IDbConnection db = new SqlConnection(_conn))
                {
                    db.Open();
                    db.Execute("upd_Client", new { idClient = c.idClient, fullname = c.fullName, Email = c.Email, address = c.address, phone = c.phone }, commandType: CommandType.StoredProcedure);
                    db.Close();
                }
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
                using (IDbConnection db = new SqlConnection(_conn))
                {
                    db.Open();
                    db.Execute("ins_Client", new { fullname = c.fullName, Email = c.Email, address = c.address, phone = c.phone }, commandType: CommandType.StoredProcedure);
                    db.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Could not do the transaction in SQL, check the connection string, that the integrity of the queried databases ****** System error : " + e.ToString());
            }
        }
    }
}