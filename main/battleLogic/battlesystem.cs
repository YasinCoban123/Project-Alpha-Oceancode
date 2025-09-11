using System;

public class BattleSystem
{
    private Player player;
    private Monster monster;
    private Random rng = new Random();

    public BattleSystem(Player player, Monster monster)
    {
        this.player = player;
        this.monster = monster;
    }

    public void StartBattle()
    {
        Console.WriteLine($"A wild {monster.Name} appears!");

        while (player.Health > 0 && monster.CurrentHitPoints > 0)
        {
            Console.WriteLine("\nChoose an action:");
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Use Skill");
            Console.WriteLine("3. Flee");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                int playerDamage = 10;
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
                    monster.CurrentHitPoints -= chosenSkill.Damage;
                    Console.WriteLine($"You used {chosenSkill.Name} for {chosenSkill.Damage} damage!");
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

                // Give skill depending on monster ID
                if (monster.ID == World.MONSTER_ID_GIANT_SPIDER)
                {
                    Skill webStrike = new Skill("Web Strike", 8, "Shoot sticky web to slow the enemy");
                    player.LearnSkill(webStrike);
                }
                else if (monster.ID == World.MONSTER_ID_SNAKE)
                {
                    Skill venomShot = new Skill("Venom Shot", 10, "Shoot venom that poisons enemies");
                    player.LearnSkill(venomShot);
                }
            }

            if (player.Health <= 0)
            {
                Console.WriteLine("Game Over! You died.");
            }
        }
    }
}
