using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Exceptions;
using InventoryManagementSystem.Repository;

namespace InventoryManagementSystem.Controllers
{
    internal class Report
    {
        InventoryManagement inventorymanager = new InventoryManagement(new Data.InventoryContext());
        public void OpenInventoryMenu()
        {
            while (true)
            {
                Console.WriteLine("Report Generation");
                Console.WriteLine("What operation would you like to perform? \n" +
                    "1. Generate Report individually \n" +
                    "2. Generate Bulk Report \n" +
                    "3. Exit \n");

                Console.WriteLine("Enter your Choice");
                int choice = Convert.ToInt32(Console.ReadLine());
                try
                {
                    DoTask(choice);
                }
                catch(NoSuchItemException nsie) 
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
                    Console.WriteLine("Enter Inventory ID:");
                    int inventoryId = Convert.ToInt32(Console.ReadLine());                        
                    inventorymanager.GenerateReport(inventoryId);
                    break;
                case 2:
                    inventorymanager.GenerateReportBulk();
                    break;
                case 3:
                    InventoryMenu.MainMenu();
                    break;
                default:
                    Console.WriteLine("Invalid output");
                    break;
            }
        }

    }
}
