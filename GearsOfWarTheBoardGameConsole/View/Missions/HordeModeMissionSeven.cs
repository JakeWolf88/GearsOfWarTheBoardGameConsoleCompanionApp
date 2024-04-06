using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearsOfWarTheBoardGameConsole.View.Missions
{
    internal class HordeModeMissionSeven
    {

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
