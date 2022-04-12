public class LevelData
{
    public float level = 1;
    public float xp = 0;

    public static float XpRequired(float level)
    {
        return level * level;
    }
}
