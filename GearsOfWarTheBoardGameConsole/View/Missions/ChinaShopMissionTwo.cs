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
        Console.WriteLine("area of level 1.");

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
        Console.WriteLine("THEN PROCEED TO THE NEXT STAGE");

        //TODO: Press Y to Continue
        DisplayLocationCardDeck(2);
    }
    private void MissionEnd()
    {
        Console.WriteLine("\nThe Bersker howls in rage as the imulsion beam rips her apart.");
        Console.WriteLine("\"Fenix: Hey Cole, Baird - It's all clear.\"\n");
        Console.WriteLine("YOU WIN THE GAME!!!\n");
    }
}