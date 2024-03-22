public class TheShowDownMissionPackOne: GearsOfWarMission
{
    private int _playerInterator = 1;
    private int _numberOfPlayers;
    private int _stageNumber;
    private bool _isStageOneActivated;
    private bool _isStageTwoActivated;
    private bool _isGameStillGoing;
    public TheShowDownMissionPackOne(int numberOfPlayers, int missionNumber): base(numberOfPlayers, missionNumber)
    {
        _numberOfPlayers = numberOfPlayers;
        _isStageOneActivated = true;
        _isGameStillGoing = true;
        _stageNumber = 1;
        CreateLocationCardDeck();
        DisplayLocationCardDeck(1);
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
            Console.WriteLine("\nHas level 2 been explored Y/N?");

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
            Console.WriteLine("\nHas General RAAM been killed Y/N?");

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

        //TODO: Press Y to Continue
        CreateLocustAiCardDeck(2);
    }
    private void MissionEnd()
    {
        Console.WriteLine("\nYou charge toward the wounded General, hoping to finish him off.");
        Console.WriteLine("But before you can reach him, his loyal kryll descend from the sky,");
        Console.WriteLine("\tforcing you to retreat.");
        Console.WriteLine("You hear his voice above the shrieks, swearing revenge in his");
        Console.WriteLine("guttural tongue.\n");
        Console.WriteLine("You have a feeling you'll be meeting again real soon...\n");
        Console.WriteLine("YOU WIN THE GAME!!!\n");
    }
}