public interface IObserver
{
    void OnNotify(ICommand command);  // Komut geldi�inde tetiklenen metot
}
