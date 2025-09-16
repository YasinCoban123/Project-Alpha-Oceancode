using System;

public class Player
{
    public string Name;
    public int Health;
    public int MaxHealth;
    public Weapon CurrentWeapon;
    public Inventory Inventory = new Inventory();

    // Skills
    public Skill[] Skills = new Skill[4];
    public int SkillCount = 0;

    // Kill counters
    public int SpiderKills = 0;
    public int SnakeKills = 0;
    public int RatKills = 0;

    public Player()
    {
        Health = 25;
        MaxHealth = 25;
        // Starting Healing skill
        LearnSkill(new Skill("Healing", 5, "Restore 5 HP."));
    }

    public void LearnSkill(Skill skill)
    {
        if (SkillCount < Skills.Length)
        {
            Skills[SkillCount] = skill;
            SkillCount++;
            Console.WriteLine($"You learned {skill.Name}!");
        }
    }

    public void Heal(int amount)
    {
        Health += amount;
        if (Health > MaxHealth)
            Health = MaxHealth;
    }
}
