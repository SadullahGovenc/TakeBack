using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MoveCommand", menuName = "Commands/MoveCommand")]
public class MoveCommandSO : ScriptableObject, ICommand
{
    public Vector3 direction; // Hareket yönü
    private Transform player;

    public void SetPlayer(Transform player)
    {
        this.player = player;
    }

    public void Execute()
    {
        if (player != null)
        {
            player.position += direction;
        }
    }

    public void Undo()
    {
        if (player != null)
        {
            player.position -= direction;
        }
    }
}

