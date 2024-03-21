public abstract class GearsOfWarMission
{
    private List<LocustAiCard> _missionLocustAiCardDeck;
    private List<List<LocationCard>> _missionLocationCardDeck;
    int _missionNumber;
    private int _playerInterator;
    private bool _isLocustPcPlaying;
    private int _numberOfPlayers;

    public GearsOfWarMission(int numberOfPlayers, int missionNumber)
    {
        _numberOfPlayers = numberOfPlayers;
        _playerInterator = 1;
        _missionNumber = missionNumber;

    }

    public bool IsLocustPcPlaying { get; set; }

    public List<LocustAiCard> MissionLocustAiCardDeck { get; set; }
    
    public List<LocationCard> MissionLocationCardDeck { get; set; }


    public void SetupMission()
    {
        Console.WriteLine("Would you like the computer to draw AI Locust cards? Y/N");
        switch (Console.ReadLine().ToUpper())
        {
            case "Y":
            CreateLocustAiCardDeck(1);
            IsLocustPcPlaying = true;
            break;
            case "N":
            IsLocustPcPlaying = false;
            break;
            default:
            SetupMission();
            break;
        }
    }


    public void CreateLocustAiCardDeck(int stageNumber)
    {
        _missionLocustAiCardDeck = new LocustAiCardDeck(_missionNumber, stageNumber).MissionLocustAiCardDeck;
        Shuffle(_missionLocustAiCardDeck);
    }

    static void Shuffle<T>(List<T> list)
    {
        Random rng = new Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    public void CreateLocationCardDeck()
    {
        _missionLocationCardDeck = new LocationCardDeck(_missionNumber).MissionLocationCardDeck;
        foreach (List<LocationCard> item in _missionLocationCardDeck)
        {
            Shuffle(item);
        }
        DisplayLocationCardDeck(0);
    }

    public void DisplayLocationCardDeck(int levelStage)
    {
         Console.WriteLine($"          STAGE {levelStage} LOCATION SETUP: \n\n");
        foreach(LocationCard mission in _missionLocationCardDeck[levelStage])
        {
            Console.WriteLine($"      -------------");
            Console.WriteLine($"      |    {mission.Name}    |");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n{mission.Title}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"\n{mission.Description} \n");
            switch (_numberOfPlayers)
            {
                case 1:
                Console.Write($" Enemies spawned: {mission.Enemies[0]} \n\n");
                break;
                case 2:
                Console.WriteLine($"Enemies spawned: {mission.Enemies[1]} \n\n");
                break;
                case 3:
                Console.WriteLine($"Enemies spawned: {mission.Enemies[2]} \n\n");
                break;
                default:
                Console.WriteLine($"Enemies spawned: {mission.Enemies[3]} \n\n");
                break;
            }
        }
    }

    public void DisplayLocustAiCard(int stageNumber)
    {
        if (_missionLocustAiCardDeck.Count.Equals(0))
        {
            Console.WriteLine("Re-shuffle deck");
            CreateLocustAiCardDeck(stageNumber);
            Shuffle(_missionLocustAiCardDeck);
        }
        Console.WriteLine("_______________________");
        Console.WriteLine("|                     |");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"  {_missionLocustAiCardDeck[0].Banner}");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(_missionLocustAiCardDeck[0].PrimaryAttack);
        Console.WriteLine(_missionLocustAiCardDeck[0].OtherWiseAttack);
        Console.WriteLine("|                     |");
        Console.WriteLine("=======================");

        if (_missionLocustAiCardDeck[0].HasASecondDraw)
        {
            _missionLocustAiCardDeck.RemoveAt(0);
            AskIfSecondActionIsNeeded(stageNumber);
        }
        else
        {
            _missionLocustAiCardDeck.RemoveAt(0);
        }
    }

    public void AskIfSecondActionIsNeeded(int stageNumber)
    {
        //TODO: create a new switch return statement
        Console.WriteLine("\nDoes card require another action? Y/N?");
        switch (Console.ReadLine().ToUpper())
        {
            case "Y":
            DisplayLocustAiCard(stageNumber);
            break;
            case "N":
            return;
            default:
            AskIfSecondActionIsNeeded(stageNumber);
            break;
        }
    }

    public void WaitForTurnToComplete()
    {
        Console.WriteLine("Press 'Y' when turn is complete");
        switch (Console.ReadLine().ToUpper())
        {
            case "Y":
            return;
            default:
            WaitForTurnToComplete();
            break;
        }
    }


















}