using System;
using System.Collections.Generic;
using Console = Colorful.Console;
using System.Drawing;
using System.Linq;
using Faker;

namespace H5Chocolate
{
    class Program
    {
        static void Main()
        {
            List<Product> productDatabase = GenerateFakeProducts();
            List<string> organizationDatabase = GenerateFakeOrganizations();

            Random random = new Random();
            Order order = null;

            while (true)
            {
                PrintWelcomeMessage();
                PrintProducts(productDatabase);
                PrintCurrentOrder(order);
                PrintFooter();

                string input = Console.ReadLine().ToUpper();

                if (input == "B" && order != null)
                {
                    order.donation = new Donation();

                    Console.WriteLine("Välj organisation att donera till:\n");
                    PrintOrganizations(organizationDatabase);

                    int choice = ReadLineAsInt(":> ", organizationDatabase.Count - 1);
                    order.donation.Organization = organizationDatabase[choice];
                    Console.WriteLine($"Vald organisation: {order.donation.Organization}");

                    Console.Write("Summa: ");
                    order.donation.Amount = Convert.ToInt32(Console.ReadLine());

                    bool orderSuccesfull = order.Confirm();
                    if (orderSuccesfull)
                    {
                        Console.WriteLine("Beställning skickad! Tack!");
                        order = null;
                        Console.ReadLine();
                    }
                }
                else if (input == "B")
                {
                    ShowErrorMessage("Det finns ingen order att lägga.");
                }
                else if (input == "A")
                {
                    Environment.Exit(0);
                }
                else // Add things to the order (numbers)
                {
                    try
                    {
                        int index = Convert.ToInt32(input);
                        if (index > -1 && index <= productDatabase.Count - 1)
                        {
                            if (order == null) order = new Order();
                            order.AddProduct(productDatabase[index]);
                        }
                        else
                        {
                            ShowErrorMessage("Du skrev nog in en för hög siffra!");
                        }
                    }
                    catch
                    {
                        ShowErrorMessage("Du måste skriva en siffra, B eller A.");
                    }
                }
            }
        }

        private static void ShowErrorMessage(string message)
        {
            Console.WriteLine(message, Color.Red);
            Console.WriteLine("Tryck <enter> för att fortsätta...");
            Console.ReadLine();
        }

        private static void PrintFooter()
        {
            Console.WriteLine("\n[B] Lägg beställning   [A] Avsluta");
            Console.Write("\n:> ");
        }

        private static void PrintOrganizations(List<string> orgs)
        {
            foreach (string o in orgs)
            {
                Console.Write("[");
                Console.Write($"{orgs.IndexOf(o)}", Color.Blue);
                Console.Write($"] {o} \n");
            }
            Console.WriteLine();
        }

        private static void PrintCurrentOrder(Order order)
        {
            if (order != null)
            {
                Console.WriteLine("\n----------------------------------");
                Console.WriteLine($"{order.Count} produkter i ordern:", Color.Blue);
                Console.Write(order.GetOrderedItemsAsString());
                Console.WriteLine("----------------------------------");
            }
        }

        private static void PrintWelcomeMessage()
        {
            string catchPhrase = Faker.Company.CatchPhrase();
            Console.Clear();
            /* fixformat ignore:start */
            Console.WriteLine("---------------------------------------\n " +
                              "Välkommen till H5Chocolate Ordersystem  \n " +
                             $"{catchPhrase}\n " +
                              "---------------------------------------", Color.WhiteSmoke);
            /* fixformat ignore:end */
        }

        private static void PrintProducts(List<Product> productDatabase)
        {
            Console.WriteLine("Välj en produkt att lägga till: \n");
            foreach (Product product in productDatabase)
            {
                Console.Write("[");
                Console.Write($"{productDatabase.IndexOf(product)}", Color.Blue);

                /* fixformat ignore:start */
                switch (product)
                {
                    case Chocolate choco:
                        Console.WriteLine($"] {choco.Name} ({choco.CacaoAmount}% cacao)");
                        break;
                    
                    case Product prod:
                        Console.WriteLine($"] {prod.Name}");
                        break;
                }
                /* fixformat ignore:end */
            }
        }

        private static List<Product> GenerateFakeProducts()
        {
            List<Product> productDatabase = new List<Product>();

            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                int cacaoAmount = random.Next(0, 100);
                /* fixformat ignore:start */
                var fillings = new List<string>(new string[]{"Havre","Hockeypulver","Majs"});
                Chocolate chocolate = new Chocolate("Chocolate " + Faker.Name.Last(), cacaoAmount, 100 - cacaoAmount, fillings);
                /* fixformat ignore:end */
                productDatabase.Add(chocolate);
            }

            Product product = new Product { ID = 0, Name = "Slips" };
            productDatabase.Add(product);

            return productDatabase;
        }

        private static List<string> GenerateFakeOrganizations()
        {
            var fakeOrg = new List<string>();

            for (int i = 0; i < 5; i++)
            {
                fakeOrg.Add(Faker.Company.Name());
            }
            return fakeOrg;
        }

        private static int ReadLineAsInt(string prompt, int maxValue = -1)
        {
            int output = -1;
            bool success = false;

            do
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                try
                {
                    output = Convert.ToInt32(input);
                    if ((maxValue == -1 || output <= maxValue) && output >= 0) success = true;
                    else Console.WriteLine("Skriv en siffra mellan 0 - " + maxValue, Color.Red);
                }
                catch
                {
                    Console.WriteLine("Du måste skriva en siffra.", Color.Red);
                }
            } while (!success);

            return output;
        }
    }
}