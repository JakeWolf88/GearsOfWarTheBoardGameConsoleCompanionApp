using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearsOfWarTheBoardGameConsole.View.Missions
{
    internal class ScatteredMissionFive
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
            Console.WriteLine("\tsection of Loxation cards would be used for setup.\n");
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
            Console.WriteLine("\tfigures' wound markers (excluding dropped wapons).");

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
