using System;

public class BattleSystem
{
    public Player player;
    public Monster monster;
    private Random rng = new Random();

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
                if (monster.CurrentHitPoints < 0) monster.CurrentHitPoints = 0;
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
                    Console.WriteLine($"{i + 1}. {player.Skills[i].Name} (Damage/Effect: {player.Skills[i].Damage})");

                if (int.TryParse(Console.ReadLine(), out int skillIndex) &&
                    skillIndex >= 1 && skillIndex <= player.SkillCount)
                {
                    Skill chosenSkill = player.Skills[skillIndex - 1];

                    if (chosenSkill.Name.ToLower() == "healing")
                    {
                        player.Heal(chosenSkill.Damage);
                        Console.WriteLine($"You used Healing and restored {chosenSkill.Damage} HP!");
                    }
                    else
                    {
                        monster.CurrentHitPoints -= chosenSkill.Damage;
                        if (monster.CurrentHitPoints < 0) monster.CurrentHitPoints = 0;
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

            // Show health
            Console.WriteLine($"Your health: {player.Health}/{player.MaxHealth}");
            Console.WriteLine($"Monster health: {monster.CurrentHitPoints}/{monster.MaxHitPoints}");

            if (monster.CurrentHitPoints > 0)
            {
                int monsterDamage = rng.Next(monster.MinimumDamage, monster.MaximumDamage + 1);
                player.Health -= monsterDamage;
                if (player.Health < 0) player.Health = 0;
                Console.WriteLine($"The {monster.Name} hits you for {monsterDamage} damage!");
            }
            else
            {
                Console.WriteLine($"You defeated the {monster.Name}!");

                // Kill counters and quest completion
                if (monster.ID == World.MONSTER_ID_RAT)
                {
                    player.RatKills++;
                    if (player.RatKills >= 3)
                        World.QuestByID(World.QUEST_ID_CLEAR_ALCHEMIST_GARDEN).QuestCompleted(player);
                }
                else if (monster.ID == World.MONSTER_ID_SNAKE)
                {
                    player.SnakeKills++;
                    if (player.SnakeKills >= 3)
                        World.QuestByID(World.QUEST_ID_CLEAR_FARMERS_FIELD).QuestCompleted(player);
                }
                else if (monster.ID == World.MONSTER_ID_GIANT_SPIDER)
                {
                    player.SpiderKills++;
                    if (player.SpiderKills >= 3)
                        World.QuestByID(World.QUEST_ID_COLLECT_SPIDER_SILK).QuestCompleted(player);
                }
            }
        }
    }
}
