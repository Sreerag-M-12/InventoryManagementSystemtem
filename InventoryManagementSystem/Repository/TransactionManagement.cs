using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Data;
using InventoryManagementSystem.Exceptions;
using InventoryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Repository
{
    internal class TransactionManagement
    {
        public readonly InventoryContext _context;

        public TransactionManagement(InventoryContext context)
        {
            _context = context;
        }

        public void AddTransaction(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
        }

        public void AddStock(string name, int quantity) {
            var product = _context.Products.Where(x => x.ProductName == name).FirstOrDefault();

            if (product != null)
            {

                product.ProductQuantity += quantity;

                _context.Entry(product).State = EntityState.Modified;
                Transaction transaction=new Transaction() { 
                    ProductId = product.ProductId,
                    ActionType="Stock Added",
                    TransactionQuantity = quantity,
                    Date = DateTime.Now
                };
                AddTransaction(transaction);
                _context.SaveChanges();
            }
            else
            {
                throw new NoSuchItemException("No such Product Exists");
            }
        }

        public void RemoveStock(string name, int quantity)
        {
            var product = _context.Products.Where(x => x.ProductName == name).FirstOrDefault();
            if (product == null)
            {
                throw new NoSuchItemException("Product Not Found");
            }
            else
            {
                
                product.ProductQuantity -= quantity;
                
                _context.Entry(product).State = EntityState.Modified;
                Transaction transaction = new Transaction()
                {
                    ProductId = product.ProductId,
                    ActionType = "Stock Removed",
                    TransactionQuantity = quantity,
                    Date = DateTime.Now
                };
                AddTransaction(transaction);
                _context.SaveChanges();

            }
            
        }
       
        public List<Transaction> GetAllTransaction()
        {
            return _context.Transactions.ToList();
        }

        public void DisplayTransaction(List<Transaction> transactions)
        {
            if (transactions.Count == 0)
                throw new DatabaseEmptyException("Transaction Db is empty");
            transactions.ForEach(transaction => Console.WriteLine(transaction));
        }
    }
}
