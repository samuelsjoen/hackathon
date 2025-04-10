public class Item
{
    public string Name { get; }
    public string Description { get;}
    public bool Obtainable { get;}

    public Item(string name, string description, bool obtainable)
    {
        this.Name = name;
        this.Description = description;
        this.Obtainable = obtainable;
    }
}