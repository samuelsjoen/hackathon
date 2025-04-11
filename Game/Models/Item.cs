public class Item
{
    public string Name { get; }
    public string Description { get;}
    public bool Obtainable { get;}

    public string Image { get; }

    public Item(string name, string description, bool obtainable, string image)
    {
        this.Name = name;
        this.Description = description;
        this.Obtainable = obtainable;
        this.Image = image;
    }
}