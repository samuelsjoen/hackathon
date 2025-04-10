public class GameView
{
    private GameModel GameModel;
    private List<string> PrintQueue;
    private Location CurrentLocation => GameModel.LocationModel.CurrentLocation;

    private Character SelectedCharacter => GameModel.CharacterModel.selectedCharacter;

    private Detective Detective => GameModel.Detective;

    private List<Question> SelectedQuestions => GameModel.SelectedQuestions;

    private Question SelectedQuestion => GameModel.SelectedQuestion;

    private GameState CurrentGameState => GameModel.CurrentGameState;

    private int CurrentOptionSelected => GameModel.SelectedOption;

    public GameView(GameModel gameModel)
    {
        this.GameModel = gameModel;
        PrintQueue = new List<string>();
    }

    public void Print()
    {
        Console.Clear();
        switch (CurrentGameState)
        {
            case GameState.StartScreen:
                PrintStartScreen();
                break;
            case GameState.ToDoMenu:
                PrintToDoMenu();
                break;
            case GameState.MoveMenu:
                PrintMoveMenu();
                break;
            case GameState.ExamineMenu:
                PrintExamineMenu();
                break;
            case GameState.ItemInfo:
                PrintItemInfo();
                break;
            case GameState.SelectCharacterMenu:
                PrintSelectCharacterMenu();
                break;
            case GameState.QuestionMenu:
                PrintQuestionMenu();
                break;
            case GameState.Answer:
                PrintAnswer();
                break;
            case GameState.InventoryMenu:
                PrintInventoryMenu();
                break;
            case GameState.Leaderboard:
                PrintLeaderboard();
                break;
            default:
                Console.WriteLine("Unknown state. Please restart game.");
                break;
        }
    }

    private void PrintStartScreen()
    {
        Console.WriteLine(@"
        ,--.--------.   ,--.-,,-,--,       ,----.                  ___                      ,-,--.   ,--.--------.        ,----.                                           _,.---._          _,---.          ,--.--------.   ,--.-,,-,--,       ,----.  
/==/,  -   , -\ /==/  /|=|  |    ,-.--` , \          .-._ .'=.'\   ,--.-.  .-,--.  ,-.'-  _\ /==/,  -   , -\    ,-.--` , \   .-.,.---.    ,--.-.  .-,--.          ,-.' , -  `.     .-`.' ,  \        /==/,  -   , -\ /==/  /|=|  |    ,-.--` , \ 
\==\.-.  - ,-./ |==|_ ||=|, |   |==|-  _.-`         /==/ \|==|  | /==/- / /=/_ /  /==/_ ,_.' \==\.-.  - ,-./   |==|-  _.-`  /==/  `   \  /==/- / /=/_ /          /==/_,  ,  - \   /==/_  _.-'        \==\.-.  - ,-./ |==|_ ||=|, |   |==|-  _.-` 
`--`\==\- \    |==| ,|/=| _|   |==|   `.-.         |==|,|  / - | \==\, \/=/. /   \==\  \     `--`\==\- \      |==|   `.-. |==|-, .=., | \==\, \/=/. /          |==|   .=.     | /==/-  '..-.         `--`\==\- \    |==| ,|/=| _|   |==|   `.-. 
    \==\_ \   |==|- `-' _ |  /==/_ ,    /         |==|  \/  , |  \==\  \/ -/     \==\ -\         \==\_ \    /==/_ ,    / |==|   '='  /  \==\  \/ -/           |==|_ : ;=:  - | |==|_ ,    /              \==\_ \   |==|- `-' _ |  /==/_ ,    / 
    |==|- |   |==|  _     |  |==|    .-'          |==|- ,   _ |   |==|  ,_/      _\==\ ,\        |==|- |    |==|    .-'  |==|- ,   .'    |==|  ,_/            |==| , '='     | |==|   .--'               |==|- |   |==|  _     |  |==|    .-'  
    |==|, |   |==|   .-. ,\  |==|_  ,`-._         |==| _ /\   |   \==\-, /      /==/\/ _ |       |==|, |    |==|_  ,`-._ |==|_  . ,'.    \==\-, /              \==\ -    ,_ /  |==|-  |                  |==|, |   |==|   .-. ,\  |==|_  ,`-._ 
    /==/ -/   /==/, //=/  |  /==/ ,     /         /==/  / / , /   /==/._/       \==\ - , /       /==/ -/    /==/ ,     / /==/  /\ ,  )   /==/._/                '.='. -   .'   /==/   \                  /==/ -/   /==/, //=/  |  /==/ ,     / 
    `--`--`   `--`-' `-`--`  `--`-----``          `--`./  `--`    `--`-`         `--`---'        `--`--`    `--`-----``  `--`-`--`--'    `--`-`                   `--`--''     `--`---'                  `--`--`   `--`-' `-`--`  `--`-----``  
                ,---.                        _,.---._      .-._          .--.-.     ,-,--.                          ,---.                          _,---.    ,--.-,,-,--,  ,--.--------.        ,----.                                          
    _..---.    .--.'  \       .-.,.---.     ,-.' , -  `.   /==/ \  .-._  /==/  /   ,-.'-  _\          _,..---._    .--.'  \      .--.-. .-.-.   _.='.'-,  \  /==/  /|=|  | /==/,  -   , -\    ,-.--` , \   .-.,.---.                             
.' .'.-. \   \==\-/\ \     /==/  `   \   /==/_,  ,  - \  |==|, \/ /, / \==\ -\  /==/_ ,_.'        /==/,   -  \   \==\-/\ \    /==/ -|/=/  |  /==.'-     /  |==|_ ||=|, | \==\.-.  - ,-./   |==|-  _.-`  /==/  `   \                            
/==/- '=' /   /==/-|_\ |   |==|-, .=., | |==|   .=.     | |==|-  \|  |   \==\- \ \==\  \           |==|   _   _\  /==/-|_\ |   |==| ,||=| -| /==/ -   .-'   |==| ,|/=| _|  `--`\==\- \      |==|   `.-. |==|-, .=., |                           
|==|-,   '    \==\,   - \  |==|   '='  / |==|_ : ;=:  - | |==| ,  | -|    `--`-'  \==\ -\          |==|  .=.   |  \==\,   - \  |==|- | =/  | |==|_   /_,-.  |==|- `-' _ |       \==\_ \    /==/_ ,    / |==|   '='  /                           
|==|  .=. \   /==/ -   ,|  |==|- ,   .'  |==| , '='     | |==| -   _ |            _\==\ ,\         |==|,|   | -|  /==/ -   ,|  |==|,  \/ - | |==|  , \_.' ) |==|  _     |       |==|- |    |==|    .-'  |==|- ,   .'                            
/==/- '=' ,| /==/-  /\ - \ |==|_  . ,'.   \==\ -    ,_ /  |==|  /\ , |           /==/\/ _ |        |==|  '='   / /==/-  /\ - \ |==|-   ,   / \==\-  ,    (  |==|   .-. ,\       |==|, |    |==|_  ,`-._ |==|_  . ,'.                            
|==|   -   /  \==\ _.\=\.-' /==/  /\ ,  )   '.='. -   .'   /==/, | |- |           \==\ - , /        |==|-,   _`/  \==\ _.\=\.-' /==/ , _  .'   /==/ _  ,  /  /==/, //=/  |       /==/ -/    /==/ ,     / /==/  /\ ,  )                           
`-._`.___,'    `--`         `--`-`--`--'      `--`--''     `--`./  `--`            `--`---'         `-.`.____.'    `--`         `--`..---'     `--`------'   `--`-' `-`--`       `--`--`    `--`-----``  `--`-`--`--'                            
        " + "\n");
        Console.WriteLine(@"
The sun was shining brightly on the last day of June along the rugged coast of Rygland.
In the quaint town of Brandal, a former but important shipping hub for the copper trade which had dominated the region’s economy for centuries, the Richards family had gathered for their yearly get-together.

Their history ran deep in the region, but in recent years they had torn up their roots and dispersed throughout the country following what locally had become known as the Great Drought of 1957.
Unlike most droughts, this one had nothing to do with water supply.
The region had been stripped and bled dry of every single ounce of copper ore that once harbored in the ancient mountains along the valley.
The Richards had played an important part in the copper industry, but expanded elsewhere after the drought.

Somewhere higher up in the family, it had been decided to host this year’s get-together on the infamous Slitøya,
a small and luscious island about 15 nautical miles off the coast of Brandal.
The family had owned this island for generations but had largely abandoned its manor house and beautiful landscapes after the Great Drought.
This get-together marked the family’s first return to the region in over a decade.

For some, this return would evoke strong feelings of nostalgia; for others, unpleasant memories.
And for some, something much more sinister—and murderous—would be in store.

You are an old friend of Liz Richard, the oldest daughter of the late Baron Felix Richard and current heir of the family fortune.
Although you’ve maintained a friendly correspondence with Liz, you have not seen her for close to seven years,
when you both attended Rygland University together.
The invite, although kindheartedly accepted, came as a bit of a surprise.

In recent years, having grown tired of working the local beat as a cop,
you opened a private practice as a detective in the region's capital.
        ");
        Console.WriteLine("\nPress any key to continue...\n");
    }

    private void PrintToDoMenu()
    {
        Console.WriteLine(CurrentLocation.Image);
        Console.WriteLine(CurrentLocation.Description + "\n");
        Console.WriteLine("What would you like to do?\n");
        List<string> options = new List<string> {
                    "Move to another location",
                    "Examine the area",
                    "Talk to characters",
                    "Open inventory",
                    "Check leaderboard",
                };
        PrintSelectedOption(options);
    }

    private void PrintMoveMenu()
    {
        Console.WriteLine(CurrentLocation.Image);
        Console.WriteLine("Where would you like to go?\n");
        List<string> options = new List<string>() { "Cancel" };
        List<Location> locations = CurrentLocation.ConnectedLocations;
        foreach (Location location in locations)
        {
            options.Add(location.Name);
        }
        PrintSelectedOption(options);
    }

    private void PrintExamineMenu()
    {
        Console.WriteLine(CurrentLocation.Image);
        Console.WriteLine(CurrentLocation.ExamineDescription + "\n");
        if (CurrentLocation.Interactables.Count == 0)
        {
            Console.WriteLine("There is nothing to examine here.\n");
            Console.WriteLine("Press any key to continue...\n");
            return;
        }
        List<string> options = new List<string>() { "Cancel" };
        foreach (Item item in CurrentLocation.Interactables)
        {
            options.Add(item.Name);
        }
        PrintSelectedOption(options);
    }

    private void PrintItemInfo()
    {
        Console.WriteLine(GameModel.SelectedItem.Image);
        Console.WriteLine(GameModel.SelectedItem.Description + "\n");
        if (GameModel.SelectedItem.Obtainable && !GameModel.Detective.Inventory.Contains(GameModel.SelectedItem))
        {
            Console.WriteLine($"You have obtained {GameModel.SelectedItem.Name}.\n");
        }
        Console.WriteLine("Press any key to continue...\n");
    }

    private void PrintSelectCharacterMenu()
    {
        Console.WriteLine(CurrentLocation.Image);
        Console.WriteLine("Who would you like to talk to?\n");
        List<string> options = new List<string>() { "Cancel" };
        foreach (Character character in CurrentLocation.Characters)
        {
            options.Add(character.Name);
        }
        PrintSelectedOption(options);
    }

    private void PrintQuestionMenu()
    {
        Console.WriteLine(SelectedCharacter.Image);
        Console.WriteLine(SelectedCharacter.Description + "\n");
        List<string> options = new List<string>() { "Cancel" };
        foreach (Question question in SelectedQuestions)
        {
            options.Add(question.Text);
        }
        PrintSelectedOption(options);
    }

    private void PrintAnswer()
    {
        Console.WriteLine(SelectedCharacter.Image);
        Console.WriteLine(SelectedCharacter.Name + ": " + SelectedQuestion.Answer + "\n");
        Console.WriteLine("Press any key to continue...\n");
    }

    private void PrintInventoryMenu()
    {
        Console.WriteLine(Detective.Image);
        Console.WriteLine("Your inventory:\n");
        if (GameModel.Detective.Inventory.Count == 0)
        {
            Console.WriteLine("Your inventory is empty.\n");
            Console.WriteLine("Press any key to continue...\n");
            return;
        }
        List<string> options = new List<string>() { "Cancel" };
        foreach (Item item in GameModel.Detective.Inventory)
        {
            options.Add(item.Name);
        }
        PrintSelectedOption(options);
    }

    private void PrintLeaderboard()
    {
        try
        {
            List<Player> players = SupabaseFetcher.FetchLeaderboardSync(); // Ensure this method exists in SupabaseFetcher
            Console.WriteLine("Leaderboard:\n");
            if (players.Count == 0)
            {
                Console.WriteLine("No players found.\n");
                Console.WriteLine("Press any key to go back...\n");
                return;
            }
            foreach (Player player in players)
            {
                Console.WriteLine($"{player.Name}: {player.Score} points");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error fetching leaderboard...", ex.Message);
            Console.WriteLine("Press any key to go back...\n");
            return;
        }
    }

    private void PrintSelectedOption(List<string> options)
    {
        for (int i = 0; i < options.Count; i++)
        {
            if (i == CurrentOptionSelected)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"> {options[i]}");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine($"  {options[i]}");
            }
        }
    }
}