using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;

public class ItemBuilder
{
    private readonly string DATA_PATH = "Assets/Data/Items/";

    public static List<WeaponItem> weapons = new List<WeaponItem>();
    public static List<AbilityItem> abilities = new List<AbilityItem>();
    public static List<ArmorItem> armors = new List<ArmorItem>();
    public static List<AccessoryItem> accessories = new List<AccessoryItem>();
    public static List<ConsumableItem> consumables = new List<ConsumableItem>();
    public static List<SigilItem> sigils = new List<SigilItem>();
    public static List<TokenItem> tokens = new List<TokenItem>();

    public void ReadAndStoreData()
    {
        if (!Directory.Exists(DATA_PATH))
        {
            Directory.CreateDirectory(DATA_PATH);
            return;
        }

        foreach (string file in Directory.EnumerateFiles(DATA_PATH, "*.json", SearchOption.AllDirectories))
        {
            ItemType type = EnumUtil.Parse<ItemType>(JsonUtility.FromJson<Item>(new StreamReader(file).ReadToEnd()).itemType);
            switch (ItemUtil.GetEquipType(type))
            {
                case Item.EquipType.Weapon:
                    weapons.Add(JsonUtility.FromJson<WeaponItem>(new StreamReader(file).ReadToEnd()));
                    break;
                case Item.EquipType.Ability:
                    abilities.Add(JsonUtility.FromJson<AbilityItem>(new StreamReader(file).ReadToEnd()));
                    break;
                case Item.EquipType.Armor:
                    armors.Add(JsonUtility.FromJson<ArmorItem>(new StreamReader(file).ReadToEnd()));
                    break;
                case Item.EquipType.Accessory:
                    accessories.Add(JsonUtility.FromJson<AccessoryItem>(new StreamReader(file).ReadToEnd()));
                    break;
                case Item.EquipType.Miscellaneous:
                    if (type == ItemType.Consumable) consumables.Add(JsonUtility.FromJson<ConsumableItem>(new StreamReader(file).ReadToEnd()));
                    else if (type == ItemType.Sigil) sigils.Add(JsonUtility.FromJson<SigilItem>(new StreamReader(file).ReadToEnd()));
                    else if (type == ItemType.Token) tokens.Add(JsonUtility.FromJson<TokenItem>(new StreamReader(file).ReadToEnd()));
                    break;
                default:
                    break;
            }
        }
    }
}
