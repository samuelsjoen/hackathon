public class GameModel
{
    public Detective Detective { get; set; }
    public LocationModel LocationModel { get; set; }
    public CharacterModel CharacterModel { get; set; }

    public GameModel()
    {
        Detective = new Detective();
        CharacterModel = new CharacterModel();
        LocationModel = new LocationModel(CharacterModel);
    }
}