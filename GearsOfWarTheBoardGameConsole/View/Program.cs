using NAudio.Wave;
Thread musicThread;
CancellationTokenSource cancellationTokenSource;
CancellationToken cancellationToken;

string fullPath = AppDomain.CurrentDomain.BaseDirectory;
string JacintoPrisonString = Path.GetFullPath(Path.Combine(fullPath, @"../../..", "Music/JacintoPrison.mp3"));

MainMenu();
void MainMenu()
{
    SetupAudio(@"C:\Dev\VisualStudioCode\GearsOfWarTheBoardGameConsole\Music\14YearsAfterEDay.mp3");
    Console.WriteLine(@"                     ________                             ________   _____   __      __                ___________.__             __________                       .___   ________                          "); 
    Console.WriteLine(@"                    /  _____/  ____ _____ _______  ______ \_____  \_/ ____\ /  \    /  \_____ _______  \__    ___/|  |__   ____   \______   \ _________ _______  __| _/  /  _____/_____    _____   ____     ");
    Console.WriteLine(@"                    /   \  ____/ __ \\__  \\_  __ \/  ___/  /   |   \   __\  \   \/\/   /\__  \\_  __ \   |    |   |  |  \_/ __ \   |    |  _//  _ \__  \\_  __ \/ __ |  /   \  ___\__  \  /     \_/ __ \   ");
    Console.WriteLine(@"                    \    \_\  \  ___/ / __ \|  | \/\___ \  /    |    \  |     \        /  / __ \|  | \/   |    |   |   Y  \  ___/   |    |   (  <_> ) __ \|  | \/ /_/ |  \    \_\  \/ __ \|  Y Y  \  ___/   ");
    Console.WriteLine(@"                    \______  /\___  >____  /__|  /____  > \_______  /__|      \__/\  /  (____  /__|       |____|   |___|  /\___  >  |______  /\____(____  /__|  \____ |   \______  (____  /__|_|  /\___  >   ");
    Console.WriteLine(@"                           \/     \/     \/           \/          \/               \/        \/                        \/     \/          \/           \/           \/          \/     \/      \/     \/    ");
    Console.WriteLine(@"                                                             _________                            .__           _________                                    .__                                             ");
    Console.WriteLine(@"                                                             \_   ___ \  ____   ____   __________ |  |   ____   \_   ___ \  ____   _____ ___________    ____ |__| ____   ____                                 ");
    Console.WriteLine(@"                                                             /    \  \/ /  _ \ /    \ /  ___/  _ \|  | _/ __ \  /    \  \/ /  _ \ /     \\____ \__  \  /    \|  |/  _ \ /    \                                ");
    Console.WriteLine(@"                                                             \     \___(  <_> )   |  \\___ (  <_> )  |_\  ___/  \     \___(  <_> )  Y Y  \  |_> > __ \|   |  \  (  <_> )   |  \                               ");
    Console.WriteLine(@"                                                              \______  /\____/|___|  /____  >____/|____/\___  >  \______  /\____/|__|_|  /   __(____  /___|  /__|\____/|___|  /                                ");
    Console.WriteLine(@"                                                                     \/            \/     \/                \/          \/             \/|__|       \/     \/               \/                                 ");
    Console.WriteLine(@"                                                                                                                      _____                               ");
    Console.WriteLine(@"                                                                                                                     /  _  \ ______ ______              ");
    Console.WriteLine(@"                                                                                                                    /  /_\  \\____ \\____ \             ");
    Console.WriteLine(@"                                                                                                                   /    |    \  |_> >  |_> >               ");
    Console.WriteLine(@"                                                                                                                   \____|__  /   __/|   __/                ");
    Console.WriteLine(@"                                                                                                                           \/|__|   |__|                       ");


    Console.WriteLine("Main Menu");
    Console.WriteLine("1 - New Game");
    Console.WriteLine("2 - Load Game");
    Console.WriteLine("3 - Quit\n");

    switch (Console.ReadLine())
    {
        case "1":
        NewGame();
        break;
        case "2":
        LoadGame();
        break;
        case "3":
        QuitGame();
        break;
        default:
        MainMenu();
        break;
    }
}

void NewGame()
{
    int playerCount = SelectPlayerCount();
    Console.WriteLine("\n \n Select Your Mission: \n");
    Console.WriteLine("1- Emergence");
    Console.WriteLine("2- China Shop");
    Console.WriteLine("3- Emergence Hive");
    Console.WriteLine("4- Scattered Roadblocks");
    Console.WriteLine("5- Horde Mode");
    Console.WriteLine("\nMission Pack 1:");
    Console.WriteLine("7- The Showdown");
    Console.WriteLine("8- Search For The Stranded");
    Console.WriteLine("9- Back To Main Menu\n");

    switch (Console.ReadLine())
    {
        case "1":
        cancellationTokenSource.Cancel();
        musicThread.Join();
        SetupAudio(JacintoPrisonString);
        EmergenceMissionOne missionStartOne = new(playerCount, 1);
        break;
        case "2":
        cancellationTokenSource.Cancel();
        musicThread.Join();
        SetupAudio(@"C:\Dev\VisualStudioCode\GearsOfWarTheBoardGameConsole\Music\TombsOfTheUnknowns.mp3");
        ChinaShopMissionTwo missionStartTwo = new(playerCount, 2);
        break;
        case "3":
        break;
        case "4":
        break;
        case "5":
        break;
        case "7":
        cancellationTokenSource.Cancel();
        musicThread.Join();
        SetupAudio(@"C:\Dev\VisualStudioCode\GearsOfWarTheBoardGameConsole\Music\TrainRideToHell.mp3");
        TheShowDownMissionPackOne missionStartSeven = new(playerCount, 7);
        break;
        case "8":
        cancellationTokenSource.Cancel();
        musicThread.Join();
        SetupAudio(@"C:\Dev\VisualStudioCode\GearsOfWarTheBoardGameConsole\Music\EphyraStreet.mp3");
        SearchForTheStrandedMisisonPackOne missionStartEight = new(playerCount, 8);
        break;
        case "9":
        MainMenu();
        break;
        default:
        NewGame();
        break;
    }
    TerminateMisison();
}

void LoadGame()
{
    Console.WriteLine("Upcoming feature to be released in the future! \n \n");
    MainMenu();
}

void TerminateMisison()
{
    cancellationTokenSource.Cancel();
    musicThread.Join();
    Console.WriteLine("Would you like to save your progress Y/N? (Feature to be included later)");
    switch (Console.ReadLine().ToUpper())
    {
        case "Y":
        break;
        case "N":
        MainMenu();
        break;
        default:
        TerminateMisison();
        break;
    }
}

void PlayMusicOnNewthread(CancellationToken cancellationToken, string trackFilePath)
    {
        // Path to the audio file
        string audioFilePath = trackFilePath;

        // Create a WaveOutEvent for audio playback
        using (WaveOutEvent waveOut = new WaveOutEvent())
        {
            // Create a WaveFileReader to read the audio file
            using (Mp3FileReader reader = new (audioFilePath))
            {
                // Initialize WaveOutEvent with WaveFileReader
                waveOut.Init(reader);

                // Start audio playback
                waveOut.Play();

                // Wait for cancellation request or end of audio playback
                while (!cancellationToken.IsCancellationRequested && waveOut.PlaybackState == PlaybackState.Playing)
                {
                    Thread.Sleep(100); // Sleep for a short duration before checking cancellation
                }
                // Stop audio playback if it's still playing
                if (waveOut.PlaybackState == PlaybackState.Playing)
                {
                    waveOut.Stop();
                }
            }
        }
    }

int SelectPlayerCount()
{
    Console.WriteLine("\nHow many players?\n");
    Console.WriteLine("1");
    Console.WriteLine("2");
    Console.WriteLine("3");
    Console.WriteLine("4");
    Console.WriteLine("5- Back To Main Menu\n");

    switch (Console.ReadLine())
    {
        case "1":
        return 1;
        case "2":
        return 2;
        case "3":
        return 3;
        case "4":
        return 4;
        case "5":
        MainMenu();
        break;
        default:
        SelectPlayerCount();
        break;
    }
    return 1;
}

void SetupAudio(string audioLocation)
{
    cancellationTokenSource = new();
    cancellationToken = cancellationTokenSource.Token;
    musicThread = new Thread(() => PlayMusicOnNewthread(cancellationToken, audioLocation));
    musicThread.Start();
}

static void QuitGame() => Environment.Exit(1);