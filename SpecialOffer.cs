// SpecialOffer - represents a special offer from a brand
namespace SDP_ASG;

public class SpecialOffer
{
    private string offerName;
    private double discount;
    private Brand brand;

    public SpecialOffer(string offerName, double discount, Brand brand)
    {
        this.offerName = offerName;
        this.discount = discount;
        this.brand = brand;
    }

    public string getOfferName() { return offerName; }
    public double getDiscount() { return discount; }
    public Brand getBrand() { return brand; }
}
