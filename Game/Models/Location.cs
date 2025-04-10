public class Location
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? ExamineDescription { get; set; }
    public string? Image { get; set; }
    public List<Character>? Characters { get; set; }
    public List<Item>? Interactables { get; set; }
    public List<Location>? ConnectedLocations { get; set; }

    public void Initialize(string name, string description, string examineDescription, string image, List<Item> interactables, List<Character> characters, List<Location> connectedLocations)
    {
        Name = name;
        Description = description;
        ExamineDescription = examineDescription;
        Image = image;
        Interactables = interactables;
        Characters = characters;
        ConnectedLocations = connectedLocations;
    }
}