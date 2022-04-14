using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;

public class EnemyBuilder
{
    private readonly string DATA_PATH = "Assets/Data/Enemies/";

    public static List<BasicEnemy> enemies = new List<BasicEnemy>();
    public static List<BossEnemy> bosses = new List<BossEnemy>();

    public void ReadAndStoreData()
    {
        if (!Directory.Exists(DATA_PATH))
        {
            Directory.CreateDirectory(DATA_PATH);
            return;
        }
        
        foreach (string file in Directory.EnumerateFiles(DATA_PATH, "*.json", SearchOption.AllDirectories))
        {
            BasicEnemy enemy = JsonUtility.FromJson<BasicEnemy>(new StreamReader(file).ReadToEnd());
            if (enemy.isBoss) bosses.Add(JsonUtility.FromJson<BossEnemy>(new StreamReader(file).ReadToEnd()));
            else enemies.Add(enemy);
        }
    }
}
