public class Location
{
    public int ID { get; }
    public string Name { get; }
    public string Description { get; }
    public Quest QuestAvailableHere { get; set; }
    public Monster MonsterLivingHere { get; set; }

    public Location(int id, string name, string description, Quest quest, Monster monster)
    {
        ID = id;
        Name = name;
        Description = description;
        QuestAvailableHere = quest;
        MonsterLivingHere = monster;
    }

    // Optional properties to link locations together
    public Location LocationToNorth { get; set; }
    public Location LocationToSouth { get; set; }
    public Location LocationToEast { get; set; }
    public Location LocationToWest { get; set; }
}
