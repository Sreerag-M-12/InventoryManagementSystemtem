using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Exceptions;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace InventoryManagementSystem.Controllers
{
    internal class SupplierMenu
    {
        SupplierManagement supplierManager = new SupplierManagement(new Data.InventoryContext());
        public void OpenSupplierMenu()
        {
            while (true)
            {
                Console.WriteLine("Welcome to Supplier Menu");
                Console.WriteLine("What operation would you like to perform? \n" +
                    "1. Add new Supplier \n" +
                    "2. Update a Supplier \n" +
                    "3. Delete a Supplier \n" +
                    "4. View Supplier Details \n" +
                    "5. View Supplier by Id \n" +
                    "6. Exit \n");

                Console.WriteLine("Enter your Choice");
                int choice = Convert.ToInt32(Console.ReadLine());
                try
                {
                    DoTask(choice);
                }
                catch (NoSuchItemException nsie) 
                {
                    Console.WriteLine(nsie.Message);
                }
            }
        }

        public void DoTask(int choice)
        {
            switch (choice)
            {
                case 1:
                    Add();
                    break;

                case 2:
                    Update();
                    break;
                case 3:
                    Delete();
                    break;
                case 4:
                    supplierManager.DisplaySupplier(supplierManager.GetAllSupplier());
                    break;
                case 5:
                    Console.WriteLine("Enter Supplier ID");
                    int id1 = Convert.ToInt32(Console.ReadLine());
                    supplierManager.DisplaySupplierById(id1);
                    break;
                case 6:
                    InventoryMenu.MainMenu();
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    Console.WriteLine();
                    break;
            }
        }
        public void Add()
        {
            Console.WriteLine("Enter Supplier Details ");
            Console.WriteLine("Supplier Name");
            string name = Console.ReadLine();
            Console.WriteLine("Suppliers Contact");
            string contact = Console.ReadLine();
            Console.WriteLine("Inventory Id");
            int inventoryId = Convert.ToInt32(Console.ReadLine());
            InventoryManagement inventoryManagement = new InventoryManagement(new Data.InventoryContext());
            try
            {
                if (!inventoryManagement.IsInventoryIdValid(inventoryId))
                {
                    throw new InvalidOperationException("Invalid Inventory Id. Inventory doesnt exist.");
                }
            }
            catch (InvalidOperationException ioe)
            {
                Console.WriteLine(ioe.Message);
                return;
            }
            Supplier supplier = new Supplier()
            {
                SupplierName = name,
                SupplierContact = contact,
                InventoryId = inventoryId
            };
            supplierManager.AddSupplier(supplier);
            Console.WriteLine("supplier added");
            Console.WriteLine();
        }
        public void Update()
        {
            Console.WriteLine("Supplier ID");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Supplier Name");
            string name = Console.ReadLine();
            Console.WriteLine("Supplier Contact");
            string contact = Console.ReadLine();
            var supplier = new Supplier()
            {
                SupplierId = id,
                SupplierName = name,
                SupplierContact = contact
            };
            supplierManager.UpdateSupplier(supplier);
            Console.WriteLine("Supplier updated");
            Console.WriteLine();

        }

        public void Delete()
        {
            Console.WriteLine("Enter Supplier Name to Delete");
            string nameDelete = Console.ReadLine();
            supplierManager.DeleteSupplier(nameDelete);
            Console.WriteLine("supplier deleted");

        }
    }
}
