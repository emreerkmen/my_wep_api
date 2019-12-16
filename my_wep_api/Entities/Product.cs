using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_wep_api.Entities
{
    public class Product : IEntity//Burda IEntity ile product'ın bir database nesnesi olduğunu belirtiyorum
    {
        public int ProductId { get => productId; set => productId = value; }
        public string ProductName { get => productName; set => productName = value; }
        public int CategoryId { get => categoryId; set => categoryId = value; }
        public decimal UnitPrice { get => unitPrice; set => unitPrice = value; }
        public short UnitsInStock { get => unitsInStock; set => unitsInStock = value; }

        private int productId;

        private string productName;

        private int categoryId;

        private decimal unitPrice;

        private short unitsInStock;

    }

}
