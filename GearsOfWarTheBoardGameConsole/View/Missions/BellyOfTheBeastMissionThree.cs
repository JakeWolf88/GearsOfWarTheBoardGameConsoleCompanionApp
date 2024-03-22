public class BellyOfTheBeastMissionThree : GearsOfWarMission
{
    private int _playerInterator = 1;
    private int _numberOfPlayers;
    private int _stageNumber;
    private bool _isStageOneActivated;
    private bool _isStageTwoActivated;
    private bool _isGameStillGoing;
    public BellyOfTheBeastMissionThree(int numberOfPlayers, int missionNumber) : base (numberOfPlayers, missionNumber)
    {
        _numberOfPlayers = numberOfPlayers;
        _isStageOneActivated = true;
        _isGameStillGoing = true;
        _stageNumber = 1;
        CreateLocationCardDeck();
        DisplayLocationCardDeck(1);
        DisplayLocationCardDeck(2);
        StartMission();
    }

    private void StartMission()
    {
        SetupMission();
        MissionSetup();

        while (_isGameStillGoing)
        {
            CogTurn();
            LocustTurn();
        }
    }

        private void MissionSetup()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(@"                            __________       .__  .__          ________   _____  ___________.__             __________                        __            ");
        Console.WriteLine(@"                            \______   \ ____ |  | |  | ___.__. \_____  \_/ ____\ \__    ___/|  |__   ____   \______   \ ____ _____    _______/  |_          ");
        Console.WriteLine(@"                             |    |  _// __ \|  | |  |<   |  |  /   |   \   __\    |    |   |  |  \_/ __ \   |    |  _// __ \\__  \  /  ___/\   __\         ");
        Console.WriteLine(@"                             |    |   \  ___/|  |_|  |_\___  | /    |    \  |      |    |   |   Y  \  ___/   |    |   \  ___/ / __ \_\___ \  |  |           ");
        Console.WriteLine(@"                             |______  /\___  >____/____/ ____| \_______  /__|      |____|   |___|  /\___  >  |______  /\___  >____  /____  > |__|           ");
        Console.WriteLine(@"                                    \/     \/          \/              \/                        \/     \/          \/     \/     \/     \/                 ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nMission Setup\n");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Special Rules:\n");
        Console.WriteLine("After setup, rotate the first map");
        Console.WriteLine("tile placed so it's entrance lines");
        Console.WriteLine("up with the entrance of the");
        Console.WriteLine("s3cond map tile placed");

        Console.WriteLine("Enemies");
        Console.WriteLine("A: Lambent Wretch");
        Console.WriteLine("B: Drone");
        Console.WriteLine("C: Theron Guard\n");
        Console.WriteLine("General AI: 1, 2, 3, 6, 7\n");
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

    private void StageActivationPrompt()
    {
        if (_isStageOneActivated)
        {
            Console.WriteLine("\nHas a player actived\n location 12B's equipment\n (found in level 3) Y/N?");

            switch (Console.ReadLine().ToUpper())
            {
                case "Y":
                _isStageOneActivated = false;
                _isStageTwoActivated = true;
                _stageNumber = 2;
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
            Console.WriteLine("\nHas the last card of the AI\n deck been resolved Y/N?");

            switch (Console.ReadLine().ToUpper())
            {
                case "Y":
                _isStageTwoActivated = false;
                _isGameStillGoing = false;
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

    private void LocustTurn()
    {
        if (!_isGameStillGoing)
        {
            return;
        }
        Console.WriteLine("\nLocust turn:");
        if (IsLocustPcPlaying)
        {
            DisplayLocustAiCard(_stageNumber);
        }
        WaitForTurnToComplete();
    }

    private void StageOneBanner()
    {
        Console.WriteLine("\nSpecial Rules:\n");
        Console.WriteLine("Place a door token on the first");
        Console.WriteLine("map tile's exit. This door leads");
        Console.WriteLine("to level 3. Level 3 cannot be");
        Console.WriteLine("explored from any other door.");
        Console.WriteLine("OBJECTIVE: A player activates");
        Console.WriteLine("Location 13B's equipment");
        Console.WriteLine("(found in level 3).");
    }

    private void StageTwoBanner()
    {
        Console.WriteLine("\nSpecial Rules:\n");
        Console.WriteLine("Resolve one additional AI card");
        Console.WriteLine("during each player's Locust");
        Console.WriteLine("Activation step");
        Console.WriteLine("Objective: The last card of the AI");
        Console.WriteLine("deck has been resolved");
    }

    private void StageOneEnd()
    {
        Console.WriteLine("\n\"Fenix: Ok, time to go home. Baird, you set up the resonator,");
        Console.WriteLine("we'll get that elevator back online\n");
        Console.WriteLine("Shuffle the AI discard pile into the deck. Each player then");
        Console.WriteLine("spawns 1 Locust B at an emergence hole on map tile 13B.\n");
        Console.WriteLine("THEN PROCEED TO THE NEXT STAGE");

        //TODO: Press Y to Continue
    }

    private void MissionEnd()
    {
        Console.WriteLine("\n\"Fenix: Control, this is Delta. We're clear. Resenator has been detonated.");
        Console.WriteLine("Control: You did it Marcus. Stand by. King ravens are en route.\"");
        Console.WriteLine("YOU WIN THE GAME!!!\n");
    }
}