public class Item
{
    public string Name;
    public int Amount;

    public Item(string name, int amount = 1)
    {
        Name = name;
        Amount = amount;
    }

    public string GetStats()
    {
        return $"Item: {Name}, Amount: {Amount}";
    }
}

public class Inventory
{
    private List<Item> items = new List<Item>();

    public Inventory()
    {
        // Add some starter items
        items.Add(new Item("Frog Legs", 3));
        items.Add(new Item("Torch", 2));
    }

    public void AddItem(Item item)
    {
        var existing = items.FirstOrDefault(i => i.Name == item.Name);
        if (existing != null)
        {
            existing.Amount += item.Amount;
        }
        else
        {
            items.Add(item);
        }

        Console.WriteLine($"{item.Name} has been added to your inventory.");
    }

    public void ShowItems()
    {
        if (items.Count == 0)
        {
            Console.WriteLine("Your inventory is empty.");
            return;
        }

        Console.WriteLine("Items in Inventory:");
        for (int i = 0; i < items.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {items[i].GetStats()}");
        }

        Console.Write("Choose an item number to use or type 0 to exit: ");
        if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= items.Count)
        {
            Item selectedItem = items[choice - 1];
            selectedItem.Amount -= 1;
            if (selectedItem.Amount <= 0)
            {
                items.Remove(selectedItem);
                Console.WriteLine($"{selectedItem.Name} is now used up and removed from inventory.");
            }
            else
            {
                Console.WriteLine($"You used {selectedItem.Name}. Remaining: {selectedItem.Amount}");
            }
        }
    }

    public bool HasAllQuestItems()
    {
        return items.Any(i => i.Name == "Rare Herb") &&
               items.Any(i => i.Name == "Farm Ingredient") &&
               items.Any(i => i.Name == "Spider Silk");
    }

    // Optional: For debugging / testing
    public void ShowQuestItems()
    {
        Console.WriteLine("Quest Items in Inventory:");
        foreach (var questItem in new[] { "Rare Herb", "Farm Ingredient", "Spider Silk" })
        {
            var item = items.FirstOrDefault(i => i.Name == questItem);
            if (item != null)
            {
                Console.WriteLine($"- {item.Name} (Amount: {item.Amount})");
            }
            else
            {
                Console.WriteLine($"- {questItem} (not collected)");
            }
        }
    }
}
