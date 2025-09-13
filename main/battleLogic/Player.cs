public class Player
{
    public string Name;
    public int Health;
    public int MaxHealth;
    public Weapon CurrentWeapon;

    public Skill[] Skills = new Skill[10];
    public int SkillCount = 0;

    public void LearnSkill(Skill skill)
    {
        if (SkillCount < Skills.Length)
        {
            Skills[SkillCount] = skill;
            SkillCount++;
        }
    }

    // Heal method for the healing skill
    public void Heal(int amount)
    {
        Health += amount;
        if (Health > MaxHealth)
            Health = MaxHealth;
    }
}
