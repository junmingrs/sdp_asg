// Decorator Pattern - WarrantyDecorator (ConcreteDecorator)
namespace SDP_ASG;

public class WarrantyDecorator : FurnitureDecorator
{
    private int warrantyYears;
    private double warrantyCost;

    public WarrantyDecorator(Furniture item, int warrantyYears) : base(item)
    {
        this.warrantyYears = warrantyYears;
        this.warrantyCost = warrantyYears * 50.00;
    }

    public override string getDescription()
    {
        return item.getDescription() + $", {warrantyYears}-year Warranty";
    }

    public override double getPrice()
    {
        return item.getPrice() + warrantyCost;
    }
}
