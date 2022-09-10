using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BallHitter : MonoBehaviour
{
    public float MinHitPowerValue;
    public float MaxHitPowerValue;
    public string Axis = "x";
    /// <summary>
    /// Return a new Vector2 direction. Default Changes X axis value
    /// </summary>
    /// <param name="direction"></param>
    /// <param name="axis"></param>
    /// <returns></returns>
    public virtual Vector2 ChangeBallDirection(Vector2 direction)
    {
        float newPositionValue = Random.Range(MinHitPowerValue, MaxHitPowerValue);
        if (Axis == "y")
        {
            direction.y = VectorAxisValueChanger.ChangeVectorAxisValue(direction.y, newPositionValue);
            return direction;
        }
        direction.x = VectorAxisValueChanger.ChangeVectorAxisValue(direction.x, newPositionValue);
        return direction;
    }
}
