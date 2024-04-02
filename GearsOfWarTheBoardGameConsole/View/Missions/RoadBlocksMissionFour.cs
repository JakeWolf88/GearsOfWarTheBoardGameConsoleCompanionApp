﻿namespace GearsOfWarTheBoardGameConsole.View.Missions
{
    public class RoadBlocksMissionFour : GearsOfWarMission
    {
        private int _playerInterator = 1;
        private int _numberOfPlayers;
        private int _stageNumber;
        private bool _isStageOneActivated;
        private bool _isStageTwoActivated;
        private bool _isGameStillGoing;

        public RoadBlocksMissionFour(int numberOfPlayers, int missionNumber) : base(numberOfPlayers, missionNumber)
        {
            _numberOfPlayers = numberOfPlayers;
            _isStageOneActivated = true;
            _isGameStillGoing = true;
            _stageNumber = 1;
            //SetupAudio(@"C:\Dev\VisualStudioCode\GearsOfWarTheBoardGameConsole\Music\GearsOfWar.mp3");
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
            Console.WriteLine(@"                        __________                    ._____________ .__                    __                    ");
            Console.WriteLine(@"                        \______   \  ____ _____     __| _/\______   \|  |    ____    ____  |  | __  ______        ");
            Console.WriteLine(@"                         |       _/ /  _ \\__  \   / __ |  |    |  _/|  |   /  _ \ _/ ___\ |  |/ / /  ___/        ");
            Console.WriteLine(@"                         |    |   \(  <_> )/ __ \_/ /_/ |  |    |   \|  |__(  <_> )\  \___ |    <  \___ \         ");
            Console.WriteLine(@"                         |____|_  / \____/(____  /\____ |  |______  /|____/ \____/  \___  >|__|_ \/____  >        ");
            Console.WriteLine(@"                                \/             \/      \/         \/                    \/      \/     \/         ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nMission Setup\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Special Rules:\n");
            Console.WriteLine("Only draw and set up the first");
            Console.WriteLine("Location card from Level 1.\n");
            Console.WriteLine("Instead of spawning based on the");
            Console.WriteLine("Location card, each player spawns");
            Console.WriteLine("1 Ticker on any empty area.\n");
            Console.WriteLine("Enemies");
            Console.WriteLine("A: Ticker");
            Console.WriteLine("B: None");
            Console.WriteLine("C: None\n");
            Console.WriteLine("General AI: 1, 2, 3, 4, 5, 7\n");
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
                Console.WriteLine("\nHas a COG entered the last\n map tile on this level Y/N?");

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
                Console.WriteLine("\nAre all COG figures at\n the map exit on level 2\n or level 3 and zero COG\n figures are bleeding out. Y/N?");

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
            Console.WriteLine("When a COG figure enters the");
            Console.WriteLine("map exit, he automatically");
            Console.WriteLine("explores the next level 1 location.");
            Console.WriteLine("Instead of spawning based on the");
            Console.WriteLine("Location card, each player spawns");
            Console.WriteLine("1 Ticker on any empty area\n");
            Console.WriteLine("Objective: A COG enters the last");
            Console.WriteLine("map tile on this level.\n");
        }

        private void StageTwoBanner()
        {
            Console.WriteLine("\nSpecial Rules:\n");
            Console.WriteLine("When a COG explores, he");
            Console.WriteLine("explores the unlocked level.\n");
            Console.WriteLine("When a Drone or Boomer spawns");
            Console.WriteLine("from an AI card, place it on the map");
            Console.WriteLine("exit (instead of an emergence hole).\n");
            Console.WriteLine("Objective: All COG figurtes are at");
            Console.WriteLine("the map exit on level 2");
            Console.WriteLine("or level 3 and zero COG");
            Console.WriteLine("figures are bleeding out.\n");
        }

        private void StageOneEnd()
        {
            Console.WriteLine("\n\"Fenix: Ok, time to go home. Baird, you set up the resonator,");
            Console.WriteLine("we'll get that elevator back online\n");
            Console.WriteLine("Shuffle the AI discard pile into the deck. Each player then");
            Console.WriteLine("spawns 1 Locust B at an emergence hole on map tile 13B.\n");
            Console.WriteLine("THEN PROCEED TO THE NEXT STAGE\n");
            CreateLocustAiCardDeck(1);
            DisplayLocationCardDeck(2);
            //TODO: Press Y to Continue
        }

        private void MissionEnd()
        {
            CancellationTokenSource.Cancel();
            Console.WriteLine("\n\"Fenix: Control, this is Delta. We're clear. Resenator has been detonated.");
            Console.WriteLine("Control: You did it Marcus. Stand by. King ravens are en route.\"");
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
            Console.WriteLine("\nROADBLOCKS\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Maps Size: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Medium\n");
            Console.WriteLine("Stranded in the town of Landown, the COGs must make");
            Console.WriteLine("their way through dark tunnels and bombed out streets to");
            Console.WriteLine("clear the way for the COG offensive.\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Tips: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Interrupt Ticker movement with a guard reaction");
            Console.WriteLine("ability in order to destroy it while in another Ticker's area.\n");
            Console.WriteLine("Remember to resolve each Locust move and attack before");
            Console.WriteLine("activating the next figure. The active player should use");
            Console.WriteLine("this to his advantage by choosing to activate further-away");
            Console.WriteLine("enemies first.\n");
            Console.WriteLine("RULE CLARIFICATIONS:\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("@ Setup: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Take the Level 1 Location deck and place it");
            Console.WriteLine("\tnext to the Mission deck. Each time a COG explores");
            Console.WriteLine("\tduring stage 1, he draws a single card from this");
            Console.WriteLine("\tdeck and explores it as normal.\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("@ Stage 1 Spawning: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("When exploring, do not spawn");
            Console.WriteLine("\tplayer spawns 1 Ticker on any empty area of the");
            Console.WriteLine("\tfigures based on the Location card. Instead, each");
            Console.WriteLine("\tnew map tile. An area is considered empty if there");
            Console.WriteLine("\tare no figures in it. If there are no empty areas on");
            Console.WriteLine("\tthe map tile, the player may spawn his Ticker in");
            Console.WriteLine("\tany area of the map tile.\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("@ Chain Reactions: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("When a Ticker is killed (except after");
            Console.WriteLine("\tattacking or being killed by a Bolo Grenade), it deals 1");
            Console.WriteLine("\twound to each figure in it's area (including Locusts).\n");
            Console.WriteLine("\tExample: There are three Tickers in Marucs Fenix's");
            Console.WriteLine("\tarea and he kills one of them. It deals him 1 wound");
            Console.WriteLine("\tand deals 1 wound to each other Ticker in his area.");
            Console.WriteLine("\tSince this wound kills the other two Tickers, they also");
            Console.WriteLine("\tdeal Marcus 1 wound each (for a total of 3 wounds");
            Console.WriteLine("\tdealt to Marcus).\n");
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
}