using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class StatusEffect
{
    public string name;
    public float duration;
    public bool instant = false;
    public bool positive;
    public StatData statChange;

    public StatusEffect(string name, float duration, bool instant, bool positive, StatData statChange)
    {
        this.name = name;
        this.duration = duration;
        this.instant = instant;
        this.positive = positive;
        this.statChange = statChange;
    }

    public StatusEffect WithDuration(float duration)
    {
        this.duration = duration;
        return this;
    }
    public static StatusEffect Override(StatusEffect one, StatusEffect two)
    {
        return new StatusEffect(
            two.name == null ? one.name : two.name,
            two.duration == 0 ? one.duration : two.duration,
            two.instant,
            two.positive,
            two.statChange == null ? one.statChange : StatData.Override(one.statChange, two.statChange)
        );
    }

    public IEnumerator Apply(Character character)
    {
        character.stats.Add(statChange);
        yield return new WaitForSeconds(duration);
        character.activeEffects.Remove(this);
        if (!instant) character.stats.Subtract(statChange);
    }

    public IEnumerator Apply(Enemy enemy)
    {
        enemy.stats.Add(statChange);
        yield return new WaitForSeconds(duration);
        enemy.activeEffects.Remove(this);
        if (!instant) enemy.stats.Subtract(statChange);
    }
}
