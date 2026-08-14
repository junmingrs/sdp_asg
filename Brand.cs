namespace SDP_ASG;

public class Brand : Subject
{
    private string brandName;
    private List<Observer> observers;
    private List<SpecialOffer> offers;

    public List<Observer> Observers
    {
        get { return observers; }
    }

    public Brand(string brandName)
    {
        this.brandName = brandName;
        observers = new List<Observer>();
        offers = new List<SpecialOffer>();
    }

    public void registerObserver(Observer o)
    {
        observers.Add(o);
        Customer c = (Customer)o;
        Console.WriteLine($"{c.Name} subscribed to {brandName}!");
    }

    public void removeObserver(Observer o)
    {
        observers.Remove(o);
        Customer c = (Customer)o;
        Console.WriteLine($"{c.Name} unsubscribed from {brandName}.");
    }

    public void notifyObservers()
    {
        foreach (Observer o in observers)
        {
            o.update(offers[offers.Count - 1]);
        }
    }

    public void addSpecialOffer(SpecialOffer offer)
    {
        offers.Add(offer);
        Console.WriteLine($"\n[{brandName}] New offer: {offer.getOfferName()} - {offer.getDiscount()}% off!");
        notifyObservers();
    }

    public string getBrandName() { return brandName; }
    public List<SpecialOffer> getOffers() { return offers; }
}
