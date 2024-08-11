using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Models
{
    internal class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductQuantity { get; set; }
        public int ProductPrice { get; set; }

        public override string ToString()
        {
            return $"Product ID: {ProductId}\n" +
                $"Product Name: {ProductName}\n" +
                $"Product Desc: {ProductDescription}\n" +
                $"Product Quantity: {ProductQuantity}\n" +
                $"Product Price: {ProductPrice}\n";
        }
    }
}
