using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Exceptions;
using InventoryManagementSystem.Migrations;

namespace InventoryManagementSystem.Controllers
{
    internal class InventoryMenu
    {
        public static void MainMenu()
        {
            while (true)
            {
                Console.WriteLine("Welcome to Inventory Management System");
                Console.WriteLine(
                    "1. Product Management \n" +
                    "2. Supplier Management\n" +
                    "3. Transaction Management \n" +
                    "4. Generate Report \n" +
                    "5. Exit \n");

                Console.WriteLine("Enter your Choice");
                int choice = Convert.ToInt32(Console.ReadLine());
                try
                {
                    DoTask(choice);
                }
                catch(DatabaseEmptyException de)
                {
                    Console.WriteLine(de.Message);
                }
              
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static void DoTask(int choice)
        {
            switch (choice) 
            {
                case 1:
                    ProductMenu productMenu = new ProductMenu();
                    productMenu.OpenProductMenu();
                    Console.WriteLine();
                    break;
                case 2:
                    SupplierMenu supplierMenu = new SupplierMenu();
                    supplierMenu.OpenSupplierMenu();
                    Console.WriteLine();
                    break;
                case 3:
                    TransactionMenu transactionMenu = new TransactionMenu();
                    transactionMenu.OpenTransactionMenu();
                    break;
                case 4:
                    Report report = new Report();
                    report.OpenInventoryMenu();
                    break ;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    Console.WriteLine();
                    break;

            }

        }
        
    }
}
