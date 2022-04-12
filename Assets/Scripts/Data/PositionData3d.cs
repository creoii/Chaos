using System;
using UnityEngine;

[Serializable]
public class PositionData3d
{
    public float x;
    public float y;
    public float z;

    public PositionData3d(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public static PositionData3d Override(PositionData3d one, PositionData3d two)
    {
        return new PositionData3d(
            two.x == 0 ? one.x : two.x,
            two.y == 0 ? one.y : two.y,
            two.z == 0 ? one.z : two.z
        );
    }

    public Vector3 GetAsVector3()
    {
        return new Vector3(x, y, z);
    }
}
