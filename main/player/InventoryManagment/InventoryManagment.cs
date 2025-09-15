using System;
using System.Collections.Generic;
using System.Linq;

public class Item
{
    public string Name;
    public int Amount;

    public Item(string name, int amount = 1)
    {
        Name = name;
        Amount = amount;
    }

    public override string ToString()
    {
        return $"Item: {Name}, Amount: {Amount}";
    }
}

// Weapon class inherits from Item
public class Weapon : Item
{
    public int Damage;
    public int ID;

    public Weapon(int id, string name, int damage, int amount = 1) 
        : base(name, amount)
    {
        ID = id;
        Damage = damage;
    }

    public override string ToString()
    {
        return $"Weapon: {Name}, Damage: {Damage}, Amount: {Amount}";
    }
}

// Inventory class
public class Inventory
{
    private List<Item> items = new List<Item>();

    // Preload some items and weapons for demo
    public Inventory()
    {
        // Add generic items
        items.Add(new Item("Frog legs", 3));
        items.Add(new Item("Torch", 2));

        // Add predefined weapons from World
        items.Add(World.WeaponByID(World.WEAPON_ID_RUSTY_SWORD));
        items.Add(World.WeaponByID(World.WEAPON_ID_CLUB));
    }

    // Show only items (non-weapons)
    public void ShowItems()
    {
        List<Item> nonWeapons = items.Where(i => !(i is Weapon)).ToList();
        if (nonWeapons.Count == 0)
        {
            Console.WriteLine("No items in inventory.");
        }
        else
        {
            Console.WriteLine("Items in Inventory:");
            foreach (Item item in nonWeapons)
            {
                Console.WriteLine(item);
            }
        }
    }

    // Show only weapons
    public void ShowWeapons()
    {
        List<Weapon> weapons = items.OfType<Weapon>().ToList();
        if (weapons.Count == 0)
        {
            Console.WriteLine("No weapons in inventory.");
        }
        else
        {
            Console.WriteLine("Weapons in Inventory:");
            foreach (Weapon weapon in weapons)
            {
                Console.WriteLine(weapon);
            }
        }
    }
}

// World class for predefined content
public static class World
{
    public static readonly List<Weapon> Weapons = new List<Weapon>();

    public const int WEAPON_ID_RUSTY_SWORD = 1;
    public const int WEAPON_ID_CLUB = 2;

    static World()
    {
        PopulateWeapons();
    }

    public static void PopulateWeapons()
    {
        Weapons.Add(new Weapon(WEAPON_ID_RUSTY_SWORD, "Rusty Sword", 5));
        Weapons.Add(new Weapon(WEAPON_ID_CLUB, "Club", 10));
    }

    public static Weapon WeaponByID(int id)
    {
        return Weapons.FirstOrDefault(w => w.ID == id);
    }
}

// Main program
class Program
{
    static void Main(string[] args)
    {
        Inventory inventory = new Inventory();
        bool running = true;

        Console.WriteLine("Welcome to the Inventory System!");

        while (running)
        {
            Console.WriteLine("\nCommands: show items, show weapons, exit");
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
