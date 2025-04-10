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
                if (!visited)
                {
                    GameView.AddToPrintQueue(currentLocation.Description);
                    visited = true;
                }
                GameView.AddToPrintQueue("What would you like to do?");
                GameView.AddToPrintQueue("1. Move to another location");
                GameView.AddToPrintQueue("2. Examine the location");
                if (currentLocation.Characters != null && currentLocation.Characters.Count > 0)
                {
                    GameView.AddToPrintQueue("3. Talk to a character");
                }
                GameView.Print();
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
                else
                {
                    GameView.PrintInvalidInput();
                }
            }
        }
    }


    private void HandleMove(Location currentLocation)
    {
        while (true)
        {
            GameView.AddToPrintQueue("Where would you like to go?");
            GameView.AddToPrintQueue($"0. Cancel");
            for (int i = 0; i < currentLocation.ConnectedLocations.Count; i++)
            {
                GameView.AddToPrintQueue($"{i + 1}. {currentLocation.ConnectedLocations[i].Name}");
            }
            GameView.Print();
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
            else
            {
                GameView.PrintInvalidInput();
            }
        }
    }

    private void HandleExamine(Location currentLocation)
    {
        while (true)
        {
            GameView.AddToPrintQueue(currentLocation.ExamineDescription);
            GameView.AddToPrintQueue("What would you like to examine");
            GameView.AddToPrintQueue($"0. Cancel");
            for (int i = 0; i < currentLocation.Interactables.Count; i++)
            {
                GameView.AddToPrintQueue($"{i + 1}. {currentLocation.Interactables[i].Name}");
            }
            GameView.Print();
            String input = Console.ReadLine();
            if (input == "0")
            {
                break;
            }
            else if (int.TryParse(input, out int index) && index > 0 && index <= currentLocation.Interactables.Count)
            {
                Item item = currentLocation.Interactables[index - 1];
                GameView.AddToPrintQueue(item.Description);
                if (item.Obtainable)
                {
                    GameView.AddToPrintQueue($"You have obtained {item.Name}.");
                    GameModel.Detective.Inventory.Add(item);
                }
                break;
            }
            else
            {
                GameView.PrintInvalidInput();
            }
        }
    }

    private void HandleCharacters(Location currentLocation)
    {
        while (true)
        {
            GameView.AddToPrintQueue("Who would you like to talk to?");
            GameView.AddToPrintQueue($"0. Cancel");
            for (int i = 0; i < currentLocation.Characters.Count; i++)
            {
                GameView.AddToPrintQueue($"{i + 1}. {currentLocation.Characters[i].Name}");
            }
            GameView.Print();
            String input = Console.ReadLine();
            if (input == "0")
            {
                break;
            }
            if (int.TryParse(input, out int index) && index > 0 && index <= currentLocation.Characters.Count)
            {
                Character character = currentLocation.Characters[index - 1];
                GameView.AddToPrintQueue(character.Description);
                GameView.Print();
                HandleTalk(character.Questions);
            }
            else
            {
                GameView.PrintInvalidInput();
            }
        }
    }

    private void HandleTalk(List<Question> questions)
    {
        while (true)
        {
            GameView.AddToPrintQueue("What would you like to ask?");
            GameView.AddToPrintQueue($"0. Cancel");
            for (int i = 0; i < questions.Count; i++)
            {
                GameView.AddToPrintQueue($"{i + 1}. {questions[i].Text}");
            }
            GameView.Print();
            String input = Console.ReadLine();
            if (input == "0")
            {
                break;
            }
            if (int.TryParse(input, out int index) && index > 0 && index <= questions.Count)
            {
                Question question = questions[index - 1];
                GameView.AddToPrintQueue(question.Answer);
                GameView.Print();
                if (question.FollowupQuestions != null && question.FollowupQuestions.Count > 0)
                {
                    HandleTalk(question.FollowupQuestions);
                }
                break;
            }
            else
            {
                GameView.PrintInvalidInput();
            }
        }
    }
}