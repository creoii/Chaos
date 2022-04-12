using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;

public class StatusEffectBuilder
{
    private readonly string DATA_PATH = "Assets/Data/StatusEffects/";

    public static List<StatusEffect> statusEffects = new List<StatusEffect>();

    public void ReadAndStoreData()
    {
        if (!Directory.Exists(DATA_PATH))
        {
            Directory.CreateDirectory(DATA_PATH);
            return;
        }
        
        foreach (string file in Directory.EnumerateFiles(DATA_PATH, "*.json", SearchOption.AllDirectories))
        {
            statusEffects.Add(JsonUtility.FromJson<StatusEffect>(new StreamReader(file).ReadToEnd()));
        }
    }
}
