using Dapper;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Product_DL
    {
        private string _conn { get; set; }
        public Product_DL(string conn)
        {
            _conn = conn;
        }
        public Product GetProduct(int idProduct)
        {
            Product message = new Product();
            try
            {
                using (IDbConnection db = new SqlConnection(_conn))
                {
                    db.Open();
                    message = db.Query<Product>("sel_OnlyProduct", new { idProduct = idProduct }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    db.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Could not do the transaction in SQL, check the connection string, that the integrity of the queried databases ****** System error : " + e.ToString());
            }
            return message;
        }

        public List<Product> GetProducts()
        {
            List<Product> Products = new List<Product>();
            try
            {
                using (IDbConnection db = new SqlConnection(_conn))
                {
                    db.Open();
                    Products = db.Query<Product>("sel_Products", commandType: CommandType.StoredProcedure).ToList();
                    db.Close();
                }
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
                using (IDbConnection db = new SqlConnection(_conn))
                {
                    db.Open();
                    db.Execute("del_Product", new { idProduct = idProduct }, commandType: CommandType.StoredProcedure);
                    db.Close();
                }
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
                using (IDbConnection db = new SqlConnection(_conn))
                {
                    db.Open();
                    db.Execute("upd_Product", new { idProduct = c.idProduct, productName = c.productName, description = c.description, quantity = c.quantity, price = c.price }, commandType: CommandType.StoredProcedure);
                    db.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Could not do the transaction in SQL, check the connection string, that the integrity of the queried databases ****** System error : " + e.ToString());
            }
        }
        public void insProduct(Product c)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(_conn))
                {
                    db.Open();
                    db.Execute("ins_Product", new { productName = c.productName, description = c.description, quantity = c.quantity, price = c.price }, commandType: CommandType.StoredProcedure);
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
