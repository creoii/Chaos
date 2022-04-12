using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    private Dungeon dungeon;

    public List<Room> starts;
    public List<Room> standards;
    public List<Room> hallways;
    public List<Room> bosses;
    public List<Room> treasures;

    private void Start()
    {
        dungeon = DungeonBuilder.dungeons[0];

        starts = new List<Room>();
        standards = new List<Room>();
        hallways = new List<Room>();
        bosses = new List<Room>();
        treasures = new List<Room>();

        foreach (Room room in dungeon.rooms)
        {
            switch(room.type)
            {
                case "Start":
                    starts.Add(room);
                    break;
                case "Standard":
                    standards.Add(room);
                    break;
                case "Hallway":
                    hallways.Add(room);
                    break;
                case "Boss":
                    bosses.Add(room);
                    break;
                case "Treasure":
                    treasures.Add(room);
                    break;
            }
        }
    }

    public void Generate(Vector3 position)
    {
        starts[Random.Range(0, starts.Count)].Generate(position, WorldUtil.GetWorldTilemap());
    }
}
