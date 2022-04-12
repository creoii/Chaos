using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;

public class TileProviderBuilder
{
    private readonly string DATA_PATH = "Assets/Data/Tile Providers/";

    public static List<TileProvider> tileProviders = new List<TileProvider>();

    public void ReadAndStoreData()
    {
        if (!Directory.Exists(DATA_PATH))
        {
            Directory.CreateDirectory(DATA_PATH);
            return;
        }

        foreach (string file in Directory.EnumerateFiles(DATA_PATH, "*.json", SearchOption.AllDirectories))
        {
            tileProviders.Add(JsonUtility.FromJson<TileProvider>(new StreamReader(file).ReadToEnd()));
        }
    }
}
