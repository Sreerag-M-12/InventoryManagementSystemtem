using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Data;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Repository
{
    internal class InventoryManagement
    {
        List <Product> Products {  get; set; }
        List<Supplier> Suppliers { get; set; }
        List<Transaction> Transactions { get; set; }

        public readonly InventoryContext _context;

        public InventoryManagement(InventoryContext context)
        {
            _context = context;
            Products = GetAllProduct();
            Suppliers = GetAllSupplier();
            Transactions = GetAllTransaction();
        }
        public List<Product> GetAllProduct()
        {
            return _context.Products.ToList();
        }
        public List<Supplier> GetAllSupplier()
        {
            return _context.Suppliers.ToList();
        }
        public List<Transaction> GetAllTransaction()
        {
            return _context.Transactions.ToList();
        }

        public void generateReport() 
        {
            Products.ForEach(product => Console.WriteLine(product));
            Suppliers.ForEach(supplier => Console.WriteLine(supplier));
            Transactions.ForEach(transaction => Console.WriteLine(transaction));
        }
    }
}
