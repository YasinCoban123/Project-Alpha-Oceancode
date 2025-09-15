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

// Weapon class inherits from Item
public class Weapon : Item
{
    public int Damage;
    public int ID;

    public Weapon(int id, string name, int damage)
        : base(name)
    {
        ID = id;
        Damage = damage;
    }

    public string GetStats()
    {
        return $"Weapon: {Name}, Damage: {Damage}";
    }
}

// Inventory class
public class Inventory
{
    private List<Item> items = new List<Item>();

    // Preload some items and weapons
    public Inventory()
    {
        // Add generic items
        items.Add(new Item("Frog legs", 3));
        items.Add(new Item("Torch", 2));

        // Add predefined weapons from World
        var rustySword = World.WeaponByID(World.WEAPON_ID_RUSTY_SWORD);
        if (rustySword != null)
            items.Add(rustySword);
    }

    public void AddWeapon(Weapon newWeapon)
    {
        // Check if a weapon of same ID exists
        Weapon existing = items.OfType<Weapon>().FirstOrDefault(w => w.ID == newWeapon.ID);

        if (existing == null)
        {
            items.Add(newWeapon);
            Console.WriteLine($"{newWeapon.Name} added to inventory.");
        }
        else
        {
            // Always overwrite if new weapon is better
            if (newWeapon.Damage > existing.Damage)
            {
                items.Remove(existing);
                items.Add(newWeapon);
                Console.WriteLine($"{newWeapon.Name} replaced {existing.Name} (better weapon).");
            }
            else
            {
                Console.WriteLine($"{newWeapon.Name} discarded (worse than {existing.Name}).");
            }
        }
    }

    // Show only items (non-weapons) and allow using them
    public void ShowItems()
    {
        List<Item> nonWeapons = items.Where(i => !(i is Weapon)).ToList();
        if (nonWeapons.Count == 0)
        {
            Console.WriteLine("No items in inventory.");
            return;
        }

        Console.WriteLine("Items in Inventory:");
        for (int i = 0; i < nonWeapons.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {nonWeapons[i].GetStats()}");
        }

        Console.Write("Choose an item number to use or type 0 to exit: ");
        if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= nonWeapons.Count)
        {
            Item selectedItem = nonWeapons[choice - 1];
            selectedItem.Amount -= 1;
            if (selectedItem.Amount <= 0)
            {
            items.Remove(selectedItem); 
            Console.WriteLine($"{selectedItem.Name} is now used up and removed from inventory.");
            }
            Console.WriteLine($"You chose to use {selectedItem.Name}.");
            // Leave the result blank (to be implemented elsewhere)
        }
    }

    
    public void ShowWeapons()
    {
        List<Weapon> weapons = items.OfType<Weapon>().ToList();
        if (weapons.Count == 0)
        {
            Console.WriteLine("No weapons in inventory.");
            return;
        }

        Console.WriteLine("Weapons in Inventory:");
        for (int i = 0; i < weapons.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {weapons[i].GetStats()}");
        }

        Console.Write("Enter weapon number to inspect or 0 to exit: ");
        if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= weapons.Count)
        {
            Weapon selectedWeapon = weapons[choice - 1];
            Console.WriteLine($"Inspecting {selectedWeapon.Name}: Damage = {selectedWeapon.Damage}");
        }
    }
}

// World class for predefined content
public static class World
{
    public static readonly List<Weapon> Weapons = new List<Weapon>();

    public const int WEAPON_ID_RUSTY_SWORD = 1;

    static World()
    {
        PopulateWeapons();
    }

    public static void PopulateWeapons()
    {
        Weapons.Add(new Weapon(WEAPON_ID_RUSTY_SWORD, "Rusty Sword", 5));
        Weapons.Add(new Weapon(WEAPON_ID_RUSTY_SWORD, "Banana Sword", 10));
    }

    public static Weapon WeaponByID(int id)
    {
        // Return the strongest weapon with the given ID
        return Weapons.Where(w => w.ID == id).OrderByDescending(w => w.Damage).FirstOrDefault();
    }
}

// Main program
class Program
{
    static void Main(string[] args)
    {
        Inventory inventory = new Inventory();
        bool running = true;

        Console.WriteLine("You look inside your backpack!");

        while (running)
        {
            Console.WriteLine("\nChoices: show items, show weapons, exit");
            Console.Write("Enter command: ");
            string command = Console.ReadLine().ToLower();

            switch (command)
            {
                case "show items":
                    inventory.ShowItems();
                    break;

                case "show weapons":
                    inventory.ShowWeapons();
                    break;

                case "exit":
                    running = false;
                    Console.WriteLine("Getting back to the game");
                    break;

                default:
                    Console.WriteLine("Unknown command!");
                    break;
            }
        }
    }
}
