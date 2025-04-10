public class Detective
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Item> Inventory { get; set; }

    public Detective()
    {
        Name = "Detective Juve";
        Description = "A seasoned detective with a keen eye for detail and a knack for solving mysteries.";
        Inventory = new List<Item>();
    }

}