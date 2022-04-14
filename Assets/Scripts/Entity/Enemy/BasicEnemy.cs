using System;

[Serializable]
public class BasicEnemy
{
    public string name;
    public string sprite;
    public bool isBoss = false;
    public Phase[] phases = null;
    public StatData stats;
    public float xp;
}
