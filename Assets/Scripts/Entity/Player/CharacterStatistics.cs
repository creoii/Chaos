public class CharacterStatistics
{
    public int shots;
    public int hits;
    public float accuracy;

    public void UpdateAccuracy()
    {
        accuracy = (float) hits / shots;
    }
}
