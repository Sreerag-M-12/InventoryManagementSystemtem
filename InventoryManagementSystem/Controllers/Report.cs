using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    "1. Generate Report \n"  +
                    "2. Exit \n");

                Console.WriteLine("Enter your Choice");
                int choice = Convert.ToInt32(Console.ReadLine());
                DoTask(choice);
            }
        }

        public void DoTask(int choice)
        {
            switch (choice)
            {
                case 1:
                    inventorymanager.generateReport();
                    break;
                case 2:
                    var inventoryMenu = new InventoryMenu();
                    inventoryMenu.MainMenu();
                    break;
                default:
                    Console.WriteLine("Invalid output");
                    break;
            }
        }
    }
}
