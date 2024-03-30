class ChinaShopMissionTwo : GearsOfWarMission
{
    private int _playerInterator = 1;
    private int _numberOfPlayers;
    private int _stageNumber;
    private bool _isStageOneActivated;
    private bool _isStageTwoActivated;
    private bool _isStageThreeActivated;
    private bool _isGameStillGoing;
    public ChinaShopMissionTwo(int numberOfPlayers, int missionNumber) : base(numberOfPlayers, missionNumber)
    {
        _numberOfPlayers = numberOfPlayers;
        _isStageOneActivated = true;
        _isGameStillGoing = true;
        _stageNumber = 1;
        SetupAudio(@"C:\Dev\VisualStudioCode\GearsOfWarTheBoardGameConsole\Music\TombsOfTheUnknowns.mp3");
        MissionSpecifics();
        CreateLocationCardDeck();
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
        Console.WriteLine(@"                               _________ .__    .__                  _________.__                       ");
        Console.WriteLine(@"                               \_   ___ \|  |__ |__| ____ _____     /   _____/|  |__   ____ ______       ");
        Console.WriteLine(@"                               /    \  \/|  |  \|  |/    \\__  \    \_____  \ |  |  \ /  _ \\____ \       ");
        Console.WriteLine(@"                               \     \___|   Y  \  |   |  \/ __ \_  /        \|   Y  (  <_> )  |_> >      ");
        Console.WriteLine(@"                                \______  /___|  /__|___|  (____  / /_______  /|___|  /\____/|   __/       ");
        Console.WriteLine(@"                                       \/     \/        \/     \/          \/      \/       |__|         ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nMission Setup\n");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Special Rules:\n");
        Console.WriteLine("During setup, place the");
        Console.WriteLine("Berserker in a COG figure's starting area\n");
        Console.WriteLine("Enemies");
        Console.WriteLine("A: Wretch");
        Console.WriteLine("B: Drone");
        Console.WriteLine("C: Berserker\n");
        Console.WriteLine("General AI: 1, 2, 5, 6\n");
    }

    private void CogTurn()
    {
        Console.WriteLine("COG player's turn:");
        if (_isStageOneActivated)
        {
            StageOneBanner();
        }
        else if (_isStageTwoActivated)
        {
            StageTwoBanner();
        }
        else
        {
            StageThreeBanner();
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
            Console.WriteLine("\nHas the Berserk moved\n into the map exit\n area of level 1 Y/N?");

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
            Console.WriteLine("\nHas the Berserk moved\n into the map exit\n area of level 2 Y/N?");

            switch (Console.ReadLine().ToUpper())
            {
                case "Y":
                _isStageTwoActivated = false;
                _isStageThreeActivated = true;
                StageTwoEnd();
                break;
                case "N":
                break; 
                default:
                StageActivationPrompt();
                break;
            }
        }

        if (_isStageThreeActivated)
        {
            Console.WriteLine("\nHas the Berserker been killed Y/N?");

            switch (Console.ReadLine().ToUpper())
            {
                case "Y":
                _isStageThreeActivated = false;
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
        Console.WriteLine("See Berserker enemy card\n");
        Console.WriteLine("OBJECTIVE: The Berserker moves");
        Console.WriteLine("into the map exit");
        Console.WriteLine("area of level 1.\n");

    }

    private void StageTwoBanner()
    {
        Console.WriteLine("\nSpecial Rules:\n");
        Console.WriteLine("See Berserker enemy card\n");
        Console.WriteLine("OBJECTIVE: The Berserker moves");
        Console.WriteLine("into the map exit");
        Console.WriteLine("area of level 2.");
    }

    private void StageThreeBanner()
    {
        Console.WriteLine("\nSpecial Rules:\n");
        Console.WriteLine("See Berserker enemy card\n");
        Console.WriteLine("OBJECTIVE: The Berserker moves");
        Console.WriteLine("into the map exit");
        Console.WriteLine("Ther Berserker is killed.");
    }

    private void StageOneEnd()
    {
        Console.WriteLine("\n\"Fenix: Control, this is Delta. We've got a Berserker in the vicinity.");
        Console.WriteLine("\t Please advise.");
        Console.WriteLine("Control: Hold your fire Delta. Standard firearms won't work.");
        Console.WriteLine("Get her outside and use the Hammer of Dawn.");
        Console.WriteLine("Dom: So what's the plan?");
        Console.WriteLine("Fenix: Well, unfortunately all we need to do is get her to follow us.\"\n");
        Console.WriteLine("Unlock the level 2 Location deck and explore it.\n");
        Console.WriteLine("THEN PROCEED TO THE NEXT STAGE");

        //TODO: Press Y to Continue
        DisplayLocationCardDeck(1);
    }

    private void StageTwoEnd()
    {

        Console.WriteLine("\n\"Control: Satelite is online.");
        Console.WriteLine("Fenix: Ok Dom, drop the Hammer!\"\n");
        Console.WriteLine("Unlock the level 3 Location deck and explore it.\n");
        Console.WriteLine("THEN PROCEED TO THE NEXT STAGE\n");
        CancellationTokenSource.Cancel();
        SetupAudio(@"C:\Dev\VisualStudioCode\GearsOfWarTheBoardGameConsole\Music\MinhsDeath.mp3");

        //TODO: Press Y to Continue
        DisplayLocationCardDeck(2);
    }
    private void MissionEnd()
    {
        CancellationTokenSource.Cancel();
        Console.WriteLine("\nThe Bersker howls in rage as the imulsion beam rips her apart.");
        Console.WriteLine("\"Fenix: Hey Cole, Baird - It's all clear.\"\n");
        Console.WriteLine("YOU WIN THE GAME!!!\n");
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
        Console.WriteLine("\nCHINA SHOP\n");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("Maps Size: ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Medium\n");
        Console.WriteLine("This mission starts with the COG soldiers on the run from");
        Console.WriteLine("the deadly Berserker. This impervious enemy is blind and");
        Console.WriteLine("relies on it's senses of smell and hearing to detect and");
        Console.WriteLine("eliminate it's foes.\n");
        Console.WriteLine("Tip: Throw grenades to attract the Berserker away from");
        Console.WriteLine("your teammates and toward the doors.\n");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("@ Spawning Locust C: ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Since there is only one\n"); 
        Console.WriteLine("\tBerserker figure, additional Locust \"C\" figures");
        Console.WriteLine("\tcannot spawn. If a Location or AI card would spawn");
        Console.WriteLine("\ta Locust \"C\", instead spawn one Drone. If all Drones");
        Console.WriteLine("\tare in play, instead spawn one Wretch.\n");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("@ Bersker Attacks: ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("AI cards someties require the "); 
        Console.WriteLine("Bersker to attack each figure in it's area. Such");
        Console.WriteLine("\tattacks are resolved like area attacks. The attack");
        Console.WriteLine("\tdice are rolled once and each defending figure rolls");
        Console.WriteLine("\tit's own defense dice. These attacks affect both");
        Console.WriteLine("\tLocust and COG figures.\n");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("@ Berserker Constant Ability: ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("The Berserker's "); 
        Console.WriteLine("constant ability moves it one space toward a");
        Console.WriteLine("\tCOG each time the COG attacks (even when using");
        Console.WriteLine("\ta Lancer Assault Rifle's constant ability). This");
        Console.WriteLine("\thappens immediately after resolving the attack,");
        Console.WriteLine("\tand can even happen multiple times per turn. This");
        Console.WriteLine("\tability does not cause the Berserker to attack.\n");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("@ Berserker Health Levels: ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("The Berserker is the");
        Console.WriteLine("\tonly enemy that can be wounded twice (see page");
        Console.WriteLine("\t17). The Bersker may only be attacked with the");
        Console.WriteLine("\tHammer of Dawn (found on map tile 17A) unless it");
        Console.WriteLine("\thas already been wounded\n");

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