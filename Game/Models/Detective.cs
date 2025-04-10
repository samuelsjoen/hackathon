public class Detective : ICharacter
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Question> Questions { get; set; }

    public Detective(string name, string description)
    {
        Name = name;
        Description = description;
        Questions = new List<Question>();
    }

}