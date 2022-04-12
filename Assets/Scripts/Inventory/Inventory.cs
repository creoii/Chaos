using UnityEngine.UI;
using UnityEngine;

public class Inventory
{
    public Slot[] slots;

    public Inventory(int maxSlots)
    {
        slots = new Slot[maxSlots];
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = new Slot();
        }
    }
}
