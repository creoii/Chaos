using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;

public class DungeonBuilder
{
    private readonly string DATA_PATH = "Assets/Data/Dungeons/";

    public static List<Dungeon> dungeons = new List<Dungeon>();

    public void ReadAndStoreData()
    {
        if (!Directory.Exists(DATA_PATH))
        {
            Directory.CreateDirectory(DATA_PATH);
            return;
        }

        foreach (string file in Directory.EnumerateFiles(DATA_PATH, "*.json", SearchOption.AllDirectories))
        {
            dungeons.Add(JsonUtility.FromJson<Dungeon>(new StreamReader(file).ReadToEnd()));
        }
    }
}
