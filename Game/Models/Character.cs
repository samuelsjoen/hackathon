public class Character : ICharacter
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Question> Questions { get; set; }

    public Character(string name, string description)
    {
        Name = name;
        Description = description;
        Questions = new List<Question>();
    }
    
}