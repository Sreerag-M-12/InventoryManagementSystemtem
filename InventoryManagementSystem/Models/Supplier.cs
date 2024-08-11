using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Models
{
    internal class Supplier
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string SupplierContact { get; set; }

        public override string ToString()
        {
            return $"Supplier Id: {SupplierId}\n" +
                $"Supplier Name: {SupplierName}\n" +
                $"Supplier Contact: {SupplierContact}\n";
        }
    }
}
