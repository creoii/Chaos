using System;
using UnityEngine.Tilemaps;
using UnityEngine;

public class WorldUtil
{
    public static Tilemap GetWorldTilemap()
    {
        return Camera.main.GetComponentInChildren<Tilemap>();
    }
}
