
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public static bool gameOver = false;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "TrainHead")
        {
            Debug.Log("GameOver!");
            gameOver = true;
        }
    }
}
