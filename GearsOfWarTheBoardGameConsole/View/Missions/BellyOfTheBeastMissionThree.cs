public class BellyOfTheBeastMissionThree : GearsOfWarMission
{
    private int _playerIterator = 1;
    private int _numberOfPlayers;
    private int _stageNumber;
    private bool _isStageOneActivated;
    private bool _isStageTwoActivated;

    public BellyOfTheBeastMissionThree(int numberOfPlayers, int missionNumber) : base (numberOfPlayers, missionNumber)
    {
        _numberOfPlayers = numberOfPlayers;
        _isStageOneActivated = true;
        IsGameStillGoing = true;
        _stageNumber = 1;
        SetupAudioContinually(GearsOfWarMission.BasePath + @"\Music\ImulsionMines.mp3");
        MissionSpecifics();
        CreateLocationCardDeck();
        DisplayLocationCardDeck(0);
        DisplayLocationCardDeck(1);
        DisplayLocationCardDeck(2);
        StartTimer();
        Console.WriteLine("\n\n\n\n");
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
        Console.WriteLine("second map tile placed");

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
        Console.WriteLine($"Player {_playerIterator}'s turn");
        StageActivationPrompt();
        if (_playerIterator == _numberOfPlayers)
        {
            _playerIterator = 0;
        }
        _playerIterator++;
    }

    private void StageActivationPrompt()
    {
        if (_isStageOneActivated)
        {
            Console.WriteLine("\nHas a player actived\n location 13B's equipment\n (found in level 3) Y/N?");

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

    private void LocustTurn()
    {
        if (!IsGameStillGoing)
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
        Console.WriteLine("(found in level 3).\n");
    }

    private void StageTwoBanner()
    {
        Console.WriteLine("\nSpecial Rules:\n");
        Console.WriteLine("Resolve one additional AI card");
        Console.WriteLine("during each player's Locust");
        Console.WriteLine("Activation step");
        Console.WriteLine("Objective: The last card of the AI");
        Console.WriteLine("deck has been resolved\n");
    }

    private void StageOneEnd()
    {
        Console.WriteLine("\n\"Fenix: Ok, time to go home. Baird, you set up the resonator,");
        Console.WriteLine("we'll get that elevator back online\n");
        Console.WriteLine("Shuffle the AI discard pile into the deck. Each player then");
        Console.WriteLine("spawns 1 Locust B at an emergence hole on map tile 13B.\n");
        Console.WriteLine("THEN PROCEED TO THE NEXT STAGE\n");
        CancelMusic();
        SetupAudioContinually(GearsOfWarMission.BasePath + @"\Music\GearsOfWar.mp3");
        CreateLocustAiCardDeck(1);
        //TODO: Press Y to Continue
    }

    private void MissionEnd()
    {
        CancelMusic();
        SetupAudioOneTime(GearsOfWarMission.BasePath + @"\Music\GearsofWarInGameMusicBossBattleVictory.mp3");
        Console.WriteLine("\n\"Fenix: Control, this is Delta. We're clear. Resenator has been detonated.");
        Console.WriteLine("Control: You did it Marcus. Stand by. King ravens are en route.\"");
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

        Console.WriteLine("\nBELLY OF THE BEAST\n");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("Maps Size: ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Medium\n");
        Console.WriteLine("This mission sends the COG soldiers deep into the");
        Console.WriteLine("mines, searching for the ideal location to place the sonic");
        Console.WriteLine("resonator. This subsonice device will hopefully return a");
        Console.WriteLine("detailed map of the Locust holows so that the COG can");
        Console.WriteLine("destroy them once and for all whith the Lightmass bomb.\n");
        Console.WriteLine("RULE CLARIFICATIONS:");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("@ Setup: ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("This mission is unique in that there are two\n");
        Console.WriteLine("\texits to the map. After setting up the first level,");
        Console.WriteLine("\tthe first map tile that was placed is rotated so that");
        Console.WriteLine("\tit's entrance lines up with the second map tile's");
        Console.WriteLine("\tentrance (see example below).\n");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("@ Two Doors: ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("During setup, two doors are placed on\n");
        Console.WriteLine("\tthe map. The second door is placed on the exit of");
        Console.WriteLine("\tthe first map tile and leads to the third level of the");
        Console.WriteLine("\tmap (see example below). If an AI card spawns");
        Console.WriteLine("\tfigures at the map exit, these figures are spawned");
        Console.WriteLine("\tat the map exit nearest to the active player.\n");
        Console.WriteLine("\t ----------------------3B--   -------(To Level 3)----1B-- ");
        Console.WriteLine("\t|                          | |                           |");
        Console.WriteLine("\t|                          | |                           |");
        Console.WriteLine("\t|                          | |                           |");
        Console.WriteLine("\t|                          | |                           |");
        Console.WriteLine("\t|                          | |                           |");
        Console.WriteLine("\t|                          | |   (COG STAGGING AREA)     |");
        Console.WriteLine("\t(To Level 2)               | |                           |");
        Console.WriteLine("\t|                          | |                           |");
        Console.WriteLine("\t|__________________________| |___________________________|");
        Console.WriteLine("");
        Console.WriteLine("\t ----------------------11B--   ---------------------10B-- ");
        Console.WriteLine("\t|                          | |                           |");
        Console.WriteLine("\t|                          | |                           |");
        Console.WriteLine("\t|                          | |                           |");
        Console.WriteLine("\t|                          | |                           |");
        Console.WriteLine("\t|                          | |                           |");
        Console.WriteLine("\t|                          | |                           |");
        Console.WriteLine("\t|                          | |                           |");
        Console.WriteLine("\t|                          | |                           |");
        Console.WriteLine("\t|__________________________| |___________________________|");

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