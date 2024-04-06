using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearsOfWarTheBoardGameConsole.View.Missions
{
    internal class HiveMissionSix
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
            Console.WriteLine("Tip: If a Locust figure drops a wapon, try to pick it up as");
            Console.WriteLine("soon as possible. This prevents a Kantus from reviving this");
            Console.WriteLine("figure and provides players with much-needed ammunition.\n");
            Console.WriteLine("RULE CLARIFICATIONS:");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("@ Kantus Resurrection: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("AI card #33 allows a Kantus");
            Console.WriteLine("\tfigure to flip over a dropped wapon marker and");
            Console.WriteLine("\tspawn a Locust figure on top of it. If all of the");
            Console.WriteLine("\tmatching figures are already in play, no figure");
            Console.WriteLine("\tis spawned. Then discard the dropped wapon");
            Console.WriteLine("\tmarker from the map.\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("@ Kantus Healing: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("AI card #32 moves a Kantus figure");
            Console.WriteLine("\ttoward a wounded Locust figure and then heals");
            Console.WriteLine("\tit. To do so, simply discard the wounded figure's");
            Console.WriteLine("\twound marker to the pile of unused tokens. A");
            Console.WriteLine("\tKantus figure cannot heal itself.");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("@ Removing figures from the Map: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("When the final");
            Console.WriteLine("\tstage removes figures from the map, discard all");
            Console.WriteLine("\tof the figures' wound markers (excluding dropped");
            Console.WriteLine("\tweapons).\n");

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
