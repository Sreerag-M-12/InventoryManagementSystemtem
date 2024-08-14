using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Exceptions;
using InventoryManagementSystem.Repository;

namespace InventoryManagementSystem.Controllers
{
    internal class TransactionMenu
    {
        TransactionManagement transactionmanager = new TransactionManagement(new Data.InventoryContext());
        public void OpenTransactionMenu()
        {
            while (true)
            {
                Console.WriteLine("Welcome to Transaction Menu");
                Console.WriteLine("What operation would you like to perform? \n" +
                    "1. Add new Stock \n" +
                    "2. Remove Stock \n" +
                    "3. View Transaction Log \n" +
                    "4. Exit \n");

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
                catch (NegativeStockException nse)
                {
                    Console.WriteLine(nse.Message);
                }
               
            }
        }

        public void DoTask(int choice)
        {
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter Product Name");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter Quantity");
                    int quantity = Convert.ToInt32(Console.ReadLine());
                    transactionmanager.AddStock(name, quantity);
                    Console.WriteLine("stock added to "+ name);
                    break;
                case 2:
                    Console.WriteLine("Enter Product Name");
                    name = Console.ReadLine();
                    Console.WriteLine("Enter Quantity");
                    quantity = Convert.ToInt32(Console.ReadLine());
                    transactionmanager.RemoveStock(name, quantity);
                    Console.WriteLine("stock removed from " + name);
                    break;
                case 3:
                    Console.WriteLine("Transaction Log");
                    transactionmanager.DisplayTransaction(transactionmanager.GetAllTransaction());
                    break;
                case 4:
                    var inventoryMenu = new InventoryMenu();
                    inventoryMenu.MainMenu();
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }
        }
    }
}