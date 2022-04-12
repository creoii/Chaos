public enum ItemType
{
    [Item.ItemTypeAttribute(Item.EquipType.Weapon)] Sword,
    [Item.ItemTypeAttribute(Item.EquipType.Weapon)] Staff,
    [Item.ItemTypeAttribute(Item.EquipType.Weapon)] Wand,
    [Item.ItemTypeAttribute(Item.EquipType.Ability)] Helm,
    [Item.ItemTypeAttribute(Item.EquipType.Ability)] Shield,
    [Item.ItemTypeAttribute(Item.EquipType.Ability)] Spear,
    [Item.ItemTypeAttribute(Item.EquipType.Ability)] Book,
    [Item.ItemTypeAttribute(Item.EquipType.Ability)] Skull,
    [Item.ItemTypeAttribute(Item.EquipType.Ability)] Orb,
    [Item.ItemTypeAttribute(Item.EquipType.Ability)] Spell,
    [Item.ItemTypeAttribute(Item.EquipType.Ability)] Scepter,
    [Item.ItemTypeAttribute(Item.EquipType.Ability)] Totem,
    [Item.ItemTypeAttribute(Item.EquipType.Armor)] Armor,
    [Item.ItemTypeAttribute(Item.EquipType.Accessory)] Accessory,
    Consumable,
    Sigil,
    Token,
    All
}
