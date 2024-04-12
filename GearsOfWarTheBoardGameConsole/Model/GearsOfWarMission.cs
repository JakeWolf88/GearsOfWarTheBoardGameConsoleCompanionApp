using System;
using System.Diagnostics;

public abstract class GearsOfWarMission
{
    private List<LocustAiCard> _missionLocustAiCardDeck;
    private List<List<LocationCard>> _missionLocationCardDeck;
    int _missionNumber;
    private int _playerInterator;
    private bool _isLocustPcPlaying;
    private int _numberOfPlayers;
    //private CancellationTokenSource cancellationTokenSource;
    private CancellationToken cancellationToken;
    private AudioPlayer _audioPlayer;
    private Thread musicThread;

    public GearsOfWarMission(int numberOfPlayers, int missionNumber)
    {
        _numberOfPlayers = numberOfPlayers;
        _missionNumber = missionNumber;
        _audioPlayer = new();
        _playerInterator = 1;
    }

    public bool IsLocustPcPlaying { get; set; }

    public List<LocustAiCard> MissionLocustAiCardDeck { get; set; }
    
    public List<LocationCard> MissionLocationCardDeck { get; set; }

    public CancellationTokenSource CancellationTokenSource { get; set; }

    public bool IsGameStillGoing { get; set; }

    public Stopwatch Stopwatch { get; set; }



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
         Console.WriteLine($"          Level {levelStage + 1} LOCATION SETUP: \n\n");
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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"           ________                   __          _________.__              _____   _____ .__               .___  ");
            Console.WriteLine(@"           \______ \    ____   ____  |  | __     /   _____/|  |__   __ __ _/ ____\_/ ____\|  |    ____    __| _/   ");
            Console.WriteLine(@"            |    |  \ _/ __ \_/ ___\ |  |/ /     \_____  \ |  |  \ |  |  \\   __\ \   __\ |  |  _/ __ \  / __ |         ");
            Console.WriteLine(@"            |    `   \\  ___/\  \___ |    <      /        \|   Y  \|  |  / |  |    |  |   |  |__\  ___/ / /_/ |          ");
            Console.WriteLine(@"           /_______  / \___  >\___  >|__|_ \    /_______  /|___|  /|____/  |__|    |__|   |____/ \___  >\____ |        ");
            Console.WriteLine(@"                   \/      \/     \/      \/            \/      \/                                   \/      \/       ");
            Console.ForegroundColor = ConsoleColor.White;
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
        Console.WriteLine("Press 'Y' when turn is complete or 'Q' if all players are bleeding out");
        switch (Console.ReadLine().ToUpper())
        {
            case "Y":
            return;
            case "Q":
                GameOver();
                break;
            default:
            WaitForTurnToComplete();
            break;
        }
    }

    public void WaitForGameToEnd()
    {
        Stopwatch.Stop();
        TimeSpan timeSpawn = TimeSpan.FromMilliseconds(Stopwatch.ElapsedMilliseconds);
        Console.WriteLine($"Total time played: {timeSpawn.Hours} hrs {timeSpawn.Minutes} min {timeSpawn.Seconds} sec");
        Console.WriteLine("Press 'Y' to return to main menu");
        switch (Console.ReadLine().ToUpper())
        {
            case "Y":
                CancellationTokenSource.Cancel();
                return;
            default:
                WaitForGameToEnd();
                break;
        }
    }

    public void SetupAudio(string audioLocation)
    {
        if (musicThread is not null)
        {
            musicThread.Join();
        }
        CancellationTokenSource = new();
        cancellationToken = CancellationTokenSource.Token;
        musicThread = new Thread(async () => await _audioPlayer.PlayAudio(audioLocation, cancellationToken));
        musicThread.Start();
    }

    public void GameOver()
    {
        Console.WriteLine("\nAre you sure all players are bleeding out Y/N?");
        switch (Console.ReadLine().ToUpper())
        {
            case "Y":
                Console.WriteLine("GAME OVER!!!!!");
                IsGameStillGoing = false;
                Stopwatch.Stop();
                TimeSpan timeSpawn = TimeSpan.FromMilliseconds(Stopwatch.ElapsedMilliseconds);
                Console.WriteLine($"Total time played: {timeSpawn.Hours} hrs {timeSpawn.Minutes} min {timeSpawn.Seconds} sec");
                break;
            case "N":
                return;
            default:
                break;
        }
        Console.WriteLine("All players are bleeding out! Game over! ");
    }

    public void StartTimer()
    {
        Stopwatch = new();
        Stopwatch.Start();
    }







}