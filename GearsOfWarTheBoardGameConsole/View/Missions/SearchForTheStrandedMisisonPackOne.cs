class SearchForTheStrandedMisisonPackOne : GearsOfWarMission
{
    private int _playerIterator = 1;
    private int _numberOfPlayers;
    private int _stageNumber;
    private bool _isStageOneActivated;
    private bool _isStageTwoActivated;
    private bool _isStageThreeActivated;

    public SearchForTheStrandedMisisonPackOne(int numberOfPlayers, int missionNumber): base(numberOfPlayers, missionNumber)
    {
        _numberOfPlayers = numberOfPlayers;
        _isStageOneActivated = true;
        IsGameStillGoing = true;
        SetupAudioContinually(GearsOfWarMission.BasePath + @"\Music\EphyraStreet.mp3");
        _stageNumber = 1;
        MissionSpecifics();
        CreateLocationCardDeck();
        DisplayLocationCardDeck(0);
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

    private void MissionSetup()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(@"                                  _________                               .__         ___________                   _________  __                               .___           .___    "); 
        Console.WriteLine(@"                                 /   _____/  ____  _____  _______   ____  |  |__      \_   _____/____ _______      /   _____/_/  |_ _______ _____     ____    __| _/ ____    __| _/      ");
        Console.WriteLine(@"                                 \_____  \ _/ __ \ \__  \ \_  __ \_/ ___\ |  |  \      |    __) /  _ \\_  __ \     \_____  \ \   __\\_  __ \\__  \   /    \  / __ |_/ __ \  / __ |         ");
        Console.WriteLine(@"                                 /        \\  ___/  / __ \_|  | \/\  \___ |   Y  \     |     \ (  <_> )|  | \/     /        \ |  |   |  | \/ / __ \_|   |  \/ /_/ |\  ___/ / /_/ |         ");
        Console.WriteLine(@"                                /_______  / \___  >(____  /|__|    \___  >|___|  /     \___  /  \____/ |__|       /_______  / |__|   |__|   (____  /|___|  /\____ | \___  >\____ |          ");
        Console.WriteLine(@"                                        \/      \/      \/             \/      \/          \/                             \/                     \/      \/      \/     \/      \/          ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nMission Setup\n");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Special Rules:\n");
        Console.WriteLine("Set aside 1 padlock token to rep-");
        Console.WriteLine("resent the Stranded. This Token");
        Console.WriteLine("will come into play later.");
        Console.WriteLine("Enemies");
        Console.WriteLine("A: Flame Grenadier");
        Console.WriteLine("B: Palace Guard");
        Console.WriteLine("C: Butcher\n");
        Console.WriteLine("General AI: 17, 18, 19 \n");
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
            Console.WriteLine("\nAre there a number of ammunition\n tokens on this card equal to twice\n the number of players? Y/N?");

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
            Console.WriteLine("\nHas a COG activated and resolved the\n equipment location card 17B Y/N?");

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
            Console.WriteLine("\nHas the stranded entered the map exit Y/N?");

            switch (Console.ReadLine().ToUpper())
            {
                case "Y":
                _isStageThreeActivated = false;
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
        Console.WriteLine("When a locust figure is killed,");
        Console.WriteLine("place 1 ammo token in it's area.");
        Console.WriteLine("At the end of each players COG");
        Console.WriteLine("Order Step he removes 1 ammo");
        Console.WriteLine("token from his area and place it on");
        Console.WriteLine("this card\n");
        Console.WriteLine("OBJECTIVE: There are a number of ammunition");
        Console.WriteLine("tokens on this card equal to twice");
        Console.WriteLine("the number of players\n");

    }

    private void StageTwoBanner()
    {
        Console.WriteLine("\nSpecial Rules:\n");
        Console.WriteLine("None\n");
        Console.WriteLine("OBJECTIVE: A COG activates and resolves the\n");
        Console.WriteLine("equipment location card 17B\n");
    }

    private void StageThreeBanner()
    {
        Console.WriteLine("\nSpecial Rules:\n");
        Console.WriteLine("At the end of each players turn,");
        Console.WriteLine("he may discard 1 order card and");
        Console.WriteLine("move the stranded up to 2 areas.");
        Console.WriteLine("If the Stranded is delt 1 or more");
        Console.WriteLine("wounds, the players lose the");
        Console.WriteLine("game");
        Console.WriteLine("OBJECTIVE: The Stranded enters the map exit.\n");
    }

    private void StageOneEnd()
    {
        Console.WriteLine("\nUnlock the level 2 deck and explore it immediatley.\n");
        Console.WriteLine("Any dropped ammunition tokens remain on the map,");
        Console.WriteLine("but no additional ammunition tokens can be placed.\n");
        Console.WriteLine("THEN PROCEED TO THE NEXT STAGE");
        DisplayLocationCardDeck(1);
    }

    private void StageTwoEnd()
    {

        Console.WriteLine("\nPlace the padlock token ont he map 17B in the area with");
        Console.WriteLine("the equipment icon.\n");
        Console.WriteLine("This token represents the stranded and is considered a COG figure");
        Console.WriteLine("only during activation of locusts, and has a defense value of 2.\n");
        Console.WriteLine("Spawn 1 Locust type C for each player at the exit of the map.");
        Console.WriteLine("THEN PROCEED TO THE NEXT STAGE");
        DisplayLocationCardDeck(1);
    }
    private void MissionEnd()
    {
        CancellationTokenSource.Cancel();
        SetupAudioOneTime(GearsOfWarMission.BasePath + @"\Music\GearsofWarInGameMusicBossBattleVictory.mp3");
        Console.WriteLine("\nThe Stranded: \"I can't believe we made it! C'mon let's get");
        Console.WriteLine("this gear to safety and we can split the spoils there. But don't");
        Console.WriteLine("you COGSs go thinkin' that just because you saved me, you");
        Console.WriteLine("get to wipe me out! I've seen you go through ammo, and I'm");
        Console.WriteLine("not about to hand all this over!\"\n");
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
        Console.WriteLine("\nSEARCH FOR THE STRANDED\n");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("Maps Size: ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Medium\n");
        Console.WriteLine("This mission sends the COGS to rescue an isolated");
        Console.WriteLine("Stranded-a surviving scavenger-and recover a");
        Console.WriteLine("cache of ammo and supplies he is guarding.\n");
        Console.WriteLine("RULE CLARIFICATIONS:\n");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("@ The Stranded: ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("The Stranded is treated like a");
        Console.WriteLine("\tCOG figure only for Locust activations. When");
        Console.WriteLine("\tresolving Locust AI cards, the Stranded may be");
        Console.WriteLine("\ttargeted and attacked by Locusts as if it were");
        Console.WriteLine("\ta COG figure. However, the stranded cannot be");
        Console.WriteLine("\tmoved into cover or affected by COG attacks.\n");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("@ Ammo Tokens: ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Some card effects instruct players");
        Console.WriteLine("\tto place ammo tokens on the map, These tokens");
        Console.WriteLine("\tmay not be picked up or placed on Weapon cards.\n");
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