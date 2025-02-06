public interface INotifier
{
    void AddObserver(IObserver observer);  // Observer ekle
    void RemoveObserver(IObserver observer);  // Observer sil
    void Notify(ICommand command);  // Observer'larý bilgilendir
}

