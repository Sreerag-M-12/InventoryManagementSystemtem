using InventoryManagementSystem.Controllers;
using InventoryManagementSystem.Data;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Repository;

namespace InventoryManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InventoryMenu menu=new InventoryMenu();
            menu.MainMenu();
        }
    }
}
