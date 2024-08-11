using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Exceptions;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Repository;

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
                    "5. View All Supplier \n" +
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
                    Console.WriteLine("Enter Supplier Details ");
                    Console.WriteLine("Supplier Name");
                    string name = Console.ReadLine();
                    Console.WriteLine("Suppliers Contact");
                    string contact = Console.ReadLine();
                    Supplier supplier = new Supplier()
                    {
                        SupplierName=name,
                        SupplierContact=contact
                    };
                    supplierManager.AddSupplier(supplier);
                    Console.WriteLine();
                    break;

                case 2:
                    Console.WriteLine("Supplier ID");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Supplier Name");
                    string name1 = Console.ReadLine();
                    Console.WriteLine("Supplier Contact");
                    string contact1 = Console.ReadLine();
                    supplier = new Supplier()
                    {
                        SupplierId = id,
                        SupplierName = name1,
                        SupplierContact = contact1
                    };
                    supplierManager.UpdateSupplier(supplier);
                    Console.WriteLine();
                    break;
                case 3:
                    Console.WriteLine("Enter Supplier Name to Delete");
                    string nameDelete = Console.ReadLine();
                    supplierManager.DeleteSupplier(nameDelete);
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
                    var inventoryMenu = new InventoryMenu();
                    inventoryMenu.MainMenu();
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    Console.WriteLine();
                    break;
            }
        }
    }
}
