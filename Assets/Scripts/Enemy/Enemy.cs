using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Enemy
{
    public string name;
    public string sprite;
    public float xp;
    public StatData stats;
    public bool isBoss = false;
    public Phase[] phases;
    private Vector3 origin;
    private Vector3 position;
    private Phase currentPhase;
    public float phaseTime;
    public List<StatusEffect> activeEffects = new List<StatusEffect>();
    public GameObject targetCharacter;

    public Enemy(string name, string sprite, StatData stats)
    {
        this.name = name;
        this.sprite = sprite;
        this.stats = stats;
    }

    public Enemy(string name, string sprite, StatData stats, bool isBoss) : this(name, sprite, stats)
    {
        this.isBoss = isBoss;
    }

    public void Start(Vector3 origin)
    {
        stats.health = stats.maxHealth;
        this.origin = origin;
        SetPosition(origin);
        targetCharacter = GameObject.FindGameObjectWithTag("Character");
        if (phases != null)
        {
            for (int i = 0; i < phases.Length; ++i)
            {
                if (phases[i].name != null)
                {
                    foreach (Phase phase in PhaseBuilder.phases)
                    {
                        if (phases[i].name.Equals(phase.name))
                        {
                            phases[i] = Phase.Override(phases[i], phase);
                        }
                    }
                }
                phases[i].Start(this, targetCharacter);
            }
            currentPhase = phases[0];
        }
    }

    public void UpdatePhase(ObjectPool pool)
    {
        if (targetCharacter.activeInHierarchy)
        {
            if (phaseTime >= currentPhase.delay + currentPhase.duration)
            {
                // transition to next phase
                currentPhase.Run(this);
                currentPhase = GetNextPhase(currentPhase);
                phaseTime = 0f;
                Debug.Log(currentPhase.name);
            }
            else if (phaseTime >= currentPhase.delay)
            {
                currentPhase.Update(this, targetCharacter, pool);
            }
            phaseTime += Time.deltaTime;
            currentPhase.IncrementAttackTime(Time.deltaTime);
        }
    }

    public Phase GetNextPhase(Phase phase)
    {
        Debug.Log(phase.transitions[0].nextPhases == null);
        string name = phase.transitions[0].nextPhases[UnityEngine.Random.Range(0, phase.transitions[0].nextPhases.Length)];
        foreach (Phase list in phases)
        {
            if (list.name.Equals(name)) return list;
        }
        return null;
    }

    public void AddStatusEffect(StatusEffect effect)
    {
        bool apply = true;
        foreach (StatusEffect active in activeEffects)
        {
            if (active.name.Equals(effect.name)) apply = false;
        }

        if (apply)
        {
            activeEffects.Add(effect);
            effect.Apply(this);
        }
    }

    public void Damage(float amount)
    {
        if (stats.health - amount < 0)
        {
            //character.UpdateLeveling(xp);
            Kill();
        }
        else stats.health -= amount;
    }

    private void Kill()
    {
        stats.health = 0;
    }

    public void SetPosition(Vector3 position)
    {
        this.position = position;
    }

    public Vector3 GetPosition()
    {
        return position;
    }

    public Vector3 GetOrigin()
    {
        return origin;
    }
}
