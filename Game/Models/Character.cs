public class Character
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Question> Questions { get; set; }

    public string Image { get; set; }

    public bool visited { get; set; }

    public Character(string name, string description, List<Question> questions, string image)
    {
        Name = name;
        Description = description;
        Questions = questions;
        Image = image;
        visited = false;
    }

    public void Accuse()
    {}
}