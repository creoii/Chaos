using System;

[Serializable]
public class BossEnemy : Enemy
{
    public BossEnemy(string name, string sprite, StatData stats) : base(name, sprite, stats, true)
    {

    }
}
