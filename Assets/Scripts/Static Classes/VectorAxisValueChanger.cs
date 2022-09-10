using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorAxisValueChanger
{
    public static float ChangeVectorAxisValue(float axisValue, float axisNewValue)
    {
        if (axisValue < 0)
        {
            axisValue = axisNewValue;
            return axisValue;
        }
        axisValue = -axisNewValue;
        return axisValue;
    }
}
