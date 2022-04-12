using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[Serializable]
public class Room
{
    public string name;
    public string type;
    public int width;
    public int height;
    public int connections;

    public TileProvider floorTile;

    public Room(string name, string type, int width, int height, int connections, TileProvider floorTile)
    {
        this.name = name;
        this.type = type;
        this.width = width;
        this.height = height;
        this.connections = connections;
        this.floorTile = floorTile;
    }

    public Room(string name, RoomType type, int width, int height, int connections, TileProvider floorTile) : this(name, type.ToString(), width, height, connections, floorTile)
    {
    }

    public void Generate(Vector3 position, Tilemap map)
    {
        Tile tile = ScriptableObject.CreateInstance<Tile>();
        tile.sprite = SpriteUtil.GetSprite("Assets/Resources/Tiles/" + floorTile.GetTile());

        for (int x = 0; x < width; ++x)
        {
            for (int y = 0; y < height; ++y)
            {
                map.SetTile(new Vector3Int(x, y, 0), tile);
            }
        }
    }

    public enum RoomType
    {
        Start,
        Standard,
        Hallway,
        Boss,
        Treasure
    }
}
