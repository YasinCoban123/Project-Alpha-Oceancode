using System;

class Game
{
    static void Main()
    {
        Player player = new Player
        {
            Name = "Hero",
            Health = 25,
            MaxHealth = 25,
            CurrentWeapon = World.WeaponByID(World.WEAPON_ID_RUSTY_SWORD),
            Inventory = new Inventory()
        };

        Console.WriteLine("Your mother is very sick and needs a cure or else she dies...");
        Console.WriteLine("You have always wanted to be a hero and explore the world.");
        Console.WriteLine("Now it is up to you to find the cure.");

        Location currentLocation = World.LocationByID(World.LOCATION_ID_HOME);

        while (true)
        {
            currentLocation.ShowLocation();
        
            Quest.FinalQuest(currentLocation);
        
            if (currentLocation.QuestAvailableHere != null)
                currentLocation.QuestAvailableHere.TriggerQuest(player);

            if (currentLocation.MonsterLivingHere != null)
            {
                Monster monsterTemplate = World.MonsterByID(currentLocation.MonsterLivingHere.ID);
                bool questActive = currentLocation.QuestAvailableHere == null || !currentLocation.QuestAvailableHere.IsCompleted;

                while (questActive)
                {
                    Monster monster = new Monster(
                        monsterTemplate.ID,
                        monsterTemplate.Name,
                        monsterTemplate.MaxHitPoints,
                        monsterTemplate.MinimumDamage,
                        monsterTemplate.MaximumDamage
                    );

                    BattleSystem battle = new BattleSystem(player, monster);
                    battle.StartBattle();

                    if (player.Health <= 0)
                    {
                        Console.WriteLine("You have died. Game Over!");
                        return;
                    }

                    // Stop spawning monsters if quest completed
                    if ((monster.ID == World.MONSTER_ID_RAT && player.RatKills >= 3) ||
                        (monster.ID == World.MONSTER_ID_SNAKE && player.SnakeKills >= 3) ||
                        (monster.ID == World.MONSTER_ID_GIANT_SPIDER && player.SpiderKills >= 3))
                        questActive = false;
                }

                Console.WriteLine($"\nYou have defeated all the {monsterTemplate.Name}s here!");
            }

            Console.Write("\nWhich direction do you want to go? (N/S/E/W): ");
            string input = Console.ReadLine().ToLower();
            Location newLocation = currentLocation.Move(input);

            if (newLocation != null)
                currentLocation = newLocation;
            else
                Console.WriteLine("You can't go that way!");
        }
    }
}
