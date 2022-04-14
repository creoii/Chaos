public class Classes
{
    public static readonly PlayerClass Warrior = new PlayerClass("warrior", new ClassInventory(ItemType.Sword, ItemType.Helm, ItemType.Armor), new StatData(150f, 100f, 8f, 10f, 5f, 5f, 4f, 5f), new StatData(750f, 250f, 70f, 60f, 60f, 60f, 35f, 70f), new StatData(10f, 10f, 1f, 1f, 1f, 1f, 0f, 1f), new StatData(10f, 10f, 2f, 2f, 2f, 2f, 0f, 2f));
    public static readonly PlayerClass Wizard = new PlayerClass("wizard", new ClassInventory(ItemType.Staff, ItemType.Spell, ItemType.Armor), new StatData(100f, 120f, 12f, 8f, 5f, 5f, 2f, 5f), new StatData(650f, 500f, 60f, 65f, 60f, 60f, 25f, 80f), new StatData(10f, 10f, 1f, 1f, 1f, 1f, 0f, 1f), new StatData(10f, 10f, 2f, 2f, 2f, 2f, 0f, 2f));
    public static readonly PlayerClass Priest = new PlayerClass("priest", new ClassInventory(ItemType.Wand, ItemType.Book, ItemType.Armor), new StatData(100f, 120f, 10f, 12f, 5f, 5f, 0f, 5f), new StatData(700f, 600f, 60f, 70f, 60f, 60f, 25f, 60f), new StatData(10f, 10f, 1f, 1f, 1f, 1f, 0f, 1f), new StatData(10f, 10f, 2f, 2f, 2f, 2f, 0f, 2f));
}
