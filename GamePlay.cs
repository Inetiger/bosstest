namespace bosstest
{
    internal class GamePlay
    {
        public List<Item> DroppableItems { get; } = new()
        {
            new Item("HealthPotion"),
            new Item("StaminaPotion"),
            new Item("StrengthPotion"),
            new Item("Dagger"),
            new Item("Small-Sword"),
            new Item("Big-Sword"),
            new Item("Bow"),
            new Item("Cross-Bow"),
            new Item("Helmet"),
            new Item("ChestPlate"),
        };

        public Item GetItemByName(string itemName)
        {
            return DroppableItems.Find(item => item.Name == itemName);
        }

        public Item GetRandomItemToDrop()
        {
            Random random = new Random();
            return DroppableItems[random.Next(0, DroppableItems.Count)];
        }
    }
}