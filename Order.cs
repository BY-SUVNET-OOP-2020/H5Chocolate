using System;
using System.Collections.Generic;

public class Order
{
    //public string message; //TODO: Lägg till funktionalitet för att lägga in meddelande
    //public Address adress; //TODO: Lägg till klass
    //public Package package; //TODO: Lägg till klass
    public bool confirmed;
    private List<Chocolate> items = new List<Chocolate>();

    public Donation donation;

    public void AddChocolate(Chocolate chocolate)
    {
        items.Add(chocolate);
        Console.WriteLine("[Chocolate ordered]");
    }

    public string GetOrderList()
    {
        string output = "";
        foreach (Chocolate item in items)
        {
            output += item.name + ", ";
        }

        return output;
    }

    public bool HasChocolate()
    {
        return items.Count > 0;
    }

    public bool IsConfirmable()
    {
        return items.Count > 0 && donation != null;
    }

    public bool Confirm()
    {
        if (IsConfirmable())
        {
            confirmed = true;
        }

        return confirmed;
    }
}