using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearsOfWarTheBoardGameConsole.View.Missions
{
    internal class HiveMissionSix : GearsOfWarMission
    {
        private int _playerInterator = 1;
        private int _numberOfPlayers;
        private int _stageNumber;
        private bool _isStageOneActivated;
        private bool _isStageTwoActivated;

        public HiveMissionSix(int numberOfPlayers, int missionNumber) : base(numberOfPlayers, missionNumber)
        {
            _numberOfPlayers = numberOfPlayers;
            _isStageOneActivated = true;
            IsGameStillGoing = true;
            _stageNumber = 1;
            //SetupAudio(@"C:\Dev\VisualStudioCode\GearsOfWarTheBoardGameConsole\Music\HoldThemOff.mp3");
            MissionSpecifics();
            CreateLocationCardDeck();
            DisplayLocationCardDeck(0);
            DisplayLocationCardDeck(1);
            DisplayLocationCardDeck(2);
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
            Console.WriteLine(@"                       ___ ___ .__                    ");
            Console.WriteLine(@"                      /   |   \|__|__  __ ____        ");
            Console.WriteLine(@"                     /    ~    \  \  \/ // __ \       ");
            Console.WriteLine(@"                     \    Y    /  |\   /\  ___/       ");
            Console.WriteLine(@"                      \___|_  /|__| \_/  \___  >      ");
            Console.WriteLine(@"                            \/               \/       ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nMission Setup\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Special Rules:\n");
            Console.WriteLine("None.\n");
            Console.WriteLine("Enemies");
            Console.WriteLine("A: Drone");
            Console.WriteLine("B: Kantus");
            Console.WriteLine("C: Theron Guard\n");
            Console.WriteLine("General AI: 2, 4, 5, 6\n");
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
                Console.WriteLine("\nHas a COG explored the door\n at the exit lof level 3 Y/N?");

#pragma warning disable CS8602 // Dereference of a possibly null reference.
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
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            }

            if (_isStageTwoActivated)
            {
                Console.WriteLine("\nHas Skorge been killed Y/N?");

#pragma warning disable CS8602 // Dereference of a possibly null reference.
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
#pragma warning restore CS8602 // Dereference of a possibly null reference.
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
            Console.WriteLine("None.\n");
            Console.WriteLine("Objective: A COG explores the door");
            Console.WriteLine("at the exit of level 3.\n");
        }

        private void StageTwoBanner()
        {
            Console.WriteLine("\nSpecial Rules:\n");
            Console.WriteLine("Kantus figures cannot be");
            Console.WriteLine("spawned.\n");
            Console.WriteLine("Heal Skorge at the end of each");
            Console.WriteLine("Locust Activation step if he did");
            Console.WriteLine("not move or attack.\n");
            Console.WriteLine("Objective: Skorge is killed.\n");
        }

        private void StageOneEnd()
        {
            Console.WriteLine("\n\"Myrrah: Tell me, is it true? You're the son of Adam Fenix?");
            Console.WriteLine("Fenix: What's it to you?");
            Console.WriteLine("Myrrah: He spoke highly of you. It's a shame you didn't follow his path.");
            Console.WriteLine("Fenix: What the hell are you talking about?");
            Console.WriteLine("Myrrah: It no longer matters. Skorge, destroy them!\"\n");
            Console.WriteLine("Place map tile 17B at the map exit (do not use the Location card for");
            Console.WriteLine("equipment ord spawning). Then remove all Kantus from the amp and");
            Console.WriteLine("replace the Kantus Enemy card with the Skorge Enemy card.");
            Console.WriteLine("Then spawn Skorge on the map tile 17B's equipment area.\n");
            Console.WriteLine("THEN PROCEED TO THE NEXT STAGE\n");
            //TODO: Press Y to Continue
        }

        private void MissionEnd()
        {
            Console.WriteLine("\n You meet up with the rest of your squad\n");
            Console.WriteLine("\"Carmine: Where's the Queen?");
            Console.WriteLine("Baird: She escaped on a reaver!");
            Console.WriteLine("Carmine: Which way did she go?");
            Console.WriteLine("Fenix: Forget the Queen. We need to find a way back to Jacinto");
            Console.WriteLine("Baird: Well, there are those two reavers back there.");
            Console.WriteLine("Fenix: It's worth a shot. Move out!\"\n");
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
            Console.WriteLine("\nHIVE\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Maps Size: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Large\n");
            Console.WriteLine("In this mission, the COG soldiers must breach Nexus, the");
            Console.WriteLine("Locust underground stronghold. The hope is to turn the");
            Console.WriteLine("offensive on the Locust and to finally confront Myrrah,");
            Console.WriteLine("queen of the Locust horde. Plans quickly fall apart when");
            Console.WriteLine("she escapes, leaving General Skorge to deal with the COGs.\n");
            Console.WriteLine("Tip: If a Locust figure drops a weapon, try to pick it up as");
            Console.WriteLine("soon as possible. This prevents a Kantus from reviving this");
            Console.WriteLine("figure and provides players with much-needed ammunition.\n");
            Console.WriteLine("RULE CLARIFICATIONS:");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("@ Kantus Resurrection: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("AI card #33 allows a Kantus");
            Console.WriteLine("\tfigure to flip over a dropped weapon marker and");
            Console.WriteLine("\tspawn a Locust figure on top of it. If all of the");
            Console.WriteLine("\tmatching figures are already in play, no figure");
            Console.WriteLine("\tis spawned. Then discard the dropped weapon");
            Console.WriteLine("\tmarker from the map.\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("@ Kantus Healing: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("AI card #32 moves a Kantus figure");
            Console.WriteLine("\ttoward a wounded Locust figure and then heals");
            Console.WriteLine("\tit. To do so, simply discard the wounded figure's");
            Console.WriteLine("\twound marker to the pile of unused tokens. A");
            Console.WriteLine("\tKantus figure cannot heal itself.\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("@ Removing figures from the Map: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("When the final");
            Console.WriteLine("\tstage removes figures from the map, discard all");
            Console.WriteLine("\tof the figures' wound markers (excluding dropped");
            Console.WriteLine("\tweapons).\n");
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
