// Decorator Pattern - InstallationDecorator (ConcreteDecorator)


public class InstallationDecorator : FurnitureDecorator
{
	private double installationFee;
	private string scheduledDate;

	public InstallationDecorator(Furniture item, string scheduledDate) : base(item)
	{
		this.installationFee = 80.00;
		this.scheduledDate = scheduledDate;
	}

	public override string getDescription()
	{
		return item.getDescription() + $", Installation on {scheduledDate}";
	}

	public override double getPrice()
	{
		return item.getPrice() + installationFee;
	}
}