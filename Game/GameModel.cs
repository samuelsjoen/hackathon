public class GameModel
{
    public Detective Detective;
    public LocationHandler LocationHandler;
    public CharacterHandler CharacterHandler;

    public GameModel()
    {
        Detective = new Detective();
        CharacterHandler = new CharacterHandler();
        LocationHandler = new LocationHandler(CharacterHandler);
    }
}