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
    internal class SupplierManagement
    {
        public readonly InventoryContext _context;

        public SupplierManagement(InventoryContext context)
        {
            _context = context;
        }

        public void AddSupplier(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
        }
        public void UpdateSupplier(Supplier supplier)
        {
            // Retrieve the existing product
            var existingSupplier = _context.Suppliers.Find(supplier.SupplierId);

            if (existingSupplier != null)
            {

                existingSupplier.SupplierName = supplier.SupplierName;
                existingSupplier.SupplierContact= supplier.SupplierContact;

                _context.Entry(existingSupplier).State = EntityState.Modified;
            }
            else
            {
                throw new NoSuchItemException("Supplier not found");
            }
            _context.SaveChanges();
        }
        public void DeleteSupplier(string name)
        {
            var supplier = _context.Suppliers.Where(x => x.SupplierName == name).FirstOrDefault();
            if (supplier != null)
            {
                Console.WriteLine(supplier);
                _context.Suppliers.Remove(supplier);
                _context.SaveChanges();
                Console.WriteLine($"Supplier {supplier.SupplierName} deleted");
            }
            else
                throw new NoSuchItemException("Supplier not found");
        }

        public void DisplaySupplierById(int id)
        {
            var supplier = _context.Suppliers.Where(x => x.SupplierId == id).FirstOrDefault();
            if (supplier != null)
                Console.WriteLine(supplier);
            else
                throw new NoSuchItemException("Supplier not found");
        }
        public List<Supplier> GetAllSupplier()
        {
            return _context.Suppliers.ToList();
        }

        public void DisplaySupplier(List<Supplier> suppliers)
        {
            if (suppliers.Count == 0)
                throw new DatabaseEmptyException("Supplier Db is empty");

            suppliers.ForEach(suppliers => Console.WriteLine(suppliers));
        }
    }
}
