using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Data;
using InventoryManagementSystem.Exceptions;
using InventoryManagementSystem.Migrations;
using InventoryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Repository
{
    internal class ProductManagement
    {
        public readonly InventoryContext _context;

        public ProductManagement(InventoryContext context)
        {
            _context = context;
        }

        public bool DoesProductExist(string productName)
        {
            return _context.Products.Any(p => p.ProductName == productName);
        }

      
        public void AddProduct(Product product)
        {
            if (DoesProductExist(product.ProductName))
            {
                throw new InvalidOperationException("Product name already exists in the database.");
            }
            _context.Products.Add(product);
            _context.SaveChanges();
        }
        public void UpdateProduct(Product product)
        {
            // Retrieve the existing product
            var existingProduct = _context.Products.Find(product.ProductId);

            if (existingProduct != null)
            {
               
                existingProduct.ProductName = product.ProductName;
                existingProduct.ProductDescription = product.ProductDescription;
                existingProduct.ProductPrice = product.ProductPrice;

                _context.Entry(existingProduct).State = EntityState.Modified;
            }
            else
            {
                throw new NoSuchItemException("No Such Product exists");
            }
            if (DoesProductExist(product.ProductName))
            {
                throw new InvalidOperationException("Product name already exists in the database.");
            }
            _context.SaveChanges();
        }
        public void DeleteProduct(string name)
        {
            var product = _context.Products.Where(x => x.ProductName == name).FirstOrDefault();
            if (product != null)
            {
                Console.WriteLine(product);
                _context.Products.Remove(product);
                _context.SaveChanges();
              
            }
            else
                throw new NoSuchItemException("No Such Product exists");
        }

        public void DisplayProductById(int id)
        {
            var product = _context.Products.Where(x => x.ProductId == id).FirstOrDefault();
            if (product != null)
                Console.WriteLine(product);
            else
                throw new NoSuchItemException("No Such Product exists");
        }
        public List<Product> GetAllProduct()
        {
            return _context.Products.ToList();
        }

        public void DisplayProducts(List<Product> products)
        {
            if (products.Count == 0)
                throw new DatabaseEmptyException("Product Db is empty");

            products.ForEach(product => Console.WriteLine(product));
        }
    }
}
