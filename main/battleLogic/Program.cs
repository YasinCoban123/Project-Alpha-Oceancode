using System;

class Program
{
    static void Main()
    {
        // Create player
        Player player = new Player
        {
            Name = "Hero",
            Health = 20,
            MaxHealth = 20,
            CurrentWeapon = World.WeaponByID(World.WEAPON_ID_RUSTY_SWORD)
        };

        // Give player the healing skill at 
        // start
        Skill healingSkill = new Skill("Healing", 0, "Restore 5 HP");
        player.LearnSkill(healingSkill);

        int[] monsterOrder = {
            World.MONSTER_ID_RAT,
            World.MONSTER_ID_GIANT_SPIDER,
            World.MONSTER_ID_SNAKE
        };

        // Fight 3 of each monster type
        foreach (int monsterId in monsterOrder)
        {
            for (int i = 1; i <= 3; i++)
            {
                Monster monster = World.MonsterByID(monsterId);
                BattleSystem battle = new BattleSystem(player, monster);
                battle.StartBattle();

                if (player.Health <= 0)
                {
                    return;
                }
            }
        }

        // Display all learned skills at the end
        Console.WriteLine("\nPlayer's learned skills:");
        for (int i = 0; i < player.SkillCount; i++)
        {
            Console.WriteLine($"- {player.Skills[i].Name} (Damage: {player.Skills[i].Damage})");
        }

        // Display current weapon
        if (player.CurrentWeapon != null)
            Console.WriteLine($"\nPlayer's weapon: {player.CurrentWeapon.Name} (Damage: {player.CurrentWeapon.Damage})");
    }
}
