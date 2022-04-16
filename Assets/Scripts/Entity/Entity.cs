using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Entity : MonoBehaviour
{
    public ObjectPool pool;
    public StatData stats;
    public List<StatusEffect> activeEffects = new List<StatusEffect>();
    public bool alive = true;

    public virtual void OnHit(Projectile projectile, float damage, int armorIgnored)
    {
        Damage(damage, armorIgnored);
        if (projectile.attack.statusEffects != null)
        {
            foreach (StatusEffect effect in projectile.attack.statusEffects)
            {
                AddStatusEffect(effect);
            }
        }
    }

    public void AddStatusEffect(StatusEffect effect)
    {
        // 0 means don't apply, 1 means add to, 2 means replace
        int apply = 0;
        foreach (StatusEffect active in activeEffects)
        {
            if (active.name.Equals(effect.name)) apply = 1;
        }

        if (apply == 0 && isActiveAndEnabled)
        {
            activeEffects.Add(effect);
            StartCoroutine(effect.Apply(this));
        }
    }

    public virtual void Heal(float amount)
    {
        if (stats.health + amount > stats.maxHealth)
        {
            stats.health = stats.maxHealth;
        }
        else stats.health += amount;
    }

    public virtual void HealMana(float amount)
    {
        if (stats.mana + amount > stats.maxMana)
        {
            stats.mana = stats.maxMana;
        }
        else stats.mana += amount;
    }

    public virtual void Damage(float amount, int armorIgnored)
    {
        if (armorIgnored > 0)
        {
            if (armorIgnored >= stats.armor) amount += stats.armor;
            else amount += armorIgnored;
        }

        if (stats.health - amount < 0)
        {
            Kill();
        }
        else stats.health -= amount;
    }

    public virtual void DamageMana(float amount)
    {
        if (stats.mana - amount < 0)
        {
            stats.mana = 0;
        }
        else stats.mana -= amount;
    }

    void Kill()
    {
        stats.health = 0;
        alive = false;
        gameObject.SetActive(false);
    }
}
