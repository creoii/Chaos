using UnityEngine;

public class MathUtil
{
    public const float Deg2Rad = .01745329f;

    public static float ToAngle(Vector3 vec)
    {
        return Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
    }

    public static Vector3 GetDirection(Vector3 reference, float angle)
    {
        return new Vector3(reference.x + Mathf.Cos(angle * MathUtil.Deg2Rad), reference.y + Mathf.Sin(angle * MathUtil.Deg2Rad)).normalized;
    }
}
