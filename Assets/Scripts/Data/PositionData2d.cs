using System;
using UnityEngine;

[Serializable]
public class PositionData2d
{
    public float x;
    public float y;

    public PositionData2d(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    public static PositionData2d Override(PositionData2d one, PositionData2d two)
    {
        return new PositionData2d(
            two.x == 0 ? one.x : two.x,
            two.y == 0 ? one.y : two.y
        );
    }

    public Vector2 GetAsVector2()
    {
        return new Vector2(x, y);
    }

    public Vector3 GetAsVector3()
    {
        return new Vector3(x, y, 0);
    }
}
