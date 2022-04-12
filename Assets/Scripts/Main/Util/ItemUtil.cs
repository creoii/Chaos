public class ItemUtil
{
    public static Item.EquipType GetEquipType(ItemType type)
    {
        switch (type)
        {
            case ItemType.Sword:
            case ItemType.Staff:
            case ItemType.Wand:
                return Item.EquipType.Weapon;
            case ItemType.Helm:
            case ItemType.Shield:
            case ItemType.Spear:
            case ItemType.Spell:
            case ItemType.Skull:
            case ItemType.Orb:
            case ItemType.Book:
            case ItemType.Scepter:
            case ItemType.Totem:
                return Item.EquipType.Ability;
            case ItemType.Armor:
                return Item.EquipType.Armor;
            case ItemType.Accessory:
                return Item.EquipType.Accessory;
            default:
                return Item.EquipType.Miscellaneous;
        }
    }
}
