using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Exceptions;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Repository;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Controllers
{

    internal class ProductMenu
    {
        ProductManagement productmanager = new ProductManagement(new Data.InventoryContext());
        public  void OpenProductMenu()
        {
            while (true)
            {
                Console.WriteLine("Welcome to Product Menu");
                Console.WriteLine("What operation would you like to perform? \n" +
                    "1. Add new Product \n" +
                    "2. Update a Product \n" +
                    "3. Delete a product \n" +
                    "4. View Product List \n" +
                    "5. View Product by Id \n" +
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
                    Console.WriteLine("Enter Product Details ");
                    Console.WriteLine("Product Name");
                    string name = Console.ReadLine();
                    try
                    {
                        productmanager.DoesProductExist(name);
                    }
                    catch(InvalidOperationException ioe) {
                        Console.WriteLine(ioe.Message);
                    }
                    Console.WriteLine("Product Description");
                    string description = Console.ReadLine();
                    Console.WriteLine("Product Quantity");
                    int quantity = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Product Price");
                    int price = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Inventory Id");
                    int inventoryId = Convert.ToInt32(Console.ReadLine());
                    InventoryManagement inventoryManagement= new InventoryManagement(new Data.InventoryContext());
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
                    Product product = new Product()
                    { 
                        ProductName =name,
                        ProductDescription=description,
                        ProductQuantity=quantity,
                        ProductPrice=price,
                        InventoryId = inventoryId
                    };
                    productmanager.AddProduct(product);
                    Console.WriteLine();
                    break;
                
                case 2:
                    Console.WriteLine("Product ID");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Product Name");
                    name = Console.ReadLine();
                    try
                    {
                        productmanager.DoesProductExist(name);
                    }
                    catch (InvalidOperationException ioe)
                    {
                        Console.WriteLine(ioe.Message);
                    }
                    Console.WriteLine("Product Description");
                    description = Console.ReadLine();
                    Console.WriteLine("Product Price");
                    price = Convert.ToInt32(Console.ReadLine());
                    product = new Product()
                    {
                        ProductId = id,
                        ProductName = name,
                        ProductDescription = description,
                        ProductPrice = price
                    };
                    productmanager.UpdateProduct(product);
                    Console.WriteLine();
                    break;
                case 3:
                    Console.WriteLine("Enter Product Name to Delete");
                    string nameDelete = Console.ReadLine();
                    productmanager.DeleteProduct(nameDelete);
                    break;
                case 4:
                    productmanager.DisplayProducts(productmanager.GetAllProduct());
                    break;
                case 5:
                    Console.WriteLine("Enter Product ID");
                    int id1 = Convert.ToInt32(Console.ReadLine());
                    productmanager.DisplayProductById(id1);
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
