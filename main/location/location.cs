public class Location
{
    public int ID;
    public string Name;
    public string Description;
    public Item ItemRequiredToEnter;
    public Quest QuestAvailableHere;
    public Monster MonsterLivingHere;
 
    public Location LocationToNorth;
    public Location LocationToSouth;
    public Location LocationToEast;
    public Location LocationToWest;
    public bool AreMonstersDefeated = false;

    public Location(int id, string name, string description, Item itemRequiredToEnter, Quest questAvailableHere)
    {
        ID = id;
        Name = name;
        Description = description;
        ItemRequiredToEnter = itemRequiredToEnter;
        QuestAvailableHere = questAvailableHere;
    }
 
    public Location Move(string direction)
    {
        direction = direction.ToLower();
 
        if (direction == "n")
        {
            return LocationToNorth;
        }
        if (direction == "s")
        {
            return LocationToSouth;
        }
        if (direction == "e")
        {
            return LocationToEast;
        }
        if (direction == "w")
        {
            return LocationToWest;
        }
 
        return null;
    }
 
    public string GetAvailableDirections()
    {
        string exits = "";
 
        if (LocationToNorth != null)
        {
            exits += "North (N) ";
        }
        if (LocationToSouth != null)
        {
            exits += "South (S) ";
        }
        if (LocationToEast != null)
        {
            exits += "East (E) ";
        }
        if (LocationToWest != null)
        {
            exits += "West (W) ";
        }
 
        if (exits == "")
        {
            exits = "No exits";
        }
 
        return exits;
    }
 
    public void ShowLocation()
    {
        string exits = GetAvailableDirections();
        Console.WriteLine($"\nYou are at: {Name}");
        Console.WriteLine(Description);
        Console.WriteLine($"Exits: {exits}");
    }
}