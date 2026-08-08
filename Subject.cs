// Observer Pattern - Subject Interface

interface Subject
{
	void registerObserver(Observer o);
	void removeObserver(Observer o);
	void notifyObservers();
}