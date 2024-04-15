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

        public void SetupMission()
        {
            Console.WriteLine("Would you like the computer to draw AI Locust cards? Y/N");
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
            Console.WriteLine("options.\n");
            Console.WriteLine("Enemies");
            Console.WriteLine("A: Wretch");
            Console.WriteLine("B: Drone");
            Console.WriteLine("C: None\n");
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
                Console.WriteLine("\nHas a COG attempted to explore\n through the door at the end\n of level 1 Y/N?");

                switch (Console.ReadLine().ToUpper())
                {
                    case "Y":
                        _isStageOneActivated = false;
                        _isStageTwoActivated = true;
                        _stageNumber = 2;
                        StageOneEnd();
                        DisplayLocationCardDeck(2);
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
                Console.WriteLine("\nHas a COG attempted to explore\n through the door at the end\n of level 2 Y/N?");

                switch (Console.ReadLine().ToUpper())
                {
                    case "Y":
                        _isStageTwoActivated = false;
                        _isStageThreeActivated = true;
                        StageTwoEnd();
                        DisplayLocationCardDeck(3);
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
                Console.WriteLine("\nAre all COG figures on map 17B,\n no COG figures are bleeding out,\n and there are no Grinders in play Y/N?");

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

        private void StageOneBanner()
        {
            Console.WriteLine("\nSpecial Rules:\n");
            Console.WriteLine("COGs cannot explore though the");
            Console.WriteLine("door at the exit of level 2.\n");
            Console.WriteLine("When a player resolves an AI");
            Console.WriteLine("card, it only affects Locust on");
            Console.WriteLine("his map.\n");
            Console.WriteLine("Objective: A COG attempts to explore");
            Console.WriteLine("through the door at the end");
            Console.WriteLine("of level 1.\n");
        }

        private void StageTwoBanner()
        {
            Console.WriteLine("\nSpecial Rules:\n");
            Console.WriteLine("COGs cannot explore through the");
            Console.WriteLine("door at the exit of level 3.\n");
            Console.WriteLine("When a player resolves an AI");
            Console.WriteLine("card, it only affects Locusts on");
            Console.WriteLine("his map.\n");
            Console.WriteLine("Objective: A COG attempts to explore");
            Console.WriteLine("through the door at the end");
            Console.WriteLine("of level 2.\n");
        }

        private void StageThreeBanner()
        {
            Console.WriteLine("\nSpecial Rules:\n");
            Console.WriteLine("Areas that contain doors are");
            Console.WriteLine("considered adjacent for figure");
            Console.WriteLine("movement.\n");
            Console.WriteLine("Figures may not attack");
            Console.WriteLine("through doors.");
            Console.WriteLine("Objective: All COG figures are on map 17B,");
            Console.WriteLine("no COG figures are bleeding out,");
            Console.WriteLine("and there are no Grinders in play.\n");
        }

        private void StageOneEnd()
        {
            Console.WriteLine("\n\"Dom: so this is what the intter hollow looks like.\"");
            Console.WriteLine("Carmine: Sarge! Can you hear me?");
            Console.WriteLine("Fenix: Carmine, what's your position?");
            Console.WriteLine("Carmine: Not really sure, sir. I think my lift went off course.\n");
            Console.WriteLine("Explore level 3 of the map, spawning Locust figures based on the");
            Console.WriteLine("number of players on that map. Then place a door at the end of level 3.\n");
            Console.WriteLine("THEN PROCEED TO THE NEXT STAGE\n");
            //TODO: Press Y to Continue
        }

        private void StageTwoEnd()
        {
            Console.WriteLine("\n\"Fenix: Hold them off so that Jack can fix the lift!\"\n");
            Console.WriteLine("Place map tile 17B at the end of level 2 (do not use the");
            Console.WriteLine("Location card for equipment or spawning). Then place a");
            Console.WriteLine("door at the exit of map tile 17B.\n");
            Console.WriteLine("Remove all Boomers from the map. Then replace the Boomer");
            Console.WriteLine("Enemy card with the Grinder Enemy card. Each player spawns 1");
            Console.WriteLine("Grinder on any empty area of Map Tile 17B. In a four-player game,");
            Console.WriteLine("Kantus and Boomer figures may be used as Grinders.\n");
            Console.WriteLine("THEN PROCEED TO THE NEXT STAGE\n");
            //TODO: Press Y to Continue
        }

        private void MissionEnd()
        {
            //CancellationTokenSource.Cancel();
            Console.WriteLine("\n\"Control: Delta, according to Jack that grindlift should be operation now.");
            Console.WriteLine("Fenix: Thanks Control. All right, let;s give this lift a shove.\"\n");
            Console.WriteLine("YOU WIN THE GAME\n");
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
            Console.WriteLine("and AI deck as specified on the Mission card. This");
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
}
