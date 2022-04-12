using System;
using UnityEngine;

[Serializable]
public class SigilItem : Item
{
    public float cooldown;
    public Attack[] attacks;

    private float attackTime = 0f;

    public SigilItem(string name, string description, string sprite, ItemType itemType, ItemRarity rarity) : base(name, description, sprite, itemType.ToString(), rarity.ToString(), 0)
    {

    }

    public void TryActivate(Character character, ObjectPool pool)
    {
        if (attackTime >= cooldown)
        {
            foreach (Attack attack in attacks)
            {
                attack.Shoot(character, pool);
            }
            attackTime = 0f;
        }
    }

    public void IncrementAttackTime(float f)
    {
        attackTime += f;
    }
}
