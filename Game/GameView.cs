public class GameView
{
    private GameModel GameModel;
    private List<string> PrintQueue;
    private Location CurrentLocation => GameModel.LocationModel.CurrentLocation;

    public GameView(GameModel gameModel)
    {
        this.GameModel = gameModel;
        PrintQueue = new List<string>();
    }

    public void Print()
    {
        if (OperatingSystem.IsWindows())
        {
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
        }
        Console.Clear();

        Console.WriteLine(GameModel.LocationModel.CurrentLocation.Image);
        foreach (var line in PrintQueue)
        {
            Console.WriteLine(line);
        }
        Console.WriteLine("\n");
        PrintQueue.Clear();
    }

    public void AddToPrintQueue(string text)
    {
        PrintQueue.Add(text);
    }

    public void PrintInvalidInput()
    {
        Console.WriteLine("Invalid input. Please try again.");
    }

    public void PrintStartScreen()
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
        ");
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
        Console.WriteLine("Press any key to continue...\n");
    }

    public void PrintLocationMenu(bool visited)
    {
        if (!visited)
        {
            AddToPrintQueue(CurrentLocation.Description);
            visited = true;
        }
        AddToPrintQueue("What would you like to do?\n");
        AddToPrintQueue("1. Move to another location");
        AddToPrintQueue("2. Examine the location");
        if (CurrentLocation.Characters != null && CurrentLocation.Characters.Count > 0)
        {
            AddToPrintQueue("3. Talk to a character");
        }
        Print();
    }

    public void PrintMoveMenu()
    {
        AddToPrintQueue("Where would you like to go?\n");
        AddToPrintQueue($"0. Cancel");
        for (int i = 0; i < CurrentLocation.ConnectedLocations.Count; i++)
        {
            AddToPrintQueue($"{i + 1}. {CurrentLocation.ConnectedLocations[i].Name}");
        }
        Print();
    }

    public void PrintExamineMenu()
    {
        AddToPrintQueue(CurrentLocation.ExamineDescription);
        if (CurrentLocation.Interactables.Count == 0)
        {
            AddToPrintQueue("There is nothing to examine here.\n");
            AddContinue();
            Print();
            return;
        }
        AddToPrintQueue("What would you like to examine\n");
        AddToPrintQueue($"0. Cancel");
        for (int i = 0; i < CurrentLocation.Interactables.Count; i++)
        {
            AddToPrintQueue($"{i + 1}. {CurrentLocation.Interactables[i].Name}");
        }
        Print();
    }

    public void PrintItemInfo(Item item)
    {
        AddToPrintQueue(item.Description + "\n");
        if (item.Obtainable)
        {
            AddToPrintQueue($"You have obtained {item.Name}.\n");
        }
        AddToPrintQueue("Press any key to continue...");
        Print();
    }

    public void PrintCharacterMenu()
    {
        AddToPrintQueue("Who would you like to talk to?\n");
        AddToPrintQueue($"0. Cancel");
        for (int i = 0; i < CurrentLocation.Characters.Count; i++)
        {
            AddToPrintQueue($"{i + 1}. {CurrentLocation.Characters[i].Name}");
        }
        Print();
    }

    public void PrintCharacterDescription(Character character)
    {
        AddToPrintQueue(character.Description + "\n");
        Print();
    }

    public void PrintQuestionMenu(List<Question> questions)
    {
        AddToPrintQueue("What would you like to ask?\n");
        AddToPrintQueue($"0. Cancel");
        for (int i = 0; i < questions.Count; i++)
        {
            AddToPrintQueue($"{i + 1}. {questions[i].Text}");
        }
        Print();
    }

    public void PrintAnswer(string name, string answer)
    {
        AddToPrintQueue(name + ": " + answer + "\n");
        AddToPrintQueue("Press any key to continue...");
        Print();
    }

    public void AddContinue()
    {
        AddToPrintQueue("Press any key to continue...");
    }
}