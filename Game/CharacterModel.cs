public class CharacterModel
{
    public Character? selectedCharacter { get; set; }

    public List<Character> Characters { get; set; } = new List<Character>();

    public CharacterModel()
    {
        SetupCharacters();
    }

    public void SetupCharacters()
    {
        Character fisherman = new Character(
            "Fisherman",
            "You approach the fisherman. He looks tired and busy. His face is weathered and dirty.",
            new List<Question>()
            {
                new Question("What are you doing here?", "Just unloading my catch. What do you want?", new List<Question>()
                {
                    new Question("Can you tell me anything about this island?", "It's a quiet place, not much happens here.", new List<Question>()),
                    new Question("Have you seen anything unusual?", "Not really, just the usual stuff.", new List<Question>()),
                }),
            }
        );
        Characters.Add(fisherman);
    }

    public Character GetCharacter(string name)
    {
        return Characters.FirstOrDefault(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
               ?? throw new InvalidOperationException($"Character with name '{name}' not found.");
    }
}