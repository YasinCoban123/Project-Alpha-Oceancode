using System;

public class RewardsSystem
{
    public Inventory InventorySys;

    public RewardsSystem(Inventory inventory)
    {
        InventorySys = inventory;
    }


    public void GrantReward(string RewardType)
    {
        switch (RewardType.ToLower())
        {
            case "Frog eg":
                _inventory.AddItem(new Item("Frog leg", 1));
                Console.WriteLine("You received a Frog leg!");
                break;

            case "Rusty Armor":
                _inventory.AddItem(new Item("Rusty Armor", 1));
                Console.WriteLine("You received a Rusty Armor!");
                break;

            case "Sturdy Sword":
                _inventory.AddItem(new Weapon(World.WEAPON_ID_RUSTY_SWORD, "Sturdy Sword", 5));
                Console.WriteLine("You received a Sturdy Sword!");
                break;

            case "Mace":
                _inventory.AddItem(new Weapon(World.WEAPON_ID_CLUB, "Mace", 10));
                Console.WriteLine("You received a Mace!");
                break;

            default:
                Console.WriteLine("No reward found for this type.");
                break;
        }
    }

    public void GrantRandomReward()
    {
        Random rand = new Random();
        int roll = rand.Next(1, 4);

        if (roll == 1)
            GrantReward("Frog leg");
        else if (roll == 2)
            GrantReward("Rusty Armor");
        else if (roll == 3)
            GrantReward("Sturdy Sword");
        else
            GrantReward("Mace");
    }
}
