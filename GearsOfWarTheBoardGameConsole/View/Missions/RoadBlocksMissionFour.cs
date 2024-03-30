namespace GearsOfWarTheBoardGameConsole.View.Missions
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
            SetupAudio(@"C:\Dev\VisualStudioCode\GearsOfWarTheBoardGameConsole\Music\GearsOfWar.mp3");
            MissionSpecifics();
            CreateLocationCardDeck();
            //StartMission();
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
            Console.WriteLine("\nBELLY OF THE BEAST\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Maps Size: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Medium\n");
            Console.WriteLine("This mission sends the COG soldiers deep into the");
            Console.WriteLine("mines, searching for the ideal location to place the sonic");
            Console.WriteLine("resonator. This subsonice device will hopefully return a");
            Console.WriteLine("detailed map of the Locust holows so that the COG can");
            Console.WriteLine("destroy them once and for all whith the Lightmass bomb.\n");
            Console.WriteLine("RULE CLARIFICATIONS:");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("@ Setup: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("This mission is unique in that there are two\n");
            Console.WriteLine("\texits to the map. After setting up the first level,");
            Console.WriteLine("\tthe first map tile that was placed is rotated so that");
            Console.WriteLine("\tit's entrance lines up with the second map tile's");
            Console.WriteLine("\tentrance (see example below).\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("@ Two Doors: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("During setup, two doors are placed on\n");
            Console.WriteLine("\tthe map. The second door is placed on the exit of");
            Console.WriteLine("\tthe first map tile and leads to the third level of the");
            Console.WriteLine("\tmap (see example below). If an AI card spawns");
            Console.WriteLine("\tfigures at the map exit, these figures are spawned");
            Console.WriteLine("\tat the map exit nearestto the active player.\n");

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
