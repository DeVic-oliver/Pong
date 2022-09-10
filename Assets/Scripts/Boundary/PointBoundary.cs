using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointBoundary : MonoBehaviour, IScoreable
{
    public Player Player;
    public static bool IsPointMade;
    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.gameObject.CompareTag("Ball"))
    //    {
    //        Player.Points++;
    //        IsPointMade = true;
    //    }
    //}

    public void ApplyScore()
    {
        Player.Points++;
        IsPointMade = true;
    }
}
