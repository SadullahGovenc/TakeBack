using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, INotifier
{
    public MoveCommandSO moveUpCommand;
    public MoveCommandSO moveDownCommand;
    public MoveCommandSO moveLeftCommand;
    public MoveCommandSO moveRightCommand;

    private List<ICommand> commandHistory = new List<ICommand>(); // Komut geçmiþi
    private List<ICommand> undoHistory = new List<ICommand>();   // Geri alma geçmiþi

    private List<IObserver> observers = new List<IObserver>();

    public float moveDistance = 1f;

    void Start()
    {
        moveUpCommand.SetPlayer(transform);
        moveDownCommand.SetPlayer(transform);
        moveLeftCommand.SetPlayer(transform);
        moveRightCommand.SetPlayer(transform);

        ScoreBoard scoreBoard = FindObjectOfType<ScoreBoard>();
        if (scoreBoard != null)
        {
            AddObserver(scoreBoard);  // Observer ekle
        }
    }

    void Update()
    {
        // Hareket komutlarý
        if (Input.GetKeyDown(KeyCode.W)) ExecuteCommand(moveUpCommand);
        if (Input.GetKeyDown(KeyCode.S)) ExecuteCommand(moveDownCommand);
        if (Input.GetKeyDown(KeyCode.A)) ExecuteCommand(moveLeftCommand);
        if (Input.GetKeyDown(KeyCode.D)) ExecuteCommand(moveRightCommand);

        // Undo (geri oynatma) komutu
        if (Input.GetKeyDown(KeyCode.R)) UndoLastCommand();
    }

    void ExecuteCommand(MoveCommandSO command)
    {
        command.Execute();
        commandHistory.Add(command); // Komut kaydýný ekle
        Notify(command); // Komut çalýþtýðýnda observer'lara bildirim gönder
    }

    // Geri alma komutunu çalýþtýrma
    void UndoLastCommand()
    {
        if (commandHistory.Count > 0)
        {
            ICommand lastCommand = commandHistory[commandHistory.Count - 1];
            lastCommand.Undo();
            undoHistory.Add(lastCommand); // Geri alýnan komutu undoHistory'ye ekle
            commandHistory.RemoveAt(commandHistory.Count - 1); // Son komutu komut geçmiþinden çýkar
        }
    }

    // INotifier interface'ini implement ettik
    public void AddObserver(IObserver observer)
    {
        if (!observers.Contains(observer))
        {
            observers.Add(observer);
        }
    }

    public void RemoveObserver(IObserver observer)
    {
        if (observers.Contains(observer))
        {
            observers.Remove(observer);
        }
    }

    public void Notify(ICommand command)
    {
        foreach (var observer in observers)
        {
            observer.OnNotify(command);  // Observer'a bildirim gönder
        }
    }
}

