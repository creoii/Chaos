using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;

public class PhaseBuilder
{
    private readonly string DATA_PATH = "Assets/Data/Phases";

    public static List<Phase> phases = new List<Phase>();

    public void ReadAndStoreData()
    {
        if (!Directory.Exists(DATA_PATH))
        {
            Directory.CreateDirectory(DATA_PATH);
            return;
        }
        
        foreach (string file in Directory.EnumerateFiles(DATA_PATH, "*.json", SearchOption.AllDirectories))
        {
            phases.Add(JsonUtility.FromJson<Phase>(new StreamReader(file).ReadToEnd()));
        }
    }
}
