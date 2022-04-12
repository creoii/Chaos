using System;

[Serializable]
public class TokenItem : Item
{
    public TokenItem(string name, string description, string sprite, ItemType itemType, ItemRarity rarity) : base(name, description, sprite, itemType.ToString(), rarity.ToString(), 0)
    {

    }
}
