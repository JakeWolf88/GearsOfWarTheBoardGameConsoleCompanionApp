using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearsOfWarTheBoardGameConsole.Model
{
    public static class Faq
    {
        public static void FaqVersionOnePointOne()
        {
            Console.WriteLine("FAQ VERSION 1.1 - 4/23/2014\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ERRATA");
            Console.ForegroundColor= ConsoleColor.White;
            Console.WriteLine("@ The Roadblocks stage 1 Misison Card has a typo.");
            Console.WriteLine("\t Leve 3 should list rooms \"5A, 12A, 16A\".\n");
            Console.WriteLine("@ The initial printing of Gears of War has a few");
            Console.WriteLine("\tincorrect quantities in the component List. The list");
            Console.WriteLine("\tshould read:");
            Console.WriteLine("\t * 22 Wound/Dropped Weapon Markers");
            Console.WriteLine("\t * 14 Grenade Tokens");
            Console.WriteLine("\t * 44 Ammo Tokens\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("FREQUENTLY ASKED QUESTIONS");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("WEAPONS");
            Console.WriteLine("Q: How does the \"Mulcher\" Wepon card interact with the");
            Console.WriteLine("\"Follow\" reaction ability?");
            Console.WriteLine("A: The Mulcher only slows down the player's movement");
            Console.WriteLine("during his own  turn. He may follow other COGs as normal.\n");
            Console.WriteLine("Q: What areas are considered adjacent for the \"Mortar\"");
            Console.WriteLine("weapon's special ability?");
            Console.WriteLine("A: This ability affects areas that share a cracked movement");
            Console.WriteLine("border or blue elevation border with the target area.\n");
            Console.WriteLine("Q: Can a player use a \"Guard\" reaction ability with a \"Torque");
            Console.WriteLine("Bow\" even if he moved during the same turn?");
            Console.WriteLine("A: No.\n");
            Console.WriteLine("Q: Can a player trigger the \"Mulcher\" Weapon card's special");
            Console.WriteLine("ability when the wapon has 0 ammo tokens?");
            Console.WriteLine("A: No\n");
            Console.WriteLine("Q: Can a player use \"Bolo Grenades\" while wielding the");
            Console.WriteLine("\"BoomShield\"?");
            Console.WriteLine("A: No\n");
            Console.WriteLine("Q: When a card (such as the \"Scavenging\" Order card) specificially");
            Console.WriteLine("referes to ammo tokens, does it also refer to grenades?");
            Console.WriteLine("A: No\n");
            Console.WriteLine("ORDERS");
            Console.WriteLine("Q: Can a player use the \"Scavenging\" Order card to gain 1");
            Console.WriteLine("ammo token for the \"Hammer of Dawn\"?");
            Console.WriteLine("A: Yes\n");
            Console.WriteLine("Q: Can a player use the\"Ambush\" card, to attack with a");
            Console.WriteLine("wapon that has 0 ammo?");
            Console.WriteLine("A: No.\n");
            Console.WriteLine("Q: When I play the \"Ambush\" card can I attack with the");
            Console.WriteLine("\"Hammer of Dawn\" (with an ammo token on it) without");
            Console.WriteLine("spending the ammo token?");
            Console.WriteLine("A: Yes.\n");
            Console.WriteLine("Q: Player 1 plays the \"Teamwork\" card on player 2. If player");
            Console.WriteLine("2 uses the \"Sit Tight\" card, will players skip the Locust");
            Console.WriteLine("Activiation Step this turn?");
            Console.WriteLine("A: Yes.\n");
            Console.WriteLine("Q: If a Locust figure is moved as the result of Order cards");
            Console.WriteLine("such as \"Sight Tight\" or \"Ambush\", does the Locust take cover");
            Console.WriteLine("after it is moved?");
            Console.WriteLine("A: Yes, following normal rules for Locusts taking cover\n");
            Console.WriteLine("Can a player use the \"Ambush\" Order card even if he will");
            Console.WriteLine("be unable to attack the enemey?");
            Console.WriteLine("A: Yes. He is still required to have line of sight to the");
            Console.WriteLine("enemy in order to attack it.\n");
            Console.WriteLine("LOCUSTS AND AI");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
        }

        public static void SinglePlayerRules()
        {
            Console.WriteLine("SOLO RULES:");
            Console.WriteLine("When playing Gears of War: The Board Game alone (as the");
            Console.WriteLine("only player). The player controls a single COG figure.\n");
            Console.WriteLine("Some Order cards are more useful if playing with two or");
            Console.WriteLine("more players. If a player draws one of these Order cards");
            Console.WriteLine("(marked with a \"2+\" in the lower-right corner) when using");
            Console.WriteLine("this option, he may remove this card from the game at");
            Console.WriteLine("any time during his Order step to draw a new Order card.\n");
            Console.WriteLine("The \"Scattered\" mission may not be played when using ");
            Console.WriteLine("this optional rule.\n");
            Console.WriteLine("When playing solo, the follow reaction ability allows");
            Console.WriteLine("the player to discard this card and move his figure one");
            Console.WriteLine("additional area at any point during his Order step. He may");
            Console.WriteLine("only use one follow reaction ability per turn.\n");
        }

        public static void InsaneDifficultyRules()
        {
            Console.WriteLine("INSANE DIFFICULTY");
            Console.WriteLine("This option makes the game faster and more challenging.");
            Console.WriteLine("When using this option, apply the following rules changes.");
            Console.WriteLine("@ When a COG is dealt wounds, the player must");
            Console.WriteLine("\tdiscard Order cards from his hand at random.\n");
            Console.WriteLine("@ Locust figures can attack COG figures that are");
            Console.WriteLine("\t bleeding out as long as they are in the same area.");
            Console.WriteLine("\tNo dice are rolled, and the player is executed");
            Console.WriteLine("\t(eliminated from the game). The payer no longer");
            Console.WriteLine("\trecieves a turn, but an AI card is still resolved when");
            Console.WriteLine("\this turn would have occurred. All players can still");
            Console.WriteLine("\twin the game if the other suviving players manage");
            Console.WriteLine("\tto fulfill the mission's objective.");
        }

        public static void MissionPackOneFaqs()
        {
            Console.WriteLine("New Card Clarifications\n");
            Console.WriteLine("Scorcher Special Weapon Cards");
            Console.WriteLine("These new Special Wapon cards are");
            Console.WriteLine("added to the existing deck of");
            Console.WriteLine("Special Wapon cards\n");
            Console.WriteLine("General RAAM Enemy Card");   
            Console.WriteLine("The general RAAM Enemy card has");
            Console.WriteLine("two unique sides (Side A and Side B).");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
        }


    }
}
