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

        Skill healingSkill = new Skill("Healing", 0, "Restore 5 HP", (p) => p.Heal(5));
        player.LearnSkill(healingSkill);

        // Monster encounter order: Rat -> Spider -> Snake
        int[] monsterOrder = {
            World.MONSTER_ID_RAT,
            World.MONSTER_ID_GIANT_SPIDER,
            World.MONSTER_ID_SNAKE
        };

        foreach (int monsterId in monsterOrder)
        {
            // Fight 3 of the same monster
            for (int i = 1; i <= 3; i++)
            {
                Monster monster = World.MonsterByID(monsterId);
                BattleSystem battle = new BattleSystem(player, monster);
                battle.StartBattle();

                if (player.Health <= 0)
                {
                    Console.WriteLine("Game Over! You died.");
                    return;
                }
            }
        }
    }
}
