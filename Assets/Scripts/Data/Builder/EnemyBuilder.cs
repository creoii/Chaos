using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;

public class EnemyBuilder
{
    private readonly string DATA_PATH = "Assets/Data/Enemies/";

    public static List<Enemy> enemies = new List<Enemy>();
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
            Enemy enemy = JsonUtility.FromJson<Enemy>(new StreamReader(file).ReadToEnd());
            if (enemy.isBoss) bosses.Add(JsonUtility.FromJson<BossEnemy>(new StreamReader(file).ReadToEnd()));
            else enemies.Add(enemy);
        }
    }
}
