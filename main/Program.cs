class Program
{
    static void Main()
    {
        Player player = new Player("Hero", 50);

        // Get monsters from World.cs
        Monster spider = World.MonsterByID(World.MONSTER_ID_GIANT_SPIDER);
        Monster snake = World.MonsterByID(World.MONSTER_ID_SNAKE);

        // Start battles
        BattleSystem battle1 = new BattleSystem(player, spider);
        battle1.StartBattle();

        BattleSystem battle2 = new BattleSystem(player, snake);
        battle2.StartBattle();

        // Show learned skills
        Console.WriteLine("\nPlayer's skills:");
        for (int i = 0; i < player.SkillCount; i++)
        {
            Console.WriteLine($"- {player.Skills[i].Name} (Damage: {player.Skills[i].Damage})");
        }
    }
}
