// Observer Pattern - Subject Interface
namespace SDP_ASG;

public interface Subject
{
	void registerObserver(Observer o);
	void removeObserver(Observer o);
	void notifyObservers();
}
