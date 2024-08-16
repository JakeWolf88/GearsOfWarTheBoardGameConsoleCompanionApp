using System.Diagnostics;

public abstract class GearsOfWarMission
{
    #region Private Fields
    private List<LocustAiCard>? _missionLocustAiCardDeck;
    private List<List<LocationCard>>? _missionLocationCardDeck;
    private int _missionNumber;
    private bool _isLocustPcPlaying;
    private int _numberOfPlayers;
    private CancellationToken cancellationToken;
    private AudioPlayer _audioPlayer;
    private Thread? musicThread;
    private Random random = new Random();
    #endregion Private Fields

    #region Constructor

    public GearsOfWarMission(int numberOfPlayers, int missionNumber)
    {
        _numberOfPlayers = numberOfPlayers;
        _missionNumber = missionNumber;
        _audioPlayer = new();
    }
    #endregion Constructor

    #region Public Properties

    public bool IsLocustPcPlaying { get; set; }

    public List<LocustAiCard>? MissionLocustAiCardDeck { get; set; }
    
    public List<LocationCard>? MissionLocationCardDeck { get; set; }

    public CancellationTokenSource? CancellationTokenSource { get; set; }

    public bool IsGameStillGoing { get; set; }

    public Stopwatch? Stopwatch { get; set; }

    public static string BasePath => AppDomain.CurrentDomain.BaseDirectory;

    #endregion Public Properties

    #region Public Methods

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

    void Shuffle<T>(List<T> list)
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

            if (_missionNumber is 5 && levelStage is 3)
            {
                Console.WriteLine($"Enemies spawned: (See text) \n\n");
            }

            if (_missionNumber is 5 && levelStage is not 3)
            {
                switch (_numberOfPlayers)
                {
                    case 2:
                        Console.WriteLine($"Enemies spawned: {mission.Enemies[0]} \n\n");
                        break;
                    case 3:
                        Console.WriteLine($"Enemies spawned: For solo player on level: {mission.Enemies[0]} For two players on level: {mission.Enemies[1]} \n\n");
                        break;
                    default:
                        Console.WriteLine($"Enemies spawned: {mission.Enemies[1]} \n\n");
                        break;
                }
            }
            else
            {
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
    }

    public void DisplayLocustAiCard(int stageNumber)
    {
        CheckIfDeckShouldBeShuffled(stageNumber);

        Console.WriteLine("_______________________");
        Console.WriteLine("|                     |");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"  {_missionLocustAiCardDeck[0].Banner}");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(_missionLocustAiCardDeck[0].PrimaryAttack);
        Console.WriteLine(_missionLocustAiCardDeck[0].OtherWiseAttack);
        Console.WriteLine("|                     |");
        Console.WriteLine("=======================");

        PlayLocustSound(_missionLocustAiCardDeck[0].LocustSounds);


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

    private async void PlayLocustSound(List<String> testList)
    {
        int randomNumberOdd = random.Next(0, 3);
        int randomNumber = random.Next(0, 10000);

        if (randomNumberOdd == 0) 
        {
            if (testList.Count > 0)
            {
                await Task.Delay(randomNumber);
                Shuffle(testList);
                SetupAudioOneTime(BasePath + @"\Music\LocustSounds\" + testList[0]);
            }
        }
    }

    private void CheckIfDeckShouldBeShuffled(int stagenumber)
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
            CreateLocustAiCardDeck(stagenumber);
            Shuffle(_missionLocustAiCardDeck);
        }
    }

    public void AskIfSecondActionIsNeeded(int stageNumber)
    {
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
                if (CancellationTokenSource is not null)
                {
                    CancellationTokenSource.Cancel();
                }
                return;
            default:
                WaitForGameToEnd();
                break;
        }
    }

    public void SetupAudioContinually(string audioLocation)
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

    public void SetupAudioOneTime(string audioLocation)
    {
        //TODO: Call Dispose Method on music objects. 
        if (musicThread is not null)
        {
            musicThread.Join();
        }
        musicThread = new Thread(() => _audioPlayer.PlayAudioOnce(audioLocation));
        musicThread.Start();
    }

    public void CancelMusic()
    {
        if (CancellationTokenSource is not null)
        {
            CancellationTokenSource.Cancel();
        }
    }

    public void GameOver()
    {
        Console.WriteLine("\nAre you sure all players are bleeding out Y/N?");
        switch (Console.ReadLine().ToUpper())
        {
            case "Y":
                if (CancellationTokenSource is not null)
                {
                    CancellationTokenSource.Cancel();
                }
                Console.WriteLine("\nGAME OVER!!!!!");
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

    #endregion Public Methods
}