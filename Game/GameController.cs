public class GameController
{
    GameModel GameModel;
    GameView GameView;
    public GameController(GameModel gameModel, GameView gameView)
    {
        this.GameModel = gameModel;
        this.GameView = gameView;
    }

    public void onChange()
    {
        GameView.Print();
    }


    public void InitializeGame()
    {
        onChange();
        Console.ReadKey(true);
        HandleGameLoop();
    }
    private void HandleGameLoop()
    {
        while (true)
        {
            Location currentLocation = GameModel.LocationModel.CurrentLocation;
            while (GameModel.LocationModel.CurrentLocation == currentLocation)
            {
                GameModel.CurrentGameState = GameState.ToDoMenu;
                onChange();

                int input = SelectOptionWithArrows(4);

                if (input == 0)
                {
                    HandleMove(currentLocation);
                }
                else if (input == 1)
                {
                    HandleExamine(currentLocation);
                }
                else if (input == 2 && currentLocation.Characters != null && currentLocation.Characters.Count > 0)
                {
                    HandleCharacters(currentLocation);
                }
                else if (input == 3)
                {
                    HandleInventory();
                }
            }
        }
    }


    private void HandleMove(Location currentLocation)
    {
        while (true)
        {
            GameModel.CurrentGameState = GameState.MoveMenu;
            onChange();
            int input = SelectOptionWithArrows(currentLocation.ConnectedLocations.Count + 1);
            if (input == 0)
            {
                break;
            }
            else if (input > 0 && input <= currentLocation.ConnectedLocations.Count)
            {
                GameModel.LocationModel.CurrentLocation = currentLocation.ConnectedLocations[input - 1];
                break;
            }
        }
    }

    private void HandleExamine(Location currentLocation)
    {
        while (true)
        {
            GameModel.CurrentGameState = GameState.ExamineMenu;
            onChange();
            if (currentLocation.Interactables.Count == 0)
            {
                Console.ReadKey(true);
                break;
            }
            int input = SelectOptionWithArrows(currentLocation.Interactables.Count + 1);
            if (input == 0)
            {
                break;
            }
            else if (input > 0 && input <= currentLocation.Interactables.Count)
            {
                Item item = currentLocation.Interactables[input - 1];
                GameModel.SelectedItem = item;
                GameModel.CurrentGameState = GameState.ItemInfo;
                onChange();
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
            GameModel.CurrentGameState = GameState.SelectCharacterMenu;
            onChange();

            int input = SelectOptionWithArrows(currentLocation.Characters.Count + 1);
            if (input == 0)
            {
                break;
            }
            if (input > 0 && input <= currentLocation.Characters.Count)
            {
                Character character = currentLocation.Characters[input - 1];
                GameModel.CharacterModel.selectedCharacter = character;
                HandleTalk(character.Questions, character.Name);
            }
        }
    }

    private void HandleTalk(List<Question> questions, string characterName)
    {
        while (true)
        {
            GameModel.CurrentGameState = GameState.QuestionMenu;
            GameModel.SelectedQuestions = questions;
            onChange();
            int input = SelectOptionWithArrows(questions.Count + 1);
            if (input == 0)
            {
                break;
            }
            if (input > 0 && input <= questions.Count)
            {
                Question question = questions[input - 1];
                GameModel.CurrentGameState = GameState.Answer;
                GameModel.SelectedQuestion = question;
                onChange();
                Console.ReadKey(true);
                if (question.FollowupQuestions != null && question.FollowupQuestions.Count > 0)
                {
                    HandleTalk(question.FollowupQuestions, characterName);
                }
            }
        }
    }

    private void HandleInventory()
    {
        while (true)
        {
            GameModel.CurrentGameState = GameState.InventoryMenu;
            onChange();
            if (GameModel.Detective.Inventory.Count == 0)
            {
                Console.ReadKey(true);
                break;
            }
            int input = SelectOptionWithArrows(GameModel.Detective.Inventory.Count + 1);
            if (input == 0)
            {
                break;
            }
            else if (input > 0 && input <= GameModel.Detective.Inventory.Count)
            {
                Item item = GameModel.Detective.Inventory[input - 1];
                GameModel.SelectedItem = item;
                GameModel.CurrentGameState = GameState.ItemInfo;
                onChange();
                Console.ReadKey(true);
            }
        }
    }

    private int SelectOptionWithArrows(int OptionsAmount)
    {
        int selectedIndex = 0;
        GameModel.SelectedOption = 0;
        while (true)
        {
            onChange();
            ConsoleKey key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    selectedIndex = (selectedIndex - 1 + OptionsAmount) % OptionsAmount; // Move up
                    GameModel.SelectedOption = selectedIndex;
                    break;
                case ConsoleKey.DownArrow:
                    selectedIndex = (selectedIndex + 1) % OptionsAmount; // Move down
                    GameModel.SelectedOption = selectedIndex;
                    break;
                case ConsoleKey.Enter:
                    GameModel.SelectedOption = selectedIndex;
                    return selectedIndex;
            }
        }
    }
}