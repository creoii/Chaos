using System;
using UnityEngine;

[Serializable]
public class WeaponItem : Item
{
    public Attack[] attacks;
    public SigilItem[] sigils;
    private float attackTime = 0f;

    public WeaponItem(string name, string description, string sprite, ItemType itemType, ItemRarity rarity, int maxSigils, Attack[] attacks) : base(name, description, sprite, itemType.ToString(), rarity.ToString(), maxSigils)
    {
        this.attacks = attacks;
        sigils = new SigilItem[maxSigils];
    }

    public void Start()
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
            attacks[i].Start();
        }
        sigils = new SigilItem[maxSigils];
    }

    public void Use(Character character)
    {
        foreach (Attack attack in attacks)
        {
            if (attackTime >= 1f / (.08666f * (character.stats.attackSpeed + 17.3f) * attack.rateOfFire))
            {
                attack.Shoot(character, character.pool);
                attackTime = 0f;
            }
        }
        

        for (int i = 0; i < sigils.Length; ++i)
        {
            if (sigils[i] != null) sigils[i].TryActivate(character, character.pool);
        }
    }

    public void IncrementAttackTime(float f)
    {
        for (int i = 0; i < sigils.Length; ++i)
        {
            if (sigils[i] != null) sigils[i].IncrementAttackTime(f);
        }
        attackTime += f;
    }
}
