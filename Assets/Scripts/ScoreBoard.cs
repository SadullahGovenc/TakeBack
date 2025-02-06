using UnityEngine;

public class ScoreBoard : MonoBehaviour, IObserver
{
    private int score = 0;

    public void OnNotify(ICommand command)
    {
        // Her komut çalýþtýrýldýðýnda skoru arttýrýyoruz
        score++;
        Debug.Log("Score: " + score);
    }
}
