// Decorator Pattern - InstallationDecorator (ConcreteDecorator)
namespace SDP_ASG;

public class InstallationDecorator : FurnitureDecorator
{
	private OrderItem orderItem;
	private double installationFee;
	private string scheduledDate;

	public InstallationDecorator(OrderItem item, string scheduledDate)
	{
		this.orderItem = item;
		this.installationFee = 80.00;
		this.scheduledDate = scheduledDate;
	}

	public override string getDescription()
	{
		return orderItem.getDescription() + $", Installation on {scheduledDate}";
	}

	public override double getPrice()
	{
		return orderItem.getPrice() + installationFee;
	}
}
