using System;

[Serializable]
public class AccessoryItem : Item
{
    public AccessoryItem(string name, string description, string sprite, ItemType itemType, ItemRarity rarity, int maxSigils) : base(name, description, sprite, itemType.ToString(), rarity.ToString(), maxSigils)
    {

    }
}
