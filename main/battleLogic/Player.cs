public class Player
{
    public string Name;
    public int Health;
    public int MaxHealth;

    public Skill[] Skills;
    public int SkillCount;

    public Player(string name, int maxHealth, int maxSkills = 3)
    {
        Name = name;
        MaxHealth = maxHealth;
        Health = maxHealth;
        Skills = new Skill[maxSkills];
        SkillCount = 0;
    }

    public void LearnSkill(Skill skill)
    {
        if (SkillCount < Skills.Length)
        {
            Skills[SkillCount] = skill;
            SkillCount++;
            Console.WriteLine($"{Name} learned a new skill: {skill.Name} (Damage: {skill.Damage})");
        }
        else
        {
            Console.WriteLine($"{Name} cannot learn more skills.");
        }
    }
}
