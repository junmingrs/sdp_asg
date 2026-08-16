// Decorator Pattern - WarrantyDecorator (ConcreteDecorator)
using System.Collections;

namespace SDP_ASG;

public class WarrantyDecorator : FurnitureDecorator
{
    private OrderItem orderItem;
    private double warrantyCost;
    private int warrantyYears;
    public WarrantyDecorator(OrderItem orderItem, int warrantyYears)
    {
        this.orderItem = orderItem;
        this.warrantyYears = warrantyYears;
        this.warrantyCost = warrantyYears * 50.00;

    }

    public override string getDescription()
    {
        return orderItem.getDescription() + $", {warrantyYears}-year Warranty";
    }
    public override double getPrice()
    {
        return orderItem.getPrice() + warrantyCost;
    }
}

