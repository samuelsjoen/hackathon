public class Character
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Question> Questions { get; set; }

    public Character(string name, string description, List<Question> questions)
    {
        Name = name;
        Description = description;
        Questions = questions;
    }

    public void Accuse()
    {}

    public void Interact()
    {}
}