using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TileProvider
{
    public string name;
    public StringWithChance[] tiles;

    public TileProvider(string name, StringWithChance[] tiles)
    {
        this.name = name;
        this.tiles = tiles;
    }

    public string GetTile()
    {
        return tiles[0].name;
    }
    
    [Serializable]
    public class StringWithChance
    {
        public string name;
        public float chance;

        public StringWithChance(string name, float chance)
        {
            this.name = name;
            this.chance = chance;
        }
    }
}
