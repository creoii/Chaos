using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    private Dungeon dungeon;

    public Room[] starts;
    public Room[] standards;
    public Room[] hallways;
    public Room[] bosses;
    public Room[] treasures;

    private void Start()
    {
        dungeon = DungeonBuilder.dungeons[0];

        foreach (Room room in dungeon.rooms)
        {
            switch(room.type)
            {
                case "Start":
                    starts = CollectionUtil.ArrayAdd(starts, room);
                    break;
                case "Standard":
                    standards = CollectionUtil.ArrayAdd(standards, room);
                    break;
                case "Hallway":
                    hallways = CollectionUtil.ArrayAdd(hallways, room);
                    break;
                case "Boss":
                    bosses = CollectionUtil.ArrayAdd(bosses, room);
                    break;
                case "Treasure":
                    treasures = CollectionUtil.ArrayAdd(treasures, room);
                    break;
            }
        }
    }

    public void Generate(Vector3 position)
    {
        starts[Random.Range(0, starts.Length)].Generate(position, WorldUtil.GetWorldTilemap());
    }
}
