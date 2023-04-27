using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace ProductManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1. Add product");
                Console.WriteLine("2. Display products");
                Console.WriteLine("3. Search product");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddProduct();
                        break;
                    case "2":
                        DisplayProducts();
                        break;
                    case "3":
                        SearchProduct();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void AddProduct()
        {
            Console.Write("Enter product code: ");
            string code = Console.ReadLine();
            Console.Write("Enter product name: ");
            string name = Console.ReadLine();
            Console.Write("Enter manufacturer: ");
            string manufacturer = Console.ReadLine();
            Console.Write("Enter price: ");
            string price = Console.ReadLine();
            Console.Write("Enter description: ");
            string description = Console.ReadLine();

            using (StreamWriter sw = new StreamWriter("products.csv", true, Encoding.UTF8))
            {
                sw.WriteLine($"{code},{name},{manufacturer},{price},{description}");
            }

            Console.WriteLine("Product added successfully!");
        }

        static void DisplayProducts()
        {
            using (StreamReader sr = new StreamReader("products.csv", Encoding.UTF8))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] fields = line.Split(',');
                    Console.WriteLine($"Code: {fields[0]}");
                    Console.WriteLine($"Name: {fields[1]}");
                    Console.WriteLine($"Manufacturer: {fields[2]}");
                    Console.WriteLine($"Price: {fields[3]}");
                    Console.WriteLine($"Description: {fields[4]}");
                    Console.WriteLine();
                }
            }
        }

        static void SearchProduct()
        {
            Console.Write("Enter product code to search: ");
            string code = Console.ReadLine();

            bool productFound = false;

            using (StreamReader sr = new StreamReader("products.csv", Encoding.UTF8))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] fields = line.Split(',');
                    if (fields[0] == code)
                    {
                        Console.WriteLine($"Code: {fields[0]}");
                        Console.WriteLine($"Name: {fields[1]}");
                        Console.WriteLine($"Manufacturer: {fields[2]}");
                        Console.WriteLine($"Price: {fields[3]}");
                        Console.WriteLine($"Description: {fields[4]}");
                        Console.WriteLine();
                        productFound = true;
                        break;
                    }
                }
            }

            if (!productFound)
            {
                Console.WriteLine("Product not found!");
            }
        }
    }
}

