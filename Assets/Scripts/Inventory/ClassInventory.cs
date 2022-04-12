using UnityEngine.UI;
using UnityEngine;

public class ClassInventory : Inventory
{
    public ItemType[] classItemTypes;

    public ClassInventory(ItemType[] classItemTypes) : base(4)
    {
        this.classItemTypes = classItemTypes;
        for (int i = 0; i < 4; i++)
        {
            slots[i].slotType = classItemTypes[i];
        }
    }

    public ClassInventory(ItemType weapon, ItemType ability, ItemType armor) : this(new ItemType[4] {weapon, ability, armor, ItemType.Accessory})
    {

    }
}
