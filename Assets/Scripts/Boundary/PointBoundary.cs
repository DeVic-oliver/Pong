using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointBoundary : MonoBehaviour, IScoreable
{
    public Player Player;
    public static bool IsPointMade;
    public void ApplyScore()
    {
        Player.Points++;
        IsPointMade = true;
    }
}
