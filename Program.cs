using System;
using System.Collections.Generic;
using Faker;
using Console = Colorful.Console;
using System.Drawing;
using System.Runtime.Serialization;

namespace H5Chocolate
{
    class Program
    {
        static void Main()
        {
            List<Product> productDatabase = GenerateFakeProducts();
            List<string> organizationDatabase = GenerateFakeOrganizations();

            Random random = new Random();
            Order order = new Order(random.Next(1000, 100000));

            while (true)
            {
                PrintWelcomeMessage();
                PrintProducts(productDatabase);
                PrintCurrentOrder(order);

                Console.WriteLine("\n[B] Lägg beställning   [A] Avsluta");

                Console.Write("\n:> ");
                string input = Console.ReadLine().ToUpper();

                if (input == "B")
                {
                    Console.WriteLine("Välj organisation att donera till:");

                    Donation donation = new Donation("BY");

                    Console.WriteLine($"Vald organisation: {donation.Organization}");
                    Console.Write("Summa: ");
                    donation.amount = Convert.ToInt32(Console.ReadLine());

                    order.donation = donation;

                    bool orderSuccesfull = order.Confirm();
                    if (orderSuccesfull)
                    {
                        Console.WriteLine("Beställning skickad! Tack!");
                        Console.ReadLine();
                    }
                }
                else if (input == "B" && !order.IsConfirmable())
                {
                    Console.WriteLine("Något gick fel!", Color.Red);
                }
                else if (input == "A")
                {
                    Environment.Exit(0);
                }
                else
                {
                    int index = Convert.ToInt32(input);
                    order.AddProduct(productDatabase[index]);
                }
            }
        }

        private static void PrintCurrentOrder(Order order)
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"{order.Count} produkter i ordern:");
            Console.WriteLine(order.GetOrderedItemsAsString());
            Console.WriteLine("----------------------------------");
        }

        private static void PrintWelcomeMessage()
        {
            string catchPhrase = Faker.Company.CatchPhrase();
            Console.Clear();
            /* fixformat ignore:start */
            Console.WriteLine("---------------------------------------\n " +
                              "Välkommen till H5Chocolate Ordersystem  \n " +
                             $"{catchPhrase}\n " +
                              "---------------------------------------");
            /* fixformat ignore:end */
        }

        private static void PrintProducts(List<Product> chocolateDatabase)
        {
            Console.WriteLine("Välj en produkt att lägga till: \n");
            foreach (Chocolate c in chocolateDatabase)
            {
                /* fixformat ignore:start */
                Console.Write("[");
                Console.Write($"{chocolateDatabase.IndexOf(c)}", Color.Blue);
                Console.Write($"] {c.Name}");
                /* fixformat ignore:end */
            }

        }

        private static List<Product> GenerateFakeProducts()
        {
            List<Product> chocolateDatabase = new List<Product>();

            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                int cacaoAmount = random.Next(0, 100);
                /* fixformat ignore:start */
                var fillings = new List<string>(new string[]{"Havre","Hockeypulver","Majs"});
                Chocolate chocolate = new Chocolate("Chocolate " + Faker.Name.Last(), cacaoAmount, 100 - cacaoAmount, fillings);
                /* fixformat ignore:end */
                chocolateDatabase.Add(chocolate);
            }

            return chocolateDatabase;
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
    }
}