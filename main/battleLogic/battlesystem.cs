using System;

public class BattleSystem
{
    public Player player;
    public Monster monster;
    private Random rng = new Random();

    private int SpiderKills = 0;
    private int SnakeKills = 0;
    private int RatKills = 0;

    public BattleSystem(Player player, Monster monster)
    {
        this.player = player;
        this.monster = monster;
        this.monster.CurrentHitPoints = this.monster.MaxHitPoints; // Reset monster HP
    }

    public void StartBattle()
    {
        Console.WriteLine($"\nA wild {monster.Name} appears!");

        while (player.Health > 0 && monster.CurrentHitPoints > 0)
        {
            Console.WriteLine("\nChoose an action:");
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Use Skill");
            Console.WriteLine("3. Flee");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                int playerDamage = player.CurrentWeapon != null ? player.CurrentWeapon.Damage : 5;
                monster.CurrentHitPoints -= playerDamage;
                Console.WriteLine($"You hit the {monster.Name} for {playerDamage} damage!");
            }
            else if (choice == "2")
            {
                if (player.SkillCount == 0)
                {
                    Console.WriteLine("You have no skills!");
                    continue;
                }

                Console.WriteLine("Choose a skill:");
                for (int i = 0; i < player.SkillCount; i++)
                {
                    Console.WriteLine($"{i + 1}. {player.Skills[i].Name} (Damage: {player.Skills[i].Damage})");
                }

                if (int.TryParse(Console.ReadLine(), out int skillIndex) &&
                    skillIndex >= 1 && skillIndex <= player.SkillCount)
                {
                    Skill chosenSkill = player.Skills[skillIndex - 1];

                    // Healing skill executes differently
                    if (chosenSkill.Name == "Healing")
                    {
                        chosenSkill.Execute(player); // Heals +5
                        Console.WriteLine("You used Healing and restored 5 HP!");
                        Console.WriteLine($"Your health: {player.Health}/{player.MaxHealth}");
                    }
                    else
                    {
                        monster.CurrentHitPoints -= chosenSkill.Damage;
                        Console.WriteLine($"You used {chosenSkill.Name} for {chosenSkill.Damage} damage!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid skill choice.");
                    continue;
                }
            }
            else if (choice == "3")
            {
                Console.WriteLine("You fled the battle!");
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Try again.");
                continue;
            }

            // Monster attacks back
            if (monster.CurrentHitPoints > 0)
            {
                int monsterDamage = rng.Next(monster.MinimumDamage, monster.MaximumDamage + 1);
                player.Health -= monsterDamage;
                Console.WriteLine($"The {monster.Name} hits you for {monsterDamage} damage!");
                Console.WriteLine($"Your health: {player.Health}/{player.MaxHealth}");
            }
            else
            {
                Console.WriteLine($"You defeated the {monster.Name}!");

                // Increment kill counters and reward skills (no direct HP increase)
                if (monster.ID == World.MONSTER_ID_GIANT_SPIDER)
                {
                    SpiderKills++;
                    if (SpiderKills == 3)
                    {
                        Skill webStrike = new Skill("Web Strike", 6, "Shoot sticky web to slow enemies");
                        player.LearnSkill(webStrike);
                        Console.WriteLine("You learned Web Strike for defeating 3 spiders!");
                    }
                }
                else if (monster.ID == World.MONSTER_ID_SNAKE)
                {
                    SnakeKills++;
                    if (SnakeKills == 3)
                    {
                        Skill venomShot = new Skill("Venom Shot", 8, "Shoot venom that poisons enemies");
                        player.LearnSkill(venomShot);
                        Console.WriteLine("You learned Venom Shot for defeating 3 snakes!");
                    }
                }
                else if (monster.ID == World.MONSTER_ID_RAT)
                {
                    RatKills++;
                    if (RatKills == 3)
                    {
                        Skill quickStab = new Skill("Quick Stab", 3, "Fast stabbing attack");
                        player.LearnSkill(quickStab);
                        Console.WriteLine("You learned Quick Stab for defeating 3 rats!");
                    }
                }
            }

            if (player.Health <= 0)
                Console.WriteLine("Game Over! You died.");
        }
    }
}
