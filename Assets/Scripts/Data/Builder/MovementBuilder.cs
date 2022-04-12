using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;

public class MovementBuilder
{
    private readonly string DATA_PATH = "Assets/Data/Movements";

    public static List<Movement> movements = new List<Movement>();

    public void ReadAndStoreData()
    {
        if (!Directory.Exists(DATA_PATH))
        {
            Directory.CreateDirectory(DATA_PATH);
            return;
        }
        
        foreach (string file in Directory.EnumerateFiles(DATA_PATH, "*.json", SearchOption.AllDirectories))
        {
            movements.Add(JsonUtility.FromJson<Movement>(new StreamReader(file).ReadToEnd()));
        }
    }
}
