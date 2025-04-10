class Location
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Character> Characters { get; set; }

    public List<Item> Interactables { get; set; }
    public List<Location> ConnectedLocations { get; set; }

    public Location(string name, string description, List<Item> interactables, List<Character> characters, List<Location> connectedLocations)
    {
        Name = name;
        Description = description;
        Interactables = interactables;
        Characters = characters;
        ConnectedLocations = connectedLocations;
    }
}