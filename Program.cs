using System;
using System.Collections.Generic;

namespace H5Chocolate
{
    class Program
    {
        static void Main()
        {
            List<Chocolate> chocolateDatabase = GenerateTestData();

            Order order = new Order();

            Console.Clear();
            Console.WriteLine(
                "------------------------------------------\n" +
                "| Välkommen till H5Chocolate Ordersystem |\n" +
                "------------------------------------------");

            while (true)
            {
                Console.WriteLine("Välj en produkt:\n");
                foreach (Chocolate c in chocolateDatabase)
                {
                    Console.WriteLine($"[{chocolateDatabase.IndexOf(c)}]: {c.name}");
                }
                Console.WriteLine("\n[B] Lägg beställning   [A] Avsluta");

                Console.Write("\nVal: ");
                string input = Console.ReadLine().ToUpper();

                if (input == "B" && order.HasChocolate())
                {
                    Console.WriteLine("Välj organisation för att gå vidare:");

                    Donation donation = new Donation();
                    donation.organization = "BY";

                    Console.WriteLine($"Vald organisation: {donation.organization}");
                    Console.Write("Summa: ");
                    donation.amount = Convert.ToInt32(Console.ReadLine());

                    order.donation = donation;

                    bool orderSuccesfull = order.Confirm();
                    if (orderSuccesfull)
                    {
                        Console.WriteLine("Beställning skickad! Tack!");
                    }
                }
                else if (input == "B" && !order.IsConfirmable())
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Något gick fel!");
                    Console.ResetColor();
                }
                else if (input == "A")
                {
                    Environment.Exit(0);
                }
                else
                {
                    int index = Convert.ToInt32(input);
                    order.AddChocolate(chocolateDatabase[index]);

                    Console.WriteLine($"Du har beställt: {order.GetOrderList()}");
                }
                Console.WriteLine("------------");
            }
        }

        private static List<Chocolate> GenerateTestData()
        {
            List<Chocolate> chocolateDatabase = new List<Chocolate>();

            Chocolate chocolate = new Chocolate();
            chocolate.name = "Hockeypulverchokladkaka";
            chocolate.cacaoAmount = 4;
            chocolate.milkAmount = 12;
            chocolate.filling.Add("Hockeypulver");
            chocolate.filling.Add("Havregryn");

            chocolateDatabase.Add(chocolate);

            Chocolate chocolate2 = new Chocolate();
            chocolate2.name = "Hasselnötschoklad";
            chocolate2.cacaoAmount = 4;
            chocolate2.milkAmount = 12;
            chocolate2.filling.Add("Hockeypulver");
            chocolate2.filling.Add("Havregryn");

            chocolateDatabase.Add(chocolate2);

            return chocolateDatabase;
        }
    }
}