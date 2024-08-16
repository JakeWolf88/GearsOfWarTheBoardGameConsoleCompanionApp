namespace GearsOfWarTheBoardGameConsole.View.Missions
{
    internal class ScatteredMissionFive : GearsOfWarMission
    {
        private int _playerIterator = 1;
        private int _numberOfPlayers;
        private int _stageNumber;
        private bool _isStageOneActivated;
        private bool _isStageTwoActivated;
        private bool _isStageThreeActivated;

        public ScatteredMissionFive(int numberOfPlayers, int missionNumber) : base(numberOfPlayers, missionNumber)
        {
            //TODO: Figure out a way to properly disply location deck AI based on number of players and add music!
            _numberOfPlayers = numberOfPlayers;
            _isStageOneActivated = true;
            IsGameStillGoing = true;
            _stageNumber = 1;
            SetupAudioContinually(GearsOfWarMission.BasePath + @"\Music\GearsOfWar2SoundTrack\Hollow.mp3");
            MissionSpecifics();
            CreateLocationCardDeck();
            DisplayLocationCardDeck(0);
            DisplayLocationCardDeck(1);
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
            Console.WriteLine(@"                        _________              __    __                           .___    ");
            Console.WriteLine(@"                       /   _____/ ____ _____ _/  |__/  |_  ___________   ____   __| _/    ");
            Console.WriteLine(@"                       \_____  \_/ ___\\__  \\   __\   __\/ __ \_  __ \_/ __ \ / __ |     ");
            Console.WriteLine(@"                       /        \  \___ / __ \|  |  |  | \  ___/|  | \/\  ___// /_/ |     ");
            Console.WriteLine(@"                      /_______  /\___  >____  /__|  |__|  \___  >__|    \___  >____ |     ");
            Console.WriteLine(@"                              \/     \/     \/                \/            \/     \/    ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nMission Setup\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Special Rules:\n");
            Console.WriteLine("Set up levels 1 and 2 as two");
            Console.WriteLine("separate (non-connected) maps.");
            Console.WriteLine("Then move half the COGs to the");
            Console.WriteLine("entrance of level 2. Spawn starting");
            Console.WriteLine("Locust figures based on the");
            Console.WriteLine("number of COGs on each map.\n");
            Console.WriteLine("Enemies");
            Console.WriteLine("A: Drone");
            Console.WriteLine("B: Ticker");
            Console.WriteLine("C: Boomer\n");
            Console.WriteLine("General AI: 1, 3, 4, 5, 6, 7\n");
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
        }

        private void MissionEnd()
        {
            CancelMusic();
            SetupAudioOneTime(GearsOfWarMission.BasePath + @"\Music\GearsofWarInGameMusicBossBattleVictory.mp3");
            Console.WriteLine("\n\"Control: Delta, according to Jack that grindlift should be operation now.");
            Console.WriteLine("Fenix: Thanks Control. All right, let;s give this lift a shove.\"\n");
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
            Console.WriteLine("\nSCATTERED\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Maps Size: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Large\n");
            Console.WriteLine("This mission splits up COG players into two teams deep");
            Console.WriteLine("within the Locust hollows. One team must remotely open");
            Console.WriteLine("The locked door in order to bring the COGs together for");
            Console.WriteLine("the thrilling finale.\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("This scenario may only be played with two ore more players\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("RULE CLARIFICATIONS");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("@ Map Setup: \n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Before playing, set up level 1 and level");
            Console.WriteLine("\t2 as two separate (non-connected) maps. Players");
            Console.WriteLine("\tmust then agree upon which COG characters will");
            Console.WriteLine("\tstart on each map. These figures are placed on the");
            Console.WriteLine("\tentrance area of their map.\n");
            Console.WriteLine("\tIf playing with three players, one COG will be on");
            Console.WriteLine("\tone map and two COGs will be on the other map.\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("@ Setup Spawning: \n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("When spawning Locust figures");
            Console.WriteLine("\tduring setup, use the number at the bottom based");
            Console.WriteLine("\tupon the number of COG figures on that map. For");
            Console.WriteLine("\texample, if playing a four-player game, the \"2\"");
            Console.WriteLine("\tsection of Location cards would be used for setup.\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("@ Order Cards: \n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Some order cards provide bonuses to");
            Console.WriteLine("\tother COG players (such as \"Teamworks\" and \"Digin\"");
            Console.WriteLine("\t). These cards affect all COG players, regardless");
            Console.WriteLine("\tof which map they are on.\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("@ AI Cards: \n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\tDuring stages 1 and 2, when player");
            Console.WriteLine("\tresolves an AI card, it only affets figures on his");
            Console.WriteLine("\tmap. For example if a player draws Drone AI");
            Console.WriteLine("\tcard #13 and there are no Drones on his map, he");
            Console.WriteLine("\tdiscards this card and draws a new AI card.\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("@ Removing Figures from the Map: \n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("When the final");
            Console.WriteLine("\tstage removes figures from the map, discard all of the");
            Console.WriteLine("\tfigures' wound markers (excluding dropped wapons).\n");
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
