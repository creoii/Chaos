using System;
using UnityEngine;

[Serializable]
public class AbilityItem : Item
{
    public float manaCost;
    public float cooldown;
    public Attack[] attacks;
    public StatusEffect[] statusEffects;

    private float attackTime = 0f;

    public AbilityItem(string name, string description, string sprite, ItemType itemType, ItemRarity rarity, int maxSigils, float manaCost, float cooldown, Attack[] attacks, StatusEffect[] statusEffects) : base(name, description, sprite, itemType.ToString(), rarity.ToString(), maxSigils)
    {
        this.manaCost = manaCost;
        this.cooldown = cooldown;
        this.attacks = attacks;
        this.statusEffects = statusEffects;
    }

    public void Activate(Character character)
    {
        if (character.stats.mana >= manaCost)
        {
            if (attackTime >= cooldown)
            {
                character.DamageMana(manaCost);
                foreach (Attack attack in attacks)
                {
                    attack.Shoot(character, character.pool);
                }
                attackTime = 0f;

                if (statusEffects != null)
                {
                    foreach (StatusEffect effect in statusEffects)
                    {
                        character.AddStatusEffect(effect);
                    }
                }
            }
        }
    }

    public void Start()
    {
        if (statusEffects != null)
        {
            for (int i = 0; i < statusEffects.Length; ++i)
            {
                if (statusEffects[i].name != null)
                {
                    foreach (StatusEffect effect in StatusEffectBuilder.statusEffects)
                    {
                        if (statusEffects[i].name.Equals(effect.name))
                        {
                            statusEffects[i] = StatusEffect.Override(statusEffects[i], effect);
                        }
                    }
                }
            }
        }
    }

    public void IncrementAttackTime(float f)
    {
        attackTime += f;
    }
}
