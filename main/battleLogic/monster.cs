public class Monster
{
    public int ID;
    public string Name;
    public int CurrentHitPoints;
    public int MaxHitPoints;
    public int MinimumDamage;
    public int MaximumDamage;

    public Monster(int id, string name, int maxHP, int minDamage, int maxDamage)
    {
        ID = id;
        Name = name;
        MaxHitPoints = maxHP;
        CurrentHitPoints = maxHP;
        MinimumDamage = minDamage;
        MaximumDamage = maxDamage;
    }
}