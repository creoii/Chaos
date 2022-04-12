using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;

public class RoomBuilder
{
    private readonly string DATA_PATH = "Assets/Data/Rooms/";

    public static List<Room> rooms = new List<Room>();

    public void ReadAndStoreData()
    {
        if (!Directory.Exists(DATA_PATH))
        {
            Directory.CreateDirectory(DATA_PATH);
            return;
        }

        foreach (string file in Directory.EnumerateFiles(DATA_PATH, "*.json", SearchOption.AllDirectories))
        {
            rooms.Add(JsonUtility.FromJson<Room>(new StreamReader(file).ReadToEnd()));
        }
    }
}
