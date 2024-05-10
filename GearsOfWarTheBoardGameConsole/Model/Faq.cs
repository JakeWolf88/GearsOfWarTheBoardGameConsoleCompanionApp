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
            Console.WriteLine("\t Level 3 should list rooms \"5A, 12A, 16A\".\n");
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
            Console.WriteLine("LOCUSTS AND AI\n");
            Console.WriteLine("Q: The \"Firefight\" AI card says \"Then, each Locust that did");
            Console.WriteLine("notattack 2 areas\". Does this refer to ALL Locust");
            Console.WriteLine("figures in play or just the ones that are listed on the card?");
            Console.WriteLine("A: This reveres to every Locust in play (and not just the");
            Console.WriteLine("ones listed on the card).\n");
            Console.WriteLine("Q: When a Locust figure moves and then attacks, does it");
            Console.WriteLine("\"take cover\" before or after attacking?");
            Console.WriteLine("A: The Locust figure will take cover before attacking. It's");
            Console.WriteLine("range is measured from the cover space, and it will not");
            Console.WriteLine("attack if it no longer has line of sight.\n");
            Console.WriteLine("Q: If a Wretch rolls an omen during an attack and spawns");
            Console.WriteLine("another Wretch, does the new Wretch still activate during");
            Console.WriteLine("the current Locust activiation step?");
            Console.WriteLine("A: Yes.\n");
            Console.WriteLine("Q: What are the range of Locust weapons?");
            Console.WriteLine("A: All Locust enemies can attack COGs at any range");
            Console.WriteLine("without penalty, unless specified on their AI card. If a");
            Console.WriteLine("Locust does not thematically have a ranged weapon, it's AI");
            Console.WriteLine("cards will only allow it to attack enemies in it's area.\n");
            Console.WriteLine("Q: If a Locust attacks a COG that is already in it's area, does it");
            Console.WriteLine("move out of cover before attacking?");
            Console.WriteLine("A: No.\n");
            Console.WriteLine("Q: Can Wretch AI card #11 spawn other Locust figures if");
            Console.WriteLine("there are not enough Wretch figures available?");
            Console.WriteLine("A: Yes. As per normal spawning rules, a different figure is");
            Console.WriteLine("spawned for each Wretch that could not be spawned due");
            Console.WriteLine("to component limitations.\n");
            Console.WriteLine("BERSERKER\n");
            Console.WriteLine("Q: Can a player use an Order card to attack nothing so the");
            Console.WriteLine("Berserker will move toward him?");
            Console.WriteLine("A: No.\n");
            Console.WriteLine("Q: Can a COG Soldier attack an unwounded Berserker with");
            Console.WriteLine("weapons besides the Hammer of Dawn?");
            Console.WriteLine("A: Yes, however, this attack will not deal any wounds to the");
            Console.WriteLine("Berserker unless it has been previously wounded.\n");
            Console.WriteLine("Q: What happens when a COG uses a \"Guard\" reaction ability");
            Console.WriteLine("against a Berserker that is about to attack a COG in it's area?");
            Console.WriteLine("A: The Berserker does not move towards the attacker");
            Console.WriteLine("if it is currently being activated by an AI card. This is an");
            Console.WriteLine("exception to the rule - it still moves as normal for all");
            Console.WriteLine("other \"Guard\" and normal attacks.\n");
            Console.WriteLine("MISCELLANEOUS\n");
            Console.WriteLine("Q: If a Locust figure heals itself, what happens to it's");
            Console.WriteLine("wound marker?");
            Console.WriteLine("A: The marker is shuffled back into the pile of unused");
            Console.WriteLine("wound markers.\n");
            Console.WriteLine("Q: Are diagonal areas adjacent to each other?");
            Console.WriteLine("A: As long as two areas share a cracked border, they are");
            Console.WriteLine("considered adjacent. This includes a corner that they");
            Console.WriteLine("share. When measuring adjacent range, blue borders");
            Console.WriteLine("also follow this rule. Cover spaces often break up this");
            Console.WriteLine("adjacency, and if there is no connecting border then the");
            Console.WriteLine("figure may not move over the cover.\n");
            Console.WriteLine("For example, the diagonal areas on tile 4B cannot be");
            Console.WriteLine("moved between because they do not share a border");
            Console.WriteLine("(not even the corner of a border).\n");
            Console.WriteLine("Q: Who wins if the COGs accomplish the mission but all COGS");
            Console.WriteLine("bleed out? (e.g. if you drop a grenade in your area and blow");
            Console.WriteLine("everybody up, including yourself).");
            Console.WriteLine("A: If all COGS are bleeding out, they lose the game");
            Console.WriteLine("(regardless of if they are currently fulfilling the victory");
            Console.WriteLine("conditions).\n");
            Console.WriteLine("Q: Can a COG use the Roika Heavy MG to target multiple");
            Console.WriteLine("enemies per turn? Is there any damage when rolling an");
            Console.WriteLine("Omen symbol?");
            Console.WriteLine("A: This attack can only target a single Locust figure, and");
            Console.WriteLine("can only be used once per turn. Any omens rolled on the");
            Console.WriteLine("dice have no effect for this attack.\n");
            Console.WriteLine("Q: Can a \"Guard\" reaction be used when a Locust enters an");
            Console.WriteLine("area but before he enters cover?");
            Console.WriteLine("A: Yes.\n");
            Console.WriteLine("Q: If Dom uses \"Active Reload\" to play two Order cards in his");
            Console.WriteLine("turn, is he allowed to trigger his special ability twice?");
            Console.WriteLine("A: No.\n");
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
