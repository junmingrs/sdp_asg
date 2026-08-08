using System;

public class Customer : Observer
{
    private string name;
    private string email;

    public Customer(string name, string email)
    {
        this.name = name;
        this.email = email;
    }

    public void update(SpecialOffer offer)
    {
        Console.WriteLine($"  → {name} received: {offer.getBrand().getBrandName()} has a new offer - {offer.getOfferName()} ({offer.getDiscount()}% off)!");
    }

    public string getName() { return name; }
    public string getEmail() { return email; }
}