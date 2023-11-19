using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class Product
    {
        public int idProduct { get; set; }
        public string productName { get; set; }
        public string description { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }
    }
}
