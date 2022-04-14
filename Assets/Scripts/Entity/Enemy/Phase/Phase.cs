using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class Phase
{
    public string name;
    public float duration;
    public float delay = 0f;
    public Attack[] attacks;
    public Movement[] movements;
    public Transition[] transitions;
    
    private float attackTime = 0f;

    public Phase(string name, float duration, float delay, Attack[] attacks, Movement[] movements, Transition[] transitions)
    {
        this.name = name;
        this.duration = duration;
        this.delay = delay;
        this.attacks = attacks;
        this.movements = movements;
        this.transitions = transitions;
    }

    public void Start(Enemy enemy, GameObject character)
    {
        if (attacks != null)
        {
            for (int i = 0; i < attacks.Length; ++i)
            {
                if (attacks[i].name != null)
                {
                    foreach (Attack attack in AttackBuilder.attacks)
                    {
                        if (attacks[i].name == attack.name) attacks[i] = Attack.Override(attack, attacks[i]);
                    }
                }
                // imagine an enemy that shoots from the mouse. HA. Ha. ha.. ?
                attacks[i].onMouse = false;
            }
        }

        if (movements != null)
        {
            for (int i = 0; i < movements.Length; ++i)
            {
                if (movements[i].name != null)
                {
                    foreach (Movement movement in MovementBuilder.movements)
                    {
                        if (movements[i].name == movement.name) movements[i] = Movement.Override(movement, movements[i]);
                    }
                }
            }

            foreach (Movement movement in movements)
            {
                movement.Start(enemy, character);
            }
        }

        if (transitions != null)
        {
            for (int i = 0; i < transitions.Length; ++i)
            {
                if (transitions[i].name != null)
                {
                    foreach (Transition transition in TransitionBuilder.transitions)
                    {
                        if (transitions[i].name == transition.name) transitions[i] = Transition.Override(transition, transitions[i]);
                    }
                }
            }
        }
    }

    public static Phase Override(Phase one, Phase two)
    {
        return new Phase(
            two.name == null ? one.name : two.name,
            two.duration == 0f ? one.duration : two.duration,
            two.delay == 0f ? one.delay : two.delay,
            two.attacks == null ? one.attacks : two.attacks,
            two.movements == null ? one.movements : two.movements,
            two.transitions == null ? one.transitions : two.transitions
        );
    }

    public void Update(Enemy enemy, GameObject character, ObjectPool pool)
    {
        if (attacks != null)
        {
            if (attackTime >= 20f / enemy.stats.attackSpeed)
            {
                foreach (Attack attack in attacks)
                {
                    attack.Shoot(enemy, character, pool);
                }
                attackTime = 0f;
            }
        }
        if (movements != null)
        {
            foreach (Movement movement in movements)
            {
                movement.Run(enemy, character);
            }
        }
    }

    public IEnumerator Run(Enemy enemy)
    {
        yield return new WaitForSeconds(duration);
        enemy.phaseTime = 0f;
    }

    public void IncrementAttackTime(float f)
    {
        attackTime += f;
    }
}
