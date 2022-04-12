using System;
using System.Collections.Generic;

[Serializable]
public class Dungeon
{
    public string name;
    public string difficulty;
    public Room[] rooms;

    public Dungeon(string name, string difficulty, Room[] rooms)
    {
        this.name = name;
        this.difficulty = difficulty;
        this.rooms = rooms;
    }

    public Dungeon(string name, DifficultyGrade difficulty, Room[] rooms) : this(name, difficulty.ToString(), rooms)
    {
    }

    public enum DifficultyGrade
    {
        S, A, B, C, D, F
    }
}
