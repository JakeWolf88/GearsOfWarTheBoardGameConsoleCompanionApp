using GearsOfWarTheBoardGameConsole.Model;
using GearsOfWarTheBoardGameConsole.View.Missions;
using NAudio.Wave;

Thread musicThread;
CancellationTokenSource cancellationTokenSource;
CancellationToken cancellationToken;
string fullPath = AppDomain.CurrentDomain.BaseDirectory;
string JacintoPrisonString = Path.GetFullPath(Path.Combine(fullPath, @"../../..", "Music/JacintoPrison.mp3"));

SetupAudio(@"C:\Dev\VisualStudioCode\GearsOfWarTheBoardGameConsole\Music\14YearsAfterEDay.mp3");
MainMenu();

void MainMenu()
{
    if (!musicThread.IsAlive)
    {
        SetupAudio(@"C:\Dev\VisualStudioCode\GearsOfWarTheBoardGameConsole\Music\14YearsAfterEDay.mp3");
    }

    Console.WriteLine(@"                     ________                             ________   _____   __      __                ___________.__             __________                       .___   ________                             "); 
    Console.WriteLine(@"                    /  _____/  ____ _____ _______  ______ \_____  \_/ ____\ /  \    /  \_____ _______  \__    ___/|  |__   ____   \______   \ _________ _______  __| _/  /  _____/_____    _____   ____        ");
    Console.WriteLine(@"                    /   \  ____/ __ \\__  \\_  __ \/  ___/  /   |   \   __\  \   \/\/   /\__  \\_  __ \   |    |   |  |  \_/ __ \   |    |  _//  _ \__  \\_  __ \/ __ |  /   \  ___\__  \  /     \_/ __ \      ");
    Console.WriteLine(@"                    \    \_\  \  ___/ / __ \|  | \/\___ \  /    |    \  |     \        /  / __ \|  | \/   |    |   |   Y  \  ___/   |    |   (  <_> ) __ \|  | \/ /_/ |  \    \_\  \/ __ \|  Y Y  \  ___/      ");
    Console.WriteLine(@"                    \______  /\___  >____  /__|  /____  > \_______  /__|      \__/\  /  (____  /__|       |____|   |___|  /\___  >  |______  /\____(____  /__|  \____ |   \______  (____  /__|_|  /\___  >     ");
    Console.WriteLine(@"                           \/     \/     \/           \/          \/               \/        \/                         \/     \/          \/           \/           \/          \/     \/      \/     \/      ");
    Console.WriteLine(@"                                                             _________                            .__           _________                                    .__                                               ");
    Console.WriteLine(@"                                                             \_   ___ \  ____   ____   __________ |  |   ____   \_   ___ \  ____   _____ ___________    ____ |__| ____   ____                                  ");
    Console.WriteLine(@"                                                             /    \  \/ /  _ \ /    \ /  ___/  _ \|  | _/ __ \  /    \  \/ /  _ \ /     \\____ \__  \  /    \|  |/  _ \ /    \                                 ");
    Console.WriteLine(@"                                                             \     \___(  <_> )   |  \\___ (  <_> )  |_\  ___/  \     \___(  <_> )  Y Y  \  |_> > __ \|   |  \  (  <_> )   |  \                                ");
    Console.WriteLine(@"                                                              \______  /\____/|___|  /____  >____/|____/\___  >  \______  /\____/|__|_|  /   __(____  /___|  /__|\____/|___|  /                                ");
    Console.WriteLine(@"                                                                     \/            \/     \/                \/          \/             \/|__|       \/     \/               \/                                 ");
    Console.WriteLine(@"                                                                                                                      _____                                                                                    ");
    Console.WriteLine(@"                                                                                                                     /  _  \ ______ ______                                                                     ");
    Console.WriteLine(@"                                                                                                                    /  /_\  \\____ \\____ \                                                                    ");
    Console.WriteLine(@"                                                                                                                   /    |    \  |_> >  |_> >                                                                   ");
    Console.WriteLine(@"                                                                                                                   \____|__  /   __/|   __/                                                                    ");
    Console.WriteLine(@"                                                                                                                           \/|__|   |__|                                                                       ");
    Console.WriteLine("                                                                                                                                                                                                              \n");

    Console.WriteLine("Main Menu");
    Console.WriteLine("1 - Base Missions");
    Console.WriteLine("2 - Mission Pack 1");
    Console.WriteLine("3 - Community Missions");
    Console.WriteLine("4 - FAQS");
    Console.WriteLine("5 - Quit\n\n\n");

    switch (Console.ReadLine())
    {
        case "1":
        BaseMissions();
        break;
        case "2":
        MissionPackOne();
        break;
        case "4":
            FaqMainMenu();
            break;
        case "5":
        QuitGame();
        break;
        default:
        MainMenu();
        break;
    }
}

void BaseMissions()
{
    int playerCount = SelectPlayerCount();
    Console.WriteLine("\n \n Select Your Mission: \n");
    Console.WriteLine("1- Emergence");
    Console.WriteLine("2- China Shop");
    Console.WriteLine("3- Belly Of The Beast");
    Console.WriteLine("4- Roadblocks");
    if (playerCount is not 1)
    {
        Console.WriteLine("5- Scattered");
    }
    Console.WriteLine("6- Hive");
    Console.WriteLine("7- Horde Mode\n");
    Console.WriteLine("8- Back To Main Menu\n");

    switch (Console.ReadLine())
    {
        case "1":
        cancellationTokenSource.Cancel();
        musicThread.Join();
        EmergenceMissionOne missionStartOne = new(playerCount, 1);
        break;
        case "2":
        cancellationTokenSource.Cancel();
        musicThread.Join();
        ChinaShopMissionTwo missionStartTwo = new(playerCount, 2);
        break;
        case "3":
        cancellationTokenSource.Cancel();
        musicThread.Join();
        BellyOfTheBeastMissionThree missionStartThree = new(playerCount, 3);
        break;
        case "4":
            cancellationTokenSource.Cancel();
            musicThread.Join();
        RoadBlocksMissionFour missionStartFour = new(playerCount, 4);
        break;
        case "5":
            if (playerCount is not 1)
            {
                cancellationTokenSource.Cancel();
                musicThread.Join();
                ScatteredMissionFive missionStartFive = new(playerCount, 5);
            }
            else
            {
                BaseMissions();
            }
            break;
        case "6":
            cancellationTokenSource.Cancel();
            musicThread.Join();
            HiveMissionSix missionStartSix = new(playerCount, 6);
            break;
        case "7":
            cancellationTokenSource.Cancel();
            musicThread.Join();
            HordeModeMissionSeven missionStartSeven = new(playerCount, 7);
            break;
        case "8":
        MainMenu();
        break;
        default:
        BaseMissions();
        break;
    }
    MainMenu();
}

void MissionPackOne()
{
    int playerCount = SelectPlayerCount();
    Console.WriteLine("\n \n Select Your Mission: \n");
    Console.WriteLine("1- The Showdown");
    Console.WriteLine("2- Search For The Stranded");
    Console.WriteLine("3- Back To Main Menu\n");

    switch (Console.ReadLine())
    {
        case "1":
            StopAudio();
            SetupAudio(@"C:\Dev\VisualStudioCode\GearsOfWarTheBoardGameConsole\Music\TrainRideToHell.mp3");
            TheShowDownMissionPackOne missionStartEight = new(playerCount, 8);
            break;
        case "2":
            StopAudio();
            SetupAudio(@"C:\Dev\VisualStudioCode\GearsOfWarTheBoardGameConsole\Music\EphyraStreet.mp3");
            SearchForTheStrandedMisisonPackOne missionStartNine = new(playerCount, 9);
            break;
        case "3":
            MainMenu();
            break;
        default:
            MissionPackOne();
            break;
    }
    MainMenu();
}

void FaqMainMenu()
{
    Console.WriteLine("\nWhich page would you like to view?\n");
    Console.WriteLine("1 - FAQ version 1.1 update");
    Console.WriteLine("2 - Single Player Rules");
    Console.WriteLine("3 - Insane difficulty rules");
    Console.WriteLine("4 - Mission Pack 1 FAQs\n");
    Console.WriteLine("5 - Back to Main Menu\n");
#pragma warning disable CS8602 // Dereference of a possibly null reference.
    switch (Console.ReadLine().ToUpper())
    {
        case "1":
            Faq.FaqVersionOnePointOne();
            break;
        case "2":
            Faq.SinglePlayerRules();
            break;
        case "3":
            Faq.InsaneDifficultyRules();
            break;
        case "4":
            Faq.MissionPackOneFaqs();
            break;
        case "5":
            StopAudio();
            MainMenu();
            return;
        default:
            FaqMainMenu();
            break;
    }
#pragma warning restore CS8602 // Dereference of a possibly null reference.

    Console.WriteLine("Press Y to continue");
#pragma warning disable CS8602 // Dereference of a possibly null reference.
    switch (Console.ReadLine().ToUpper())
    {
        case "Y":
            FaqMainMenu();
            break;
        default:
            FaqMainMenu();
            break;
    }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
}

async Task PlayMusicOnNewthread(string audioFilePath, CancellationToken cancellationToken)
{
    while (!cancellationToken.IsCancellationRequested)
    {
        using (var waveOut = new WaveOutEvent())
        using (var audioFileReader = new AudioFileReader(audioFilePath))
        {
            waveOut.Init(audioFileReader);

            // TaskCompletionSource to signal completion of playback
            var playbackCompleted = new TaskCompletionSource<bool>();

            // Hook up the PlaybackStopped event
            waveOut.PlaybackStopped += (sender, eventArgs) =>
            {
                // When playback is stopped, set the TaskCompletionSource result
                playbackCompleted.SetResult(true);
            };

            // Start playback
            waveOut.Play();

            // Wait for playback to complete or cancellation to be requested
            await Task.WhenAny(playbackCompleted.Task, Task.Delay(-1, cancellationToken));

            // If cancellation is requested, stop playback
            if (cancellationToken.IsCancellationRequested)
            {
                waveOut.Stop();
                return;
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
    musicThread = new Thread(async () => await PlayMusicOnNewthread(audioLocation, cancellationToken));
    musicThread.Start();
}

void StopAudio()
{
    cancellationTokenSource.Cancel();
    musicThread.Join();
}

static void QuitGame() => Environment.Exit(1);