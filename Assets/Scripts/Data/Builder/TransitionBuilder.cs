using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;

public class TransitionBuilder
{
    private readonly string DATA_PATH = "Assets/Data/Transitions";

    public static List<Transition> transitions = new List<Transition>();

    public void ReadAndStoreData()
    {
        if (!Directory.Exists(DATA_PATH))
        {
            Directory.CreateDirectory(DATA_PATH);
            return;
        }
        
        foreach (string file in Directory.EnumerateFiles(DATA_PATH, "*.json", SearchOption.AllDirectories))
        {
            transitions.Add(JsonUtility.FromJson<Transition>(new StreamReader(file).ReadToEnd()));
        }
    }
}
