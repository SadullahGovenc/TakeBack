using UnityEngine;

public class ScoreBoard : MonoBehaviour, IObserver
{
    private int score = 0;

    public void OnNotify(ICommand command)
    {
        // Her komut �al��t�r�ld���nda skoru artt�r�yoruz
        score++;
        Debug.Log("Score: " + score);
    }
}
