using UnityEngine.UI;
using UnityEngine;

public class Slot
{
    public ItemType slotType = ItemType.All;
    public bool empty = true;
    public Item item;
    public RectTransform transform;
    public Image image;

    public Slot(ItemType slotType)
    {
        this.slotType = slotType;
    }

    public Slot()
    {
        slotType = ItemType.All;
    }

    public bool CanSetItem(Item item)
    {
        if (slotType != ItemType.All) return item.itemType == slotType.ToString();
        else return true;
    }

    public void SetItem(Item item)
    {
        if (CanSetItem(item))
        {
            this.item = item;
            this.item.SetPosition(transform.position);
            empty = false;
        }
    }

    public void RemoveItem()
    {
        item = null;
        empty = true;
    }
}
