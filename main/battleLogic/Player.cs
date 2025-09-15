public class Player
{
    public string Name;
    public int Health;
    public int MaxHealth;
    public Weapon CurrentWeapon;

    // Skills
    public Skill[] Skills = new Skill[10];
    public int SkillCount = 0;

    // Kill counters for monsters
    public int SpiderKills = 0;
    public int SnakeKills = 0;
    public int RatKills = 0;

    public void LearnSkill(Skill skill)
    {
        if (SkillCount < Skills.Length)
        {
            Skills[SkillCount] = skill;
            SkillCount++;
            Console.WriteLine($"You learned {skill.Name}!");
        }
    }

    // Heal method for healing skill
    public void Heal(int amount)
    {
        Health += amount;
        if (Health > MaxHealth)
            Health = MaxHealth;
    }
}
