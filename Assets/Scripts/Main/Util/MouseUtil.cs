using UnityEngine;

public class MouseUtil
{
    private static Vector3 mouseWorldPosition;

    public static Vector3 GetMouseWorldPos()
    {
        mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        //Debug.Log(mouseWorldPosition);
        return new Vector3(mouseWorldPosition.x, mouseWorldPosition.y, 0f);
    }

    public static float GetMouseAngle(Vector3 reference)
    {
        return MathUtil.ToAngle(GetMouseWorldPos() - reference);
    }
}