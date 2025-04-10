public class Item
{
    string Title { get; set; }
    string Description { get; set; }

    bool Obtainable { get; set; }

    public Item(string title, string description, bool obtainable)
    {
        this.Title = title;
        this.Description = description;
        this.Obtainable = obtainable;
    }
}