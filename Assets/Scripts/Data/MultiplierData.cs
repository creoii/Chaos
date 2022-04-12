using System;

[Serializable]
public class MultiplierData
{
    public float rate;
    public float multiplier = 1f;
    public float min;
    public float max;
    public float offset = 0f;

    public MultiplierData(float rate, float multiplier, float min, float max, float offset)
    {
        this.rate = rate;
        this.multiplier = multiplier;
        this.min = min;
        this.max = max;
        this.offset = offset;
    }

    public static MultiplierData Override(MultiplierData one, MultiplierData two)
    {
        return new MultiplierData(
            two.rate == 0 ? one.rate : two.rate,
            two.multiplier == 0 ? one.multiplier : two.multiplier,
            two.min == 0 ? one.min : two.min,
            two.max == 0 ? one.max : two.max,
            two.offset == 0 ? one.offset : two.offset
        );
    }
}