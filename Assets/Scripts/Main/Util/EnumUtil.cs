using System;
using UnityEngine;

public class EnumUtil
{
    public static T Parse<T>(string value)
    {
        return (T)Enum.Parse(typeof(T), value);
    }
}