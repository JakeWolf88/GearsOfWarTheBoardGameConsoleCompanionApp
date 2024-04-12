using System.Diagnostics;

class EmergenceMissionOne : GearsOfWarMission
{
    private int _playerInterator = 1;
    private int _numberOfPlayers;
    private bool _isStageOneActivated;
    private bool _isStageTwoActivated;

    public EmergenceMissionOne(int numberOfPlayers, int missionNumber) : base(numberOfPlayers, missionNumber)
    {
        _numberOfPlayers = numberOfPlayers;
        _isStageOneActivated = true;
        IsGameStillGoing = true;
        SetupAudio(@"C:\Dev\VisualStudioCode\GearsOfWarTheBoardGameConsole\Music\JacintoPrison.mp3");
        MissionSpecifics();
        CreateLocationCardDeck();
        StartTimer();
        StartMission();
    }

    private void StartMission()
    {
        SetupMission();
        MissionSetup();

        while (IsGameStillGoing)
        {
            CogTurn();
            LocustTurn();
        }
    }

    private void CogTurn()
    {
        Console.WriteLine("COG player's turn:");
        if (_isStageOneActivated)
        {
            StageOneBanner();
        }
        else
        {
            StageTwoBanner();
        }
        Console.WriteLine($"Player {_playerInterator}'s turn");
        StageActivationPrompt();
        if (_playerInterator == _numberOfPlayers)
        {
            _playerInterator = 0;
        }
        _playerInterator++;
    }

    private void LocustTurn()
    {
        if (!IsGameStillGoing)
        {
            return;
        }
        Console.WriteLine("\nLocust turn:");
        if (IsLocustPcPlaying)
        {
            DisplayLocustAiCard(1);
        }

        WaitForTurnToComplete();
    }


    private void StageActivationPrompt()
    {
        if (_isStageOneActivated)
        {
            Console.WriteLine("\nHave all emergence holes been sealed? Y/N?");

            switch (Console.ReadLine().ToUpper())
            {
                case "Y":
                _isStageOneActivated = false;
                _isStageTwoActivated = true;
                StageOneEnd();
                break;
                case "N":
                break; 
                default:
                StageActivationPrompt();
                break;
            }
        }

        if (_isStageTwoActivated)
        {
            Console.WriteLine("\nAre there zero locust figures in play Y/N?");

            switch (Console.ReadLine().ToUpper())
            {
                case "Y":
                _isStageTwoActivated = false;
                IsGameStillGoing = false;
                MissionEnd();
                break;
                case "N":
                break; 
                default:
                StageActivationPrompt();
                break;
            }
        }
    }

    private void MissionSetup()
    {
        Console.WriteLine("\nMission Setup\n");
        Console.WriteLine("Special Rules:\n");
        Console.WriteLine("After setting up the map, cover ");
        Console.WriteLine("each emergence hole with a ");
        Console.WriteLine("sealed token, except the one nearesst the map exit.\n");
        Console.WriteLine("Enemies");
        Console.WriteLine("A: Wretch");
        Console.WriteLine("B: Drone");
        Console.WriteLine("C: Boomer\n");
        Console.WriteLine("General AI: 1, 2, 3, 4, 6 \n");
    }

    private void StageOneBanner()
    {
        Console.WriteLine("\nSpecial Rules:\n");
        Console.WriteLine("Location card 12A is not discarded after it's equipment activated.\n");
        Console.WriteLine("OBJECTIVE: all emergence holes have been sealed\n");
    }

    private void StageTwoBanner()
    {
        Console.WriteLine("\nSpecial Rules:\n");
        Console.WriteLine("Locust figures cannot spawn.\n\n If an Ai card would spawn Locust\n figures, ignore the card and\n draw a new AI card.");
        Console.WriteLine("OBJECTIVE: There are zero locust figures in play\n");
    }

    private void StageOneEnd()
    {
        Console.WriteLine("\nAs you seal the emergence hole, an explosion throws you to the ground.");
        Console.WriteLine("When you regain your feet, you see a pillar of black smoke billowing from ");
        Console.WriteLine("the open doorway. A swarm of enemies charge through the smoke.\n");
        Console.WriteLine("Spawn these locust at the map exit:");
        switch (_numberOfPlayers)
        {
            case 1:
            Console.WriteLine("1 Wretch, 1 Boomer");
            break;
            case 2:
            Console.WriteLine("2 Wretches, 2 Boomers");
            break;
            case 3:
            Console.WriteLine("2 Wretches, 2 Drones, 2 Boomers");
            break;
            default:
            Console.Write("2 Wretches, 3 Drones, 3 Boomers");
            break;
        }
        Console.WriteLine("\nThen move each Wretch 2 areas towards the nearest COG");
        Console.WriteLine("and each Drone 1 area towards the nearest COG");
        CancellationTokenSource.Cancel();
        SetupAudio(@"C:\Dev\VisualStudioCode\GearsOfWarTheBoardGameConsole\Music\AttackOfTheDrones.mp3");


        //TODO: Press Y to Continue
    }
    private void MissionEnd()
    {
        CancellationTokenSource.Cancel();
        Console.WriteLine("\nFenix: What are you doing here?");
        Console.WriteLine("Santiago: Getting you out. Here put this on.");
        Console.WriteLine("Fenix: You could get into a lot of trouble for doing this.");
        Console.WriteLine("Santiago: Not anymore. Things have changed. C'mon.");
        Console.WriteLine("Fenix What about the other prisoners?");
        Console.WriteLine("We can't just leave them here.");
        Console.WriteLine("Santiago: They're gone. Hoffman pardoned everybody.");
        Console.WriteLine("Fenix: Is that right?");
        Console.WriteLine("Santiago Welcome back to the army soldier\n");
        Console.WriteLine("YOU WIN THE GAME!!!\n");
        WaitForGameToEnd();
    }

    private void MissionSpecifics()
    {
        Console.WriteLine("Would you like to view the Mission Specifics Y/N?");
        switch (Console.ReadLine().ToUpper())
        {
            case "Y":
            break;
            case "N":
            return;
            default:
            MissionSpecifics();
            break;
        }
        Console.WriteLine("\nEMERGENCE\n");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("Maps Size: ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Small\n");
        Console.WriteLine("This Mission sends COG players into the heart of danger");
        Console.WriteLine("to close an emergence hole in the middle of COG territory.");
        Console.WriteLine("Players must work together to close this hole and keep");
        Console.WriteLine("the Locust horde at bay.\n");
        Console.WriteLine("The mission is recommended when playing Gears of War:");
        Console.WriteLine("The Board Game for the first time\n");
        Console.WriteLine("RULE CLARIFICATIONS:");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("@ Spawning Locust figures: ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("During setup, Locust");
        Console.WriteLine("\tfigures are spawned before any emergence holes");
        Console.WriteLine("\tare sealed from the mission card's special ability.\n");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("@ Grenades and Sealing: ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("The stage 1 objective ");
        Console.WriteLine("requires players to use a Bolo Grenade to seal the");
        Console.WriteLine("\tfinal emergence hole. If a player runs out of grenade");
        Console.WriteLine("\ttokens, he can use map tile 12A's equipment\n");
        Console.WriteLine("\tThe stage 1 Mission card states that when activating");
        Console.WriteLine("\tthis equipment, the Location card is not discarded. It");
        Console.WriteLine("\tmay be actived again on a future turn.\n");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("@ Stage 2 Spawning: ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("During stage 2, Locust figures ");
        Console.WriteLine("cannot be spawned. If an AI card would spawn");
        Console.WriteLine("\tLocust figures, it is discarded (without resolving the");
        Console.WriteLine("\tcard) and a new AI card is drawn\n");

        Console.WriteLine("Press Y to contine");
        switch (Console.ReadLine().ToUpper())
        {
            case "Y":
            break;
            default:
            MissionSpecifics();
            break;
        }
        
    }
}