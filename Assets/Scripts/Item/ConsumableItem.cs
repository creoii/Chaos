using System;

[Serializable]
public class ConsumableItem : Item
{
    public ConsumableItem(string name, string description, string sprite, ItemType itemType, ItemRarity rarity) : base(name, description, sprite, itemType.ToString(), rarity.ToString(), 0)
    {

    }
}
