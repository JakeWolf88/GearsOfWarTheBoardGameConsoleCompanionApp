using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearsOfWarTheBoardGameConsole.View.Missions
{
    internal class HordeModeMissionSeven : GearsOfWarMission
    {
        private int _playerInterator = 1;
        private int _numberOfPlayers;
        private int _stageNumber;
        private bool _isStageOneActivated;
        private bool _isStageTwoActivated;
        private bool _isStageThreeActivated;
        private bool _isStageFourActivated;
        private bool _isStageFiveActivated;
        private bool _isStageSixActivated;

        public HordeModeMissionSeven(int numberOfPlayers, int missionNumber) : base(numberOfPlayers, missionNumber)
        {
            _numberOfPlayers = numberOfPlayers;
            _isStageOneActivated = true;
            IsGameStillGoing = true;
            _stageNumber = 1;
            //SetupAudio(@"C:\Dev\VisualStudioCode\GearsOfWarTheBoardGameConsole\Music\HoldThemOff.mp3");
            MissionSpecifics();
            CreateLocationCardDeck();
            PickDifficutly();
            StartTimer();
            StartMission();
        }

        private void PickDifficutly()
        {
            Console.WriteLine("Pick you diffictly level:");
            Console.WriteLine("1 - CASUAL");
            Console.WriteLine("2 - NORMAL");
            Console.WriteLine("3 - HARDCORE");
            Console.WriteLine("4 - INSANE");
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            switch (Console.ReadLine().ToUpper())
            {
                case "1":
                    DisplayLocationCardDeck(0);
                    break;
                case "2":
                    DisplayLocationCardDeck(1);
                    break;
                case "3":
                    DisplayLocationCardDeck(2);
                    break;
                case "4":
                    DisplayLocationCardDeck(3);
                    break;
                default:
                    PickDifficutly();
                    break;
            }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
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

#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        public void SetupMission()
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
        {
            Console.WriteLine("Would you like the computer to draw AI Locust cards? Y/N");
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            switch (Console.ReadLine().ToUpper())
            {
                case "Y":
                    CreateLocustAiCardDeck(1);
                    IsLocustPcPlaying = true;
                    break;
                case "N":
                    IsLocustPcPlaying = false;
                    break;
                default:
                    SetupMission();
                    break;
            }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }

        private void MissionSetup()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"                       ___ ___                  .___          _____             .___              ");
            Console.WriteLine(@"                      /   |   \  ___________  __| _/____     /     \   ____   __| _/____          ");
            Console.WriteLine(@"                     /    ~    \/  _ \_  __ \/ __ |/ __ \   /  \ /  \ /  _ \ / __ |/ __ \         ");
            Console.WriteLine(@"                     \    Y    (  <_> )  | \/ /_/ \  ___/  /    Y    (  <_> ) /_/ \  ___/         ");
            Console.WriteLine(@"                      \___|_  / \____/|__|  \____ |\___  > \____|__  /\____/\____ |\___  >        ");
            Console.WriteLine(@"                            \/                   \/    \/          \/            \/    \/         ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nMission Setup\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Special Rules:\n");
            Console.WriteLine("Before setting up the map,");
            Console.WriteLine("players must choose one of the 4");
            Console.WriteLine("difficulty options.\n");
            Console.WriteLine("Enemies");
            Console.WriteLine("A: Wretch");
            Console.WriteLine("B: Drone");
            Console.WriteLine("C: None\n");
            Console.WriteLine("General AI: 1, 2, 5, 6\n");
        }

        private void CogTurn()
        {
            Console.WriteLine("COG player's turn:");
            if (_isStageOneActivated || _isStageTwoActivated || _isStageThreeActivated || _isStageFourActivated || _isStageFiveActivated)
            {
                StageOneToFiveBanner();
            }
            else
            {
                StageSixBanner();
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
                DisplayLocustAiCard(_stageNumber);
            }
            WaitForTurnToComplete();
        }

        private void StageActivationPrompt()
        {
            if (_isStageOneActivated)
            {
                Console.WriteLine("\nHas the last Locust\n been killed Y/N?");

#pragma warning disable CS8602 // Dereference of a possibly null reference.
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
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            }

            if (_isStageTwoActivated)
            {
                Console.WriteLine("\nHas the last Locust\n been killed Y/N?");

#pragma warning disable CS8602 // Dereference of a possibly null reference.
                switch (Console.ReadLine().ToUpper())
                {
                    case "Y":
                        _isStageTwoActivated = false;
                        _isStageThreeActivated = true;
                        _stageNumber = 3;
                        StageTwoEnd();
                        break;
                    case "N":
                        break;
                    default:
                        StageActivationPrompt();
                        break;
                }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            }

            if (_isStageThreeActivated)
            {
                Console.WriteLine("\nHas the last Locust\n been killed Y/N?");

#pragma warning disable CS8602 // Dereference of a possibly null reference.
                switch (Console.ReadLine().ToUpper())
                {
                    case "Y":
                        _isStageThreeActivated = false;
                        _isStageFourActivated = true;
                        _stageNumber = 4;
                        StageThreeEnd();
                        break;
                    case "N":
                        break;
                    default:
                        StageActivationPrompt();
                        break;
                }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            }
            if (_isStageFourActivated)
            {
                Console.WriteLine("\nHas the last Locust\n been killed Y/N?");

#pragma warning disable CS8602 // Dereference of a possibly null reference.
                switch (Console.ReadLine().ToUpper())
                {
                    case "Y":
                        _isStageFourActivated = false;
                        _isStageFiveActivated = true;
                        _stageNumber = 5;
                        StageFourEnd();
                        break;
                    case "N":
                        break;
                    default:
                        StageActivationPrompt();
                        break;
                }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            }
            if (_isStageFiveActivated)
            {
                Console.WriteLine("\nHas the last Locust\n been killed Y/N?");

#pragma warning disable CS8602 // Dereference of a possibly null reference.
                switch (Console.ReadLine().ToUpper())
                {
                    case "Y":
                        _isStageFiveActivated = false;
                        _isStageSixActivated = true;
                        _stageNumber = 6;
                        StageFiveEnd();
                        break;
                    case "N":
                        break;
                    default:
                        StageActivationPrompt();
                        break;
                }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            }
            if (_isStageSixActivated)
            {
                Console.WriteLine("\nHas the last Locust\n been killed Y/N?");

#pragma warning disable CS8602 // Dereference of a possibly null reference.
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
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            }
        }

        private void StageOneToFiveBanner()
        {
            Console.WriteLine("\nSpecial Rules:\n");
            Console.WriteLine("Grenade and Ammunition");
            Console.WriteLine("Location cards are turned");
            Console.WriteLine("facedown when used.\n");
            Console.WriteLine("Objective: The last Locust");
            Console.WriteLine("is killed.\n");
        }

        private void StageSixBanner()
        {
            Console.WriteLine("\nSpecial Rules:\n");
            Console.WriteLine("None.\n");
        }

        private void StageOneEnd()
        {
            Console.WriteLine("\nDiscard all sealed emergence hole tokens, then turn all");
            Console.WriteLine("Ammunition Location cards faceup. Then update");
            Console.WriteLine("the AI deck and Enemy cards to reflect the following:");
            Console.WriteLine("A: Wretch, B: Drone, C: None\n");
            Console.WriteLine("Finally, shuffle the AI discard pile into the deck and spawn the");
            Console.WriteLine("following figures at emergence holes (as evenly as possible).");
            switch (_numberOfPlayers)
            {
                case 1:
                    Console.WriteLine("1 Player: 2 Wretches, 1 Drone");
                    break;
                case 2:
                    Console.WriteLine("2 Players: 4 Wretches, 1 Drone");
                    break;
                case 3:
                    Console.WriteLine("3 Players: 4 Wretches, 3 Drones");
                    break;
                case 4:
                    Console.WriteLine("4 Players: 6 Wretches, 3 Drones");
                    break;
            }
            Console.WriteLine("THEN PROCEED TO THE NEXT STAGE\n");
            //TODO: Press Y to Continue
        }

        private void StageTwoEnd()
        {
            Console.WriteLine("\nDiscard all sealed emergence hole tokens, then turn all");
            Console.WriteLine("Ammunition Location cards faceup. Then update");
            Console.WriteLine("the AI deck and Enemy cards to reflect the following:");
            Console.WriteLine("A: Lament Wretch, B: Boomer, C: None\n");
            Console.WriteLine("Finally, shuffle the AI discard pile into the deck and spawn the");
            Console.WriteLine("following figures at emergence holes (as evenly as possible).");
            switch (_numberOfPlayers)
            {
                case 1:
                    Console.WriteLine("1 Player: 2 Lament Wretches, 1 Boomer");
                    break;
                case 2:
                    Console.WriteLine("2 Players: 4 Lament Wretches, 1 Boomer");
                    break;
                case 3:
                    Console.WriteLine("3 Players: 4 Lament Wretches, 2 Boomers");
                    break;
                case 4:
                    Console.WriteLine("4 Players: 6 Lament Wretches, 2 Boomers");
                    break;
            }
            Console.WriteLine("THEN PROCEED TO THE NEXT STAGE\n");
            CreateLocustAiCardDeck(3);
        }

        private void StageThreeEnd()
        {
            Console.WriteLine("\nDiscard all sealed emergence hole tokens, then turn all");
            Console.WriteLine("Ammunition Location cards faceup. Then update");
            Console.WriteLine("the AI deck and Enemy cards to reflect the following:");
            Console.WriteLine("A: Ticker, B: Kantus, C: None\n");
            Console.WriteLine("Finally, shuffle the AI discard pile into the deck and spawn the");
            Console.WriteLine("following figures at emergence holes (as evenly as possible).");
            switch (_numberOfPlayers)
            {
                case 1:
                    Console.WriteLine("1 Player: 2 Tickers, 1 Kantus");
                    break;
                case 2:
                    Console.WriteLine("2 Players: 4 Tickers, 1 Kantus");
                    break;
                case 3:
                    Console.WriteLine("3 Players: 4 Tickers, 2 Kantus");
                    break;
                case 4:
                    Console.WriteLine("4 Players: 4 Tickers, 3 Kantus");
                    break;
            }
            Console.WriteLine("THEN PROCEED TO THE NEXT STAGE\n");
            CreateLocustAiCardDeck(4);
        }

        private void StageFourEnd()
        {
            Console.WriteLine("\nDiscard all sealed emergence hole tokens, then turn all");
            Console.WriteLine("Ammunition Location cards faceup. Then update");
            Console.WriteLine("the AI deck and Enemy cards to reflect the following:");
            Console.WriteLine("A: Ticker, B: Kantus, C: Theron Guard\n");
            Console.WriteLine("Finally, shuffle the AI discard pile into the deck and spawn the");
            Console.WriteLine("following figures at emergence holes (as evenly as possible).");
            switch (_numberOfPlayers)
            {
                case 1:
                    Console.WriteLine("1 Player: 1 Kantus, 1 Theron Guard");
                    break;
                case 2:
                    Console.WriteLine("2 Players: 1 Kantus, 2 Theron Guards");
                    break;
                case 3:
                    Console.WriteLine("3 Players: 2 Kantus, 2 Theron Guards");
                    break;
                case 4:
                    Console.WriteLine("4 Players: 2 Kantus, 3 Theron Guards");
                    break;
            }
            Console.WriteLine("THEN PROCEED TO THE NEXT STAGE\n");
            CreateLocustAiCardDeck(5);
        }

        private void StageFiveEnd()
        {
            Console.WriteLine("\nDiscard all sealed emergence hole tokens, Players then");
            Console.WriteLine("choose a player to receive the \"Hammer of Dawn\" Weapon card.");
            Console.WriteLine("Then update the AI deck and Enemy cards to reflect the following:");
            Console.WriteLine("A: Drone, B: Grinder, C: Berserker\n");
            Console.WriteLine("Finally, shuffle the AI discard pile into the deck and spawn the");
            Console.WriteLine("following figures at emergence holes (as evenly as possible).");
            switch (_numberOfPlayers)
            {
                case 1:
                    Console.WriteLine("1 Player: 1 Drone, 1 Grinder, 1 Berserker");
                    break;
                case 2:
                    Console.WriteLine("2 Players: 2 Drones, 2 Grinders, 1 Berserker");
                    break;
                case 3:
                    Console.WriteLine("3 Players: 4 Drones, 2 Grinders, 1 Berserker");
                    break;
                case 4:
                    Console.WriteLine("4 Players: 5 Drones, 3 Grinders, 1 Berserker");
                    break;
            }
            Console.WriteLine("THEN PROCEED TO THE NEXT STAGE\n");
            CreateLocustAiCardDeck(6);
        }

        private void MissionEnd()
        {
            Console.WriteLine("\n\"Myrrah: They do not understand. They do not know why we wage");
            Console.WriteLine("this war. Why we will fight, and fight and fight... Until we win...");
            Console.WriteLine("Or we die... And we are not dead yet.\"\n");
            Console.WriteLine("YOU WIN THE GAME\n");
            WaitForGameToEnd();
        }

        private void MissionSpecifics()
        {
            Console.WriteLine("Would you like to view the Mission Specifics Y/N?");
#pragma warning disable CS8602 // Dereference of a possibly null reference.
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
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            Console.WriteLine("\nHORDE MODE\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Maps Size: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Variable\n");
            Console.WriteLine("This mission pits players against increasingly difficult");
            Console.WriteLine("waves of enemies. Players need to kill all enemies in all");
            Console.WriteLine("six stages to win the game.\n");
            Console.WriteLine("This mission is recommended for experienced players.");
            Console.WriteLine("The different difficulty settings provide a large amount of");
            Console.WriteLine("replayability.\n");
            Console.WriteLine("Tip: If you are badly wounded, it is sometimes worthwile");
            Console.WriteLine("to not kill the last enemy of a stage to provide time for");
            Console.WriteLine("your team to regain health.\n");
            Console.WriteLine("RULE CLARIFICATIONS:");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("@ Difficulty Settings: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("During setup, players choose");
            Console.WriteLine("\twhich diffictuly setting they wish to use for this");
            Console.WriteLine("\tsession. This choice will determine how dense");
            Console.WriteLine("\tthe map is and how many new wapons will be");
            Console.WriteLine("\tavailable. Regardless of their choice, the map");
            Console.WriteLine("\talways consists of a single level (there is no");
            Console.WriteLine("\texploring in this mission).\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("@ Ammo and Grenade Pickups: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Ammo and Grenade");
            Console.WriteLine("\tLocation cards are not discarded after use. Instead,");
            Console.WriteLine("\tthe Location card is turned facedown and may");
            Console.WriteLine("\tnot be used until turned faceup by completing the");
            Console.WriteLine("\tstage's objective.\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("@ Waves: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("At the end of each stage of this mission,");
            Console.WriteLine("\tplayers are required to change the Enemy cards");
            Console.WriteLine("\tand AI deck as specified on the Mission card. This");
            Console.WriteLine("\tfollows the same rules that players would perform");
            Console.WriteLine("\tduring setup (remove all cards from the AI deck");
            Console.WriteLine("\tthat do no match the \"A\", \"B\", or \"C\" Enemy cards).\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("@ Spawning: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Most Misison cards instruct the players to");
            Console.WriteLine("\tspawn Locust figures \"as evenly as possible\". Players");
            Console.WriteLine("\tmay spawn these figures however they wish, as long");
            Console.WriteLine("\tas they do not place a second Locust figure into the");
            Console.WriteLine("\tsame area unless each emergence hole area has at");
            Console.WriteLine("\tleast one Locust figure. Likewise, they cannot place");
            Console.WriteLine("\ta third figure in an area unless each emergence");
            Console.WriteLine("\thole area has at least two Locust figures.\n");
            Console.WriteLine("Press Y to contine");

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            switch (Console.ReadLine().ToUpper())
            {
                case "Y":
                    break;
                default:
                    MissionSpecifics();
                    break;
            }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }
    }
}
