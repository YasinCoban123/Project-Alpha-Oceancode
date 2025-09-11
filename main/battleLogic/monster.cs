public class Monster
{
    public int ID;           
    public string Name;
    public int CurrentHitPoints;
    public int MinimumDamage;
    public int MaximumDamage;

    public Monster(int id, string name, int hp, int minDamage, int maxDamage)
    {
        ID = id;
        Name = name;
        CurrentHitPoints = hp;
        MinimumDamage = minDamage;
        MaximumDamage = maxDamage;
    }
}
