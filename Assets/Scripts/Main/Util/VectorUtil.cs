using UnityEngine;

public class VectorUtil
{
    public static Vector3 GetRandomPosition(Vector3 min, Vector3 max)
    {
        return new Vector3(Random.Range(min.x, max.x), Random.Range(min.y, max.y));
    }

    public static Vector3 Scale(Vector3 scalee, Vector3 scalar)
    {
        scalee.x *= scalar.x;
        scalee.y *= scalar.y;
        scalee.z *= scalar.z;
        return scalee;
    }
}
