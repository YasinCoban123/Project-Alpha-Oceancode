public class Weapon
{
    public int ID { get; }
    public string Name { get; }
    public int Damage { get; }

    public Weapon(int id, string name, int damage)
    {
        ID = id;
        Name = name;
        Damage = damage;
    }
}
