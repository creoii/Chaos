using System.Collections.Generic;
using System;

public class CollectionUtil
{
    public static T[] ArrayAdd<T>(T[] arr, T obj)
    {
        T[] ret = new T[arr.Length + 1];
        for (int i = 0; i < arr.Length; i++)
            ret[i] = arr[i];
        ret[arr.Length] = obj;
        return ret;
    }
}
