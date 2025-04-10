public class GameController
{
    GameModel GameModel;
    GameView GameView;
    public GameController(GameModel gameModel, GameView gameView)
    {
        this.GameModel = gameModel;
        this.GameView = gameView;
    }

    public void InitializeGame()
    {
        GameView.PrintStartScreen();
        Console.ReadKey(true);
        HandleGameLoop();
    }
    private void HandleGameLoop()
    {
        while (true)
        {
            Location currentLocation = GameModel.LocationModel.CurrentLocation;
            bool visited = false;
            while (GameModel.LocationModel.CurrentLocation == currentLocation)
            {
                GameView.PrintLocationMenu(visited);
                String input = Console.ReadLine();
                if (input == "1")
                {
                    HandleMove(currentLocation);
                }
                else if (input == "2")
                {
                    HandleExamine(currentLocation);
                }
                else if (input == "3" && currentLocation.Characters != null && currentLocation.Characters.Count > 0)
                {
                    HandleCharacters(currentLocation);
                }
            }
        }
    }


    private void HandleMove(Location currentLocation)
    {
        while (true)
        {
            GameView.PrintMoveMenu();
            String input = Console.ReadLine();
            if (input == "0")
            {
                break;
            }
            else if (int.TryParse(input, out int index) && index > 0 && index <= currentLocation.ConnectedLocations.Count)
            {
                GameModel.LocationModel.CurrentLocation = currentLocation.ConnectedLocations[index - 1];
                break;
            }
        }
    }

    private void HandleExamine(Location currentLocation)
    {
        while (true)
        {
            GameView.PrintExamineMenu();
            if (currentLocation.Interactables.Count == 0)
            {
                Console.ReadKey(true);
                break;
            }
            String input = Console.ReadLine();
            if (input == "0")
            {
                break;
            }
            else if (int.TryParse(input, out int index) && index > 0 && index <= currentLocation.Interactables.Count)
            {
                Item item = currentLocation.Interactables[index - 1];
                GameView.PrintItemInfo(item);
                if (item.Obtainable)
                {
                    GameModel.Detective.Inventory.Add(item);
                    GameModel.LocationModel.CurrentLocation.Interactables.Remove(item);
                }
                Console.ReadKey(true);
            }
        }
    }

    private void HandleCharacters(Location currentLocation)
    {
        while (true)
        {
            GameView.PrintCharacterMenu();
            String input = Console.ReadLine();
            if (input == "0")
            {
                break;
            }
            if (int.TryParse(input, out int index) && index > 0 && index <= currentLocation.Characters.Count)
            {
                Character character = currentLocation.Characters[index - 1];
                GameView.PrintCharacterDescription(character);
                HandleTalk(character.Questions, character.Name);
            }
        }
    }

    private void HandleTalk(List<Question> questions, string characterName)
    {
        while (true)
        {
            GameView.PrintQuestionMenu(questions);
            String input = Console.ReadLine();
            if (input == "0")
            {
                break;
            }
            if (int.TryParse(input, out int index) && index > 0 && index <= questions.Count)
            {
                Question question = questions[index - 1];
                GameView.PrintAnswer(characterName, question.Answer);
                Console.ReadKey(true);
                if (question.FollowupQuestions != null && question.FollowupQuestions.Count > 0)
                {
                    HandleTalk(question.FollowupQuestions, characterName);
                }
            }
        }
    }
}