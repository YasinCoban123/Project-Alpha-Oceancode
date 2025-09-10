public class Location
{
    public int ID;
    public string Name;
    public string Description;

    public Location LocationToNorth;
    public Location LocationToSouth;
    public Location LocationToEast;
    public Location LocationToWest;

    public Location(int id, string name, string description)
    {
        ID = id;
        Name = name;
        Description = description;
    }

    public Location Move(string direction)
    {
        direction = direction.ToLower();

        if (direction == "n") return LocationToNorth;
        if (direction == "s") return LocationToSouth;
        if (direction == "e") return LocationToEast;
        if (direction == "w") return LocationToWest;

        return null;
    }
}