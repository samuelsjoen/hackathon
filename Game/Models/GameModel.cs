public class GameModel
{
    public GameState CurrentGameState { get; set; }
    public int SelectedOption { get; set; }
    public Item SelectedItem { get; set; }
    public Character SelectedCharacter { get; set; }
    public List<Question> SelectedQuestions { get; set; }
    public Question SelectedQuestion { get; set; }
    public Detective Detective { get; set; }
    public LocationModel LocationModel { get; set; }
    public CharacterModel CharacterModel { get; set; }


    public GameModel()
    {
        CurrentGameState = GameState.StartScreen;
        SelectedOption = 0;
        Detective = new Detective();
        CharacterModel = new CharacterModel();
        LocationModel = new LocationModel(CharacterModel);
    }
}