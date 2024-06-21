public class TheShowDownMissionPackOne: GearsOfWarMission
{
    private int _playerInterator = 1;
    private int _numberOfPlayers;
    private int _stageNumber;
    private bool _isStageOneActivated;
    private bool _isStageTwoActivated;
    private bool _isStageThreeActivated;

    public TheShowDownMissionPackOne(int numberOfPlayers, int missionNumber): base(numberOfPlayers, missionNumber)
    {
        _numberOfPlayers = numberOfPlayers;
        _isStageOneActivated = true;
        IsGameStillGoing = true;
        SetupAudio(@"C:\Dev\VisualStudioCode\GearsOfWarTheBoardGameConsole\Music\TrainRideToHell.mp3");
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
        Console.WriteLine(@"                             ___________.__                   _________.__                        .___                        ");
        Console.WriteLine(@"                             \__    ___/|  |__    ____       /   _____/|  |__    ____ __  _  __ __| _/ ____ __  _  __ ____      ");
        Console.WriteLine(@"                               |    |   |  |  \ _/ __ \      \_____  \ |  |  \  /  _ \\ \/ \/ // __ | /  _ \\ \/ \/ //    \       ");
        Console.WriteLine(@"                               |    |   |   Y  \\  ___/      /        \|   Y  \(  <_> )\     // /_/ |(  <_> )\     /|   |  \      ");
        Console.WriteLine(@"                               |____|   |___|  / \___  >    /_______  /|___|  / \____/  \/\_/ \____ | \____/  \/\_/ |___|  /       ");
        Console.WriteLine(@"                                             \/      \/             \/      \/                     \/                    \/        ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nMission Setup\n");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\nMission Setup\n");
        Console.WriteLine("Special Rules:\n");
        Console.WriteLine("When setting up place the feral");
        Console.WriteLine("Berserker on the exit of the map.");
        Console.WriteLine("Each player receives a Scorcher.\n");
        Console.WriteLine("Special Weapons card with no\n");
        Console.WriteLine("tokens for it.\n");
        Console.WriteLine("Enemies");
        Console.WriteLine("A: Grenadier");
        Console.WriteLine("B: Palace Guard");
        Console.WriteLine("C: Feral Bezerker\n");
        Console.WriteLine("General AI: 17, 18 \n");
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
            Console.WriteLine("\nHas the Berserker been killed Y/N?");

            switch (Console.ReadLine().ToUpper())
            {
                case "Y":
                    _isStageOneActivated = false;
                    _isStageTwoActivated = true;
                    _stageNumber = 2;
                    DisplayLocationCardDeck(1);
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
            Console.WriteLine("\nHas level 2 been explored Y/N?");

            switch (Console.ReadLine().ToUpper())
            {
                case "Y":
                _isStageTwoActivated = false;
                _isStageThreeActivated = true;
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

        if (_isStageThreeActivated)
        {
            Console.WriteLine("\nHas General RAAM been killed Y/N?");

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
        Console.WriteLine("While unwounded, the Feral\n Bezerker may ony be delt wounds\n by scorchers or Bolo Grenades.\n After it is killed, return the Feral\n Beserker card to the box and\n unlock level 2.");
        Console.WriteLine("OBJECTIVE: Level 2 has been explored\n");
    }

    private void StageTwoBanner()
    {
        Console.WriteLine("\nSpecial Rules:\n");
        Console.WriteLine("Boomers cannot be spawned.");
        Console.WriteLine("OBJECTIVE: General RAAM is killed\n");
    }

        private void StageOneEnd()
    {

        Console.WriteLine("\nUpdate the cards in the deck and enemey AI as follows:");
        Console.WriteLine("A: Grenadier, B: Palace Guard, C: General Raam\n");
        Console.WriteLine("Carefully remove all the AI Butcher cards from AI deck and from");
        Console.WriteLine("the discard pile. Then shuffle the discard pile into the AI deck.");
        Console.WriteLine("Place the figure of General RAAM (use a boomer figure)");
        Console.WriteLine("on the EXIT of the map.\n");
        Console.WriteLine("Spawn 1 Locust type A for each player on every");
        Console.WriteLine("emergence hole on the map.");
        Console.WriteLine("THEN PROCEED TO THE NEXT STAGE");
        CreateLocustAiCardDeck(2);
    }
    private void MissionEnd()
    {
        CancellationTokenSource.Cancel();
        SetupAudio(@"C:\Dev\VisualStudioCode\GearsOfWarTheBoardGameConsole\Music\GearsofWarInGameMusicBossBattleVictory.mp3");
        Console.WriteLine("\nYou charge toward the wounded General, hoping to finish him off.");
        Console.WriteLine("But before you can reach him, his loyal kryll descend from the sky,");
        Console.WriteLine("\tforcing you to retreat.");
        Console.WriteLine("You hear his voice above the shrieks, swearing revenge in his");
        Console.WriteLine("guttural tongue.\n");
        Console.WriteLine("You have a feeling you'll be meeting again real soon...\n");
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
        Console.WriteLine("\nTHE SHOWDOWN\n");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("Maps Size: ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Medium\n");
        Console.WriteLine("This mission pits the COGs against two very");
        Console.WriteLine("dangerous Locusts. First they must overcome a");
        Console.WriteLine("savage Berserker, and then they must face off and");
        Console.WriteLine("eradicate General RAAM himself!\n");
        Console.WriteLine("RULE CLARIFICATIONS:\n");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("@ Setup: ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("In addition to their normal starting");
        Console.WriteLine("\tWeapons, Grenades, and Ammo, each player also");
        Console.WriteLine("\treceives a Scorcher Special Weapon card with no");
        Console.WriteLine("\tammo tokens on it.\n");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("@ Spawning Locust C: ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("During setup, assume there");
        Console.WriteLine("\tare no Locust \"C\" figures for spawning, Since there");
        Console.WriteLine("\tis only one Feral Berserker figure and players only");
        Console.WriteLine("\tuse one Boomer figure for General RAAM, Locust");
        Console.WriteLine("\t\"C\" figures cannot spawn during this mission. If");
        Console.WriteLine("\ta Location or AI card would spawn a Locust \"C\",");
        Console.WriteLine("\tinstead spawn one Locust \"B\", If all Locust \"B\"");
        Console.WriteLine("\tfigures are in play, spawn one Locust \"A\".\n");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("@ Feral Bersker: ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("If unwounded, the Feral");
        Console.WriteLine("\tBerserker may only be dealt wounds by the");
        Console.WriteLine("\tScorcher or Bolo Grenades. Once wounded, any");
        Console.WriteLine("\tweapon type can be used to wound it\n");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("@ Resetting the AI Deck: ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Once Stage 1 has been");
        Console.WriteLine("\tcompleted, the Locust AI deck is reset--all");
        Console.WriteLine("\tButcher AI cards are removed from the Locust AI");
        Console.WriteLine("\tdeck and discard pile, and General RAAM's AI");
        Console.WriteLine("\tcards are added. Then, the Locust AI deck and");
        Console.WriteLine("\tdiscard pile are shuffled together to create a");
        Console.WriteLine("\tnew Locust AI deck\n");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("@ General RAAM: ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("General RAAM's Enemy card has");
        Console.WriteLine("\ttwo unique sides. When General RAAM enters play,");
        Console.WriteLine("\tSide A of his Enemy card is placed faceup. Certain");
        Console.WriteLine("\tgame effects will force players to flip this card");
        Console.WriteLine("\tover. Whichever side is currently faceup displays");
        Console.WriteLine("\tthe current stats and abilities for General RAAM.");
        Console.WriteLine("\tPalyers always ignore the facedown side of");
        Console.WriteLine("\tthis Enemy card.\n");
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