using System;
using UnityEngine;

public class Enemy : Entity
{
    public BasicEnemy enemy;
    private Vector3 origin;
    private Phase currentPhase;
    public float phaseTime;
    public Character targetCharacter;

    private void Start()
    {
        enemy = EnemyBuilder.enemies[UnityEngine.Random.Range(0, EnemyBuilder.enemies.Count)];
        stats = enemy.stats;
        origin = transform.position;

        pool = GetComponentInChildren<ObjectPool>();
        SpriteUtil.SetSprite(GetComponent<SpriteRenderer>(), "Sprites/Characters/Enemies/" + enemy.sprite);

        stats.health = stats.maxHealth;
        targetCharacter = GameObject.FindGameObjectWithTag("Character").GetComponent<Character>();
        Phase[] phases = enemy.phases;
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
        else
        {
            phases = new Phase[1] { new Phase("default", 5, 0, new Attack[0], new Movement[0], new Transition[0]) };
        }
    }

    private void Update()
    {
        if (targetCharacter.alive)
        {
            if (phaseTime >= currentPhase.delay + currentPhase.duration)
            {
                // transition to next phase
                currentPhase.Run(this);
                currentPhase = GetNextPhase(currentPhase);
                phaseTime = 0f;
            }
            else if (phaseTime >= currentPhase.delay)
            {
                currentPhase.Update(this, targetCharacter, pool);
            }
            phaseTime += Time.deltaTime;
            currentPhase.IncrementAttackTime(Time.deltaTime);
        }
    }

    public override void OnHit(Projectile projectile, float damage, int armorIgnored)
    {
        base.OnHit(projectile, damage, armorIgnored);
        if (projectile.owner is Character character)
        {
            ++character.statistics.hits;
            character.statistics.UpdateAccuracy();
        }
    }

    public Phase GetNextPhase(Phase phase)
    {
        string name = phase.transitions[0].nextPhases[UnityEngine.Random.Range(0, phase.transitions[0].nextPhases.Length)];
        foreach (Phase list in enemy.phases)
        {
            if (list.name.Equals(name)) return list;
        }
        return null;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public Vector3 GetOrigin()
    {
        return origin;
    }
}
