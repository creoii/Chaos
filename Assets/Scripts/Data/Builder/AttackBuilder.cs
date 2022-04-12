using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;

public class AttackBuilder
{
    private readonly string DATA_PATH = "Assets/Data/Attacks";

    public static List<Attack> attacks = new List<Attack>();

    public void ReadAndStoreData()
    {
        if (!Directory.Exists(DATA_PATH))
        {
            Directory.CreateDirectory(DATA_PATH);
            return;
        }

        foreach (string file in Directory.EnumerateFiles(DATA_PATH, "*.json", SearchOption.AllDirectories))
        {
            attacks.Add(JsonUtility.FromJson<Attack>(new StreamReader(file).ReadToEnd()));
        }
    }
}
