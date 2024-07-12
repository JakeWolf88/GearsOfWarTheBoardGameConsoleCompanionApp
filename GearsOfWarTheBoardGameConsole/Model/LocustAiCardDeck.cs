class LocustAiCardDeck
{
    private int _missionNumber;
    private Dictionary<int, LocustAiCard> _locustAiCardDeck;
    private List<LocustAiCard> _missionlocustAiCardDeck;
    private List<string> _droneSounds = new() { "Drone\\locust-advancing.mp3", "Drone\\locust-attack.mp3", "Drone\\locust-die-ground-walker.mp3", "Drone\\locust-hostiles.mp3", 
                                                "Drone\\locust-moving.mp3", "Drone\\locust-sighted.mp3", "Drone\\locust_unknown.mp3", "Drone\\locust-dronegrenadier1.mp3", 
                                                "Drone\\locust-dronegrenadier2.mp3", "Drone\\locust-dronegrenadier3.mp3", "Drone\\locust-dronegrenadier4.mp3", "Drone\\locust-dronegrenadier5.mp3", 
                                                "Drone\\locust-dronegrenadier6.mp3", "Drone\\locust-dronegrenadier7.mp3", "Drone\\locust-dronegrenadier8.mp3", "Drone\\locust-dronegrenadier9.mp3", 
                                                "Drone\\locust-dronegrenadier10.mp3", "Drone\\locust-dronegrenadier11.mp3" };
    private List<string> _boomerSounds = new() { "Boomer\\locust-boom.mp3", "Boomer\\locust-crush.mp3", "Boomer\\locust-mine.mp3", "Boomer\\locust-obey-me.mp3", "Boomer\\locust-laugh-5.mp3", 
                                                 "Boomer\\locust-pathetic-meat.mp3", "Boomer\\locust-screw-you.mp3", "Boomer\\locust-laugh-4.mp3", "Boomer\\locust-growl.mp3", "Boomer\\locust-boomer1.mp3",
                                                 "Boomer\\locust-boomer2.mp3", "Boomer\\locust-boomer3.mp3", "Boomer\\locust-boomer4.mp3", "Boomer\\locust-boomer5.mp3", "Boomer\\locust-boomer6.mp3" };
    private List<string> _kantusSounds = new() { "Kantus\\kantus-die-sapien.mp3", "Kantus\\kantus-ground-meat.mp3", "Kantus\\kantus-kill-you.mp3" };
    private List<string> _BerserkerSounds = new() { "Berserker\\locust-berserker1.mp3", "Berserker\\locust-berserker2.mp3", "Berserker\\locust-berserker3.mp3", "Berserker\\locust-berserker4.mp3", 
                                                    "Berserker\\locust-berserker5.mp3", "Berserker\\locust-berserker6.mp3", "Berserker\\locust-berserker7.mp3", "Berserker\\locust-berserker8.mp3", 
                                                    "Berserker\\locust-berserker9.mp3", "Berserker\\locust-berserker10.mp3", "Berserker\\locust-berserker11.mp3" };
    private List<string> _theronGuardSounds = new() { "TheronGuard\\locust-theron-guard1.mp3", "TheronGuard\\locust-theron-guard2.mp3", "TheronGuard\\locust-theron-guard3.mp3", "TheronGuard\\locust-theron-guard4.mp3", "TheronGuard\\locust-theron-guard5.mp3", "TheronGuard\\locust-theron-guard6.mp3", "TheronGuard\\locust-theron-guard7.mp3", "TheronGuard\\locust-theron-guard8.mp3", "TheronGuard\\locust-theron-guard9.mp3", "TheronGuard\\locust-theron-guard10.mp3" };

    public LocustAiCardDeck(int missionNumber, int stageNumber)
    {
        _locustAiCardDeck = new();
        _missionlocustAiCardDeck = new();
        CreateLocustAiDeck();
        switch (missionNumber)
        {
            case 1:
                PopulateMissionOneCards();
                break;
            case 2:
                PopulateMissionTwoCards();
                break;
            case 3:
                PopulateMissionThreeCards();
                break;
            case 4:
                PopulateMissionFourCards(stageNumber);
                break;
            case 5:
                PopulateMissionFiveCards();
                break;
            case 6:
                PopulateMissionSixCards();
                break;
            case 7:
                PopulateMissionSevenCards(stageNumber);
                break;
            case 8:
                PopulateMissionEightCards(stageNumber);
                break;
            case 9:
                PopulateMissionNineCards();
                break;
            default:
                break;
        }
    }

    public List<LocustAiCard> MissionLocustAiCardDeck
    {
        get => _missionlocustAiCardDeck;
        set
        {
            if (value != _missionlocustAiCardDeck)
            {
                _missionlocustAiCardDeck = value;
            }
        }
    }

    private void CreateLocustAiDeck()
    {
        //General
        _locustAiCardDeck.Add(1, new LocustAiCard("EVENT -GENERAL\n", "DISTRACTION:\n Discard 1 ammo token from\n one of your weapon cards.\n\n Then remove all dropped\n weapon markers from the map.\n\n Then draw a new AI card.", "", true));
        _locustAiCardDeck.Add(2, new LocustAiCard("EVENT -GENERAL\n", "THE HORDE:\n Each Locust that is 4 or\n more movement away from the nearest COG figure\n moves 3 areas toward him\n\n Then draw a new AI card", "", true));
        _locustAiCardDeck.Add(3, new LocustAiCard("GROUP -GENERAL \n", "IF 1 OR MOVE LOCUST IS\n WITHIN 2 MOVEMENT OF YOU\n Each Locust moves 2 areas\n toward you. If then in your\n areas, it attack you.\n\n", "OTHERWISE:\n Spawn 1 Locust B at the\n map exit. Each Locust then\n moves 1 area toward you", true));
        _locustAiCardDeck.Add(4, new LocustAiCard("EVENT -GENERAL\n", "REINFORCEMENTS:\n Spawn 1 Locust A, 1 Locust\n B, and 1 Locust C at the\n map exit.\n\n Then each Locust A moves\n 2 areas toward the nearest\n COG figure and each Locust\n B moves 1 area toward the nearest COG figure.", "", false));
        _locustAiCardDeck.Add(5, new LocustAiCard("EVENT -GENERAL\n", "FIREFIGHT:\n Each Drone, Boomer, Kantus,\n and Theron Guard attacks a\n COG figure within 3 range.\n\n Then, each Locust that did\n not attack moves 2 areas\n toward the nearest COG\n figure and then attacks a COG figure in it's area.\n\n If no Locusts in play,\n draw a new AI card.", "", true));
        _locustAiCardDeck.Add(6, new LocustAiCard("EVENT -GENERAL\n", "SWARM:\n Each Locust that is 5\n or more movements away\n from the nearest COG\n figure moves until it is\n 4 movement away from the\n nearest COG figure.\n\n Then draw a new AI card.", "", true));
        _locustAiCardDeck.Add(7, new LocustAiCard("GROUP -GENERAL\n", "IF NO EMERGENCE HOLE\n IN YOUR AREAS:\n Place an emergence hole\n token in your area.\n Then spawn 1 Locust A\n in your area.", "OTHERWISE:\n Spawn 1 Locust B in your\n area. The Locust then\n attacks you.", true));

        //The Wretches
        _locustAiCardDeck.Add(8, new LocustAiCard("FOR EACH -WRETCH\n", "IF A COG FIGURE IS WITHIN 2 MOVEMENT:\n Move into his area\n and then attack him.\n\n", "OTHERWISE:\n Move 4 areas toward\n the nearest COG figure.\n\n If no Wretches in play,\n draw a new AI card.", true));
        _locustAiCardDeck.Add(9, new LocustAiCard("FOR EACH -WRETCH\n", "IF A COG FIGURE WITH 4 OR LESS\n HEALTH IS WITHIN 3 MOVEMENT:\n Move into his area\n and then attack him.\n\n", "OTHERWISE:\n Move 2 areas toward the\n nearest COG figure not\n in cover.\n\n If no Wretches in play or\n all COG figures in cover,\n draw a new AI card.", true));
        _locustAiCardDeck.Add(10, new LocustAiCard("FOR EACH -WRETCH\n", "IF UNWOUNDED:\n Move 3 areas toward the\n nearest COG figure. Then\n attack a COG figure in the\n area that is not in cover\n (if able).\n\n", "OTHERWISE:\n Move into the nearest\n cover space and heal.\n\n If no Wretches in play or\n all COG figures in cover,\n draw a new AI card.", true));
        _locustAiCardDeck.Add(11, new LocustAiCard("FOR EACH -WRETCH\n", "IF A COG FIGURE IS WITHIN 4 OR LESS\n HEALTH IS WITHIN 3 MOVEMENT:\n Move into his area\n and then attack him.\n\n", "OTHERWISE:\n Move 2 areas toward the\n nearest COG figure not\n in cover.\n\n If no Wretches in play or\n all COG figures in cover,\n draw a new AI card.", true));

        //The Drones
        _locustAiCardDeck.Add(12, new LocustAiCard("GROUP -DRONES\n", "IF ONE OR MORE DRONE IN PLAY:\n Move each Drone 2 areas\n toward nearest COG figure.\n Each Drone then attacks a\n COG figure within 2 range.\n\n", "OTHERWISE:\n Spawn 2 Drones at the\n emergence hole nearest you.", true, _droneSounds));
        _locustAiCardDeck.Add(13, new LocustAiCard("FOR EACH -DRONE\n", "IF A COG FIGURE IS WITHIN LINE-OF-SIGHT:\n Attack he nearest COG\n. Figure within LOS. Then, if\n this Drone is not in cover,\n move it 1 areas away from\n the nearest cog figure.\n\n", "OTHERWISE:\n Move 3 areas toward nearest\n COG figure.\n\n If no Drones in play,\n draw a new AI card.", true, _droneSounds));
        _locustAiCardDeck.Add(14, new LocustAiCard("FOR EACH -DRONE\n", "IF A COG FIGURE IS WITHIN 1 RANGE:\n Attack the COG figure with +1 attack die.\n\n", "OTHERWISE:\n Move 1 area toward the\n nearest COG figure.\n Then attack the nearest\n COG figure within LOS.\n\n If no drones in play,\n draw a new AI card.", true, _droneSounds));
        _locustAiCardDeck.Add(15, new LocustAiCard("FOR EACH -DRONE\n", "IF A COG FIGURE IS WITHIN 2 RANGE:\n If unwounded, attack the \n nearest COG figure within\n LOS. Otherwise heal.\n\n", "OTHERWISE:\n Move 2 area toward the\n nearest COG figure.\n\n If no drones in play,\n draw a new AI card.", true, _droneSounds));

        //The Boomers
        _locustAiCardDeck.Add(16, new LocustAiCard("FOR EACH -BOOMER\n", "IF A COG FIGURE IS WITHIN 4 RANGE:\n Attack the nearest COG\n figure witin LOS.\n\n", "OTHERWISE:\n Move 2 areas toward\n the nearest COG figrue.\n\n If no Boomers in play,\n draw a new AI card.", true, _boomerSounds));
        _locustAiCardDeck.Add(17, new LocustAiCard("FOR EACH -BOOMER\n", "IF A COG FIGURE IS WITHIN 3 RANGE: \n Attack the nearest COG\n figure within LOS.\n\n", "OTHERWISE:\n Move 2 areas toward the\n nearest COG figure. Then\n attack the COG figure if\n within 3 range.\n\n If no Boomers in play,\n draw a new AI card.", true, _boomerSounds));
        _locustAiCardDeck.Add(18, new LocustAiCard("FOR EACH -BOOMER\n", "IF WITHIN 1 AREA OF A COG FIGURE:\n Move 1 area away from the\n nearest COG figure. Then\n attack him (if in LOS).\n\n", "OTHERWISE:\n Move 1 area toward the\n nearest COG figure. Then\n attack im (if in LOS).\n\n if no Boomers in play,\n draw a new AI card.", true, _boomerSounds));
        _locustAiCardDeck.Add(19, new LocustAiCard("GROUP -BOOMERS\n", "IF 1 OR MORE BOOMER IN PLAY:\n Each Boomer moves 1\n area toward nearest COG\n figure and then attacks\n it (if in LOS).\n\n", "OTHERWISE:\n Spawn 1 Boomer at the\n emergence hole nearest you.", true, _boomerSounds));

        //The Berserkers
        _locustAiCardDeck.Add(20, new LocustAiCard("FOR EACH -BERSERKER\n", "IF A COG FIGURE MOVED OR\n ATTACKED THIS TURN:\n Move 1 area toward the\n COG figure. The Berserker\n then attacks each figure\n in it's own area.\n\n", "OTHERWISE:\n Move 1 area toward the\n nearest COG figure.", true, _BerserkerSounds));
        _locustAiCardDeck.Add(21, new LocustAiCard("FOR EACH -BERSERKER\n", "IF ALL COG FIGURES ARE IN COVER:\n Draw a new AI card\n and resolve it.\n\n", "OTHERWISE:\n Move the Berserker 1 area\n toward the nearest COG\n figure not in cover. The\n Bersker then attacks\n each figure in it's own area.", true, _BerserkerSounds));
        _locustAiCardDeck.Add(22, new LocustAiCard("FOR EACH -BERSERKER\n", "IF ALL COG FIGURES ARE 3 OR\n MORE MOVEMENT AWAY:\n Move 2 areas toward\n the nearest COG figure.\n\n", "OTHERWISE:\n Move 1 area toward the\n nearest COG figure. The\n Berserker then attacks\n each figure in it's own area.", true, _BerserkerSounds));
        _locustAiCardDeck.Add(23, new LocustAiCard("FOR EACH -BERSERKER\n", "IF A COG FIGURE IS IN IT'S AREA:\n The Berserk attacks each\n figure in his area.\n\n", "OTHERWISE:\n Move 2 areas toward the\n nearest COG figure. Deal\n 1 wound to each figure in\n an area that the Berserker\n moved into.", true, _BerserkerSounds));

        //The Theron Guards.
        _locustAiCardDeck.Add(24, new LocustAiCard("FOR EACH -THERON GUARD\n", "IF A COG FIGURE IS WITHIN LINE-OF-SIGHT:\n Attack the nearest COG\n figure within LOS\n\n", "OTHERWISE:\n Move 2 areas toward\n the nearest cogh figure\n\n If no Theron Guards in\n play, draw a new AI card.", true, _theronGuardSounds));
        _locustAiCardDeck.Add(25, new LocustAiCard("FOR EACH -THERON GUARD\n", "IF A COG FIGURE IS WITHIN 4 RANGE:\n Attack the nearest COG\n figure within LOS\n\n", "OTHERWISE:\n Move 3 areas toward\n the nearest COG figure.\n\n If no Theron Guards in\n play, draw a new AI card.", true, _theronGuardSounds));
        _locustAiCardDeck.Add(26, new LocustAiCard("FOR EACH -THERON GUARD\n", "IF A COG FIGURE IS WITHIN 1 MOVEMENT:\n Move 1 areas away from him and\n then attack him (if in LOS).\n\n", "OTHERWISE:\n Attack the nearest COG\n figure in LOS. If cannot\n attack, move 2 areas toward\n the nearest COG figure.\n\n If no Theron Guards in\n play, draw a new AI card.", true, _theronGuardSounds));
        _locustAiCardDeck.Add(27, new LocustAiCard("GROUP -THERON GUARD\n", "IF 1 OR MOVE THERON GUARDS HAS\n LINE-OF-SIGHT TO A COG FIGURE:\n Each Theron Guard attacks\n the nearest COG figure. Each\n Theron Guard that did not\n attack moves 2 areas toward\n you.\n\n", "OTHERWISE:\n Spawn 1 Theron Guard at the\n emergence hole nearest you.", true, _theronGuardSounds));

        //The Tickers
        _locustAiCardDeck.Add(28, new LocustAiCard("FOR EACH -TICKER\n", "IF A COG FIGURE IS WITHIN 1 MOVEMENT:\n Move into his areas and then\n attack him. Resolve the\n Ticker's triggered ability\n regardless of the roll.\n\n", "OTHERWISE:\n Move 3 areas toward the\n nearest COG figure.\n\n If no Tickers in play,\n draw a new AI card.", true));
        _locustAiCardDeck.Add(29, new LocustAiCard("FOR EACH -TICKER\n", "IF A COG FIGURE IS WITHIN 2 MOVEMENT:\n Move into his area and\n then attack him.\n\n", "OTHERWISE:\n Move 3 areas toward the\n nearest COG figure. If the\n Ticker is then in LOS of a\n COG figure and not in cover, move it 1 area away from him.\n If no Tickers in play,\n draw a new AI card.", true));
        _locustAiCardDeck.Add(30, new LocustAiCard("FOR EACH -TICKER\n", "IF A COG FIGURE IS WITHIN 3 MOVEMENT:\n Move into his area.\n Then attack a COG figure\n in the area that is not\n in cover (if able).\n\n", "OTHERWISE:\n Move 1 area toward the\n nearest COG figure.\n\n If no Tickers in play,\n draw a new AI card.", true));
        _locustAiCardDeck.Add(31, new LocustAiCard("GROUP -TICKER\n", "IF 1 OR MORE TICKER IN PLAY:\n Each TIcker moves 2 areas\n toward the closest COG\n figure and then attacks\n a COG figure in it's area.\n COG figures may not guard this turn.\n\n", "OTHERWISE:\n Spawn 1 Ticker at each\n emergence hole within 5\n movement of you.", true));

        //The Kantus
        _locustAiCardDeck.Add(32, new LocustAiCard("FOR EACH -KANTUS\n", "IF ANOTHER WOUNDED LOCUST\n IS WITHIN 2 MOVEMENT:\n Move into the Locust's area\n and then heal it.\n\n", "OTHERWISE:\n Move 2 areas toward the\n nearest COG figure and\n then attack the nearest\n COG figure in LOS.\n If no Kantus in play,\n draw a new AI card.", true, _kantusSounds));
        _locustAiCardDeck.Add(33, new LocustAiCard("FOR EACH -KANTUS\n", "IF A DROPPED WEAPON\n MARKER IS WITHIN 2 MOVEMENT:\n Flip the token weapon side down and spawn the\n matching figure on it.\n\n", "OTHERWISE:\n Attack a COG figure within 3 range.\n\n If no Kantus in play,\n draw a new AI card.", true, _kantusSounds));
        _locustAiCardDeck.Add(34, new LocustAiCard("FOR EACH -KANTUS\n", "IF A COG FIGURE IS WITHIN 4 RANGE:\n Attack him and then move\n 2 areas toward him.\n\n", "OTHERWISE:\n Move 2 areas towar the\n nearest COG figure. Then spawn\n 1 Locust A at the emergence\n hole nearest to the Kantus.\n\n If no Kantus in play,\n draw a new AI card.", true, _kantusSounds));
        _locustAiCardDeck.Add(35, new LocustAiCard("GROUP -KANTUS\n", "IF 1 OR MORE KANTUS IN PLAY:\n Each Kantus moves 2 areas\n toward the nearest COG\n figure and then attacks\n him (if in LOS).\n\n", "OTHERWISE:\n Spawn 1 Kantus at the\n emergence hole nearest you.", true, _kantusSounds));

        //Mission Pack 1
        //The Grenadiers
        _locustAiCardDeck.Add(101, new LocustAiCard("GROUP -GRENADIERS\n", "IF 1 OR MORE GRENADIER IN PLAY:\n Move each Grenadier 2 areas toward\n the nearest COG figure.\n Each Grenadier then attacks a COG\n figure within 1 range.\n\n", "OTHERWISE:\n Spawn 1 Grenadier at the emergence\n hole nearest you.\n That Grenadier then moves 1 area\n toward the nearest COG figure.", true, _droneSounds));
        _locustAiCardDeck.Add(102, new LocustAiCard("FOR EACH -GRENADIER\n", "IF A COG FIGURE IS WITHIN LINE-OF-SIGHT:\n Move 2 areas toward the nearest COG\n figurte within LOS\n Then, attack a COG figure witih 1 range.\n\n", "OTHERWISE:\n Move 3 areas toward the nearest COG\n figure.\n\n If no Grenadiers in play, draw a\n new AI card.", true, _droneSounds));
        _locustAiCardDeck.Add(103, new LocustAiCard("FOR EACH -GRENADIER\n", "IF A COG FIGURE IS WITHIN 1 RANGE:\n Attack the COG figure with\n +1 attack dice.\n\n", "OTHERWISE:\n Move 2 areas toward the nearest COG\n figure. Then attack a COG figure within\n 1 range.\n\n If no Grenadiers in play,\n draw a new AI card.", true, _droneSounds));
        _locustAiCardDeck.Add(104, new LocustAiCard("FOR EACH -GRENADIER\n", "IF A COG FIGURE IS WITHIN 2 RANGE:\n Move 2 areas toward him.\n Then attack a COG figure\n within 1 range.\n\n", "OTHERWISE:\n Spawn 1 Grenadier at the emergence\n hole nearest you.\n That Grenadier then moves 1 area\n toward the nearest COG figure.", true, _droneSounds));

        //The Palace Guards
        _locustAiCardDeck.Add(105, new LocustAiCard("GROUP -PALACE GUARDS\n", "IF 1 OR MORE PALACE GUARD HAS\n LINE-OF-SIGHT TO A COG FIGURE:\n Each Palace Guard attacks the nearest\n COG figure withi LOS. Each Palace\n Guard that did not attack moves 3 areas\n toward you.\n\n", "OTHERWISE:\n Spawn 1 Palace Guard at the emer-\ngence hole nearest you.", true, _theronGuardSounds));
        _locustAiCardDeck.Add(106, new LocustAiCard("FOR EACH -PALACE GUARD\n", "IF A COG FIGURE IS WITHIN 1 MOVEMENT:\n Move 1 area away from him and\n then attack the nearest COG figure\n within LOS.\n\n", "OTHERWISE:\n Attack the nearest COG figure in LOS. If\n no COG figure is in LOS, move 2 areas\n toward you.\n\n If no Palace guards in play,\n draw a new AI card.", true, _theronGuardSounds));
        _locustAiCardDeck.Add(107, new LocustAiCard("FOR EACH -PALACE GUARD\n", "IF A COG FIGURE IS WITHIN 4 RANGE:\n Attack the nearest COG figure within\n LOS. If there are no COG figures within\n LOS, move 2 areas toward the nearest\n COG figure.\n\n", "OTHERWISE:\n Move 3 areas toward the nearest COG\n figure.\n\n If no Palace guards in play,\n draw a new AI card.", true, _theronGuardSounds));
        _locustAiCardDeck.Add(108, new LocustAiCard("FOR EACH -PALACE GUARD\n", "IF A COG FIGURE IS WITHIN LINE-OF-SIGHT:\n Attack the nearest COG figure within\n LOS. if the target is more than 3 areas\n away, -1 attack dice.\n\n", "OTHERWISE:\n Move 2 areas toward the nearest COG\n figure.\n\n If no Palace Guards in play,\n draw a new AI card.", true, _theronGuardSounds));

        //The Butchers
        _locustAiCardDeck.Add(109, new LocustAiCard("FOR EACH -BUTCHER\n", "IF A COG MOVED OR ATTACKED THIS TURN:\n Move 1 area toward the COG. The\n Locust then attacks each COG in it's\n own area.\n\n", "OTHERWISE:\n Move 1 area toward the nearest COG.\n\n If no Locust C in play,\n draw a new AI card.", true));
        _locustAiCardDeck.Add(110, new LocustAiCard("FOR EACH -BUTCHER\n", "IF ALL COG'S ARE IN COVER:\n Move each Locust C 2 areas toward the\n COG. Then, draw a new AI card and\n resolve it.\n\n", "OTHERWISE:\n Move each Locust C 2 areas toward the\n nearest COG.\n\n If no Locust C in play,\n draw a new AI card.", true));
        _locustAiCardDeck.Add(111, new LocustAiCard("FOR EACH -BUTCHER\n", "IF ALL COG'S ARE 3 OR MORE\n MOVEMENT AWAY:\n Move 2 areas toward the nearest COG.\n\n", "OTHERWISE:\n Move 1 area toward the nearest COG.\n The Locust then attacks each COG in\n it's own area.\n\n If no Locust C in play,\n draw a new ai card.", true));
        _locustAiCardDeck.Add(112, new LocustAiCard("FOR EACH -BUTCHER\n", "IF A COG IS IN IT'S AREA:\n Attack each COG in the Locusts area.\n\n", "OTHERWISE:\n Move 2 areas toward the nearest COG.\n Then, each COG in Locust C's area is\n moved out of cover.\n\n If no Locust C in play,\n draw a new AI card", true));

        //General Raam
        _locustAiCardDeck.Add(113, new LocustAiCard("GENERAL RAAM\n", "IF 1 OR MOVE COGS ARE WITHIN 2 RANGE:\n Attack the nearest COG within LOS.\n Then, attack a different COG in that\n area (if able).\n\n", "OTHERWISE:\n Move 2 areas toward the nearest COG.\n Then, flip General RAAM's Enemy card\n to side A.", true));
        _locustAiCardDeck.Add(114, new LocustAiCard("GENERAL RAAM\n", "IF A COG IS IN HIS AREA:\n Flip General RAAM's Enemy card to\n side A. Then move 1 area away from\n the nearest COG and attack him (if\n within LOS).\n\n", "OTHERWISE:\n Move 1 area toward the nearest COG\n and attack him (if within LOS).", true));
        _locustAiCardDeck.Add(115, new LocustAiCard("GENERAL RAAM\n", "IF 1 OR MROE COGS ARE WITHIN 2 RANGE:\n Attack each COG within 2 range that is\n not in cover.\n\n", "OTHERWISE:\n Move 3 areas toward the nearest COG\n and attack a COG in General RAAM's\n area with +1 attack dice.", true));
        _locustAiCardDeck.Add(116, new LocustAiCard("GENERAL RAAM\n", "IF A COG IS WITHIN LINE-OF-SIGHT:\n Attack each COG within LOS that is not\n in cover.\n\n", "OTHERWISE:\n Move 2 areas toward the nearest COG.\n Then attack a COG within LOS.", true));

        //General
        _locustAiCardDeck.Add(117, new LocustAiCard("EVENT -GENERAL\n", "UNSTOPPABLE CHARGE:\n Each Locust moves 1 area toward then\n nearest COG,\n then each player spawns 1 Locust A at\n the emergence hole nearest him.\n\n Guards reactions may not be used while\n resolving this card.\n\n Then draw a new AI card", "", true));
        _locustAiCardDeck.Add(118, new LocustAiCard("EVENT -GENERAL\n", "UNSTOPPABLE CHARGE:\n Each Locust moves 1 area toward then\n nearest COG,\n then each player spawns 1 Locust A at\n the emergence hole nearest him.\n\n Guards reactions may not be used while\n resolving this card.\n\n Then draw a new AI card", "", true));
        _locustAiCardDeck.Add(119, new LocustAiCard("EVENT -GENERAL\n", "IF 1 OR MORE AMMO TOKEN IS ON THE MAP:\n Each player discards 1 ammo token\n from the map.\n\n Each player that could not discard an\n ammo token spawns 1 Locust A at the\n emergence hole nearest him.\n\n", "OTHERWISE:\n Spawn 1 Butcher at the map entrance.\n Each Locust then moves 1 area towards\n you.", true)); //Double check grammar
    }

    private void PopulateMissionOneCards()
    {
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[1]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[2]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[3]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[4]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[5]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[6]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[8]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[9]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[10]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[11]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[12]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[13]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[14]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[15]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[16]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[17]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[18]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[19]);
    }

    private void PopulateMissionTwoCards()
    {
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[1]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[2]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[5]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[6]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[8]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[9]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[10]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[11]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[12]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[13]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[14]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[15]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[20]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[21]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[22]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[23]);
    }

    private void PopulateMissionThreeCards()
    {
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[1]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[2]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[3]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[6]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[7]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[9]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[10]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[11]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[12]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[13]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[14]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[15]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[24]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[25]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[26]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[27]);
    }

    private void PopulateMissionFourCards(int stageNumber)
    {
        if (stageNumber == 1)
        {
            _missionlocustAiCardDeck.Add(_locustAiCardDeck[1]);
            _missionlocustAiCardDeck.Add(_locustAiCardDeck[2]);
            _missionlocustAiCardDeck.Add(_locustAiCardDeck[3]);
            _missionlocustAiCardDeck.Add(_locustAiCardDeck[4]);
            _missionlocustAiCardDeck.Add(_locustAiCardDeck[5]);
            _missionlocustAiCardDeck.Add(_locustAiCardDeck[7]);
            _missionlocustAiCardDeck.Add(_locustAiCardDeck[28]);
            _missionlocustAiCardDeck.Add(_locustAiCardDeck[29]);
            _missionlocustAiCardDeck.Add(_locustAiCardDeck[30]);
            _missionlocustAiCardDeck.Add(_locustAiCardDeck[31]);
        }
        else
        {
            _missionlocustAiCardDeck.Add(_locustAiCardDeck[1]);
            _missionlocustAiCardDeck.Add(_locustAiCardDeck[2]);
            _missionlocustAiCardDeck.Add(_locustAiCardDeck[3]);
            _missionlocustAiCardDeck.Add(_locustAiCardDeck[4]);
            _missionlocustAiCardDeck.Add(_locustAiCardDeck[5]);
            _missionlocustAiCardDeck.Add(_locustAiCardDeck[7]);
            _missionlocustAiCardDeck.Add(_locustAiCardDeck[12]);
            _missionlocustAiCardDeck.Add(_locustAiCardDeck[13]);
            _missionlocustAiCardDeck.Add(_locustAiCardDeck[14]);
            _missionlocustAiCardDeck.Add(_locustAiCardDeck[15]);
            _missionlocustAiCardDeck.Add(_locustAiCardDeck[16]);
            _missionlocustAiCardDeck.Add(_locustAiCardDeck[17]);
            _missionlocustAiCardDeck.Add(_locustAiCardDeck[18]);
            _missionlocustAiCardDeck.Add(_locustAiCardDeck[19]);
            _missionlocustAiCardDeck.Add(_locustAiCardDeck[28]);
            _missionlocustAiCardDeck.Add(_locustAiCardDeck[29]);
            _missionlocustAiCardDeck.Add(_locustAiCardDeck[30]);
            _missionlocustAiCardDeck.Add(_locustAiCardDeck[31]);
        }
    }

    private void PopulateMissionFiveCards()
    {
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[1]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[3]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[4]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[5]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[6]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[7]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[12]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[13]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[14]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[15]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[16]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[17]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[18]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[19]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[28]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[29]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[30]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[31]);
    }

    private void PopulateMissionSixCards()
    {
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[2]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[4]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[5]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[6]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[12]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[13]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[14]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[15]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[24]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[25]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[26]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[27]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[32]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[33]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[34]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[35]);
    }

    private void PopulateMissionSevenCards(int stageNumber)
    {
        switch (stageNumber)
        {
            case 1:
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[1]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[2]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[5]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[6]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[8]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[9]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[10]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[11]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[12]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[13]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[14]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[15]);
                break;
            case 3:
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[1]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[2]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[5]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[6]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[8]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[9]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[10]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[11]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[16]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[17]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[18]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[19]);
                break;
            case 4:
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[1]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[2]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[5]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[6]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[28]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[29]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[30]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[31]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[32]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[33]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[34]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[35]);
                break;
            case 5:
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[1]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[2]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[5]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[6]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[24]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[25]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[26]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[27]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[28]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[29]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[30]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[31]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[32]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[33]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[34]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[35]);
                break;
            default:
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[1]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[2]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[5]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[6]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[12]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[13]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[14]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[15]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[16]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[17]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[18]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[19]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[20]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[21]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[22]);
                _missionlocustAiCardDeck.Add(_locustAiCardDeck[23]);
                break;
        }
    }

    private void PopulateMissionEightCards(int stageNumber)
    {
        if (stageNumber == 1)
        {
            _missionlocustAiCardDeck.Add(_locustAiCardDeck[117]);
            _missionlocustAiCardDeck.Add(_locustAiCardDeck[118]);
            _missionlocustAiCardDeck.Add(_locustAiCardDeck[101]);
            _missionlocustAiCardDeck.Add(_locustAiCardDeck[102]);
            _missionlocustAiCardDeck.Add(_locustAiCardDeck[103]);
            _missionlocustAiCardDeck.Add(_locustAiCardDeck[104]);
            _missionlocustAiCardDeck.Add(_locustAiCardDeck[105]);
            _missionlocustAiCardDeck.Add(_locustAiCardDeck[106]);
            _missionlocustAiCardDeck.Add(_locustAiCardDeck[107]);
            _missionlocustAiCardDeck.Add(_locustAiCardDeck[108]);
            _missionlocustAiCardDeck.Add(_locustAiCardDeck[20]);
            _missionlocustAiCardDeck.Add(_locustAiCardDeck[21]);
            _missionlocustAiCardDeck.Add(_locustAiCardDeck[22]);
            _missionlocustAiCardDeck.Add(_locustAiCardDeck[23]);
        }
        else
        {
            _missionlocustAiCardDeck.Add(_locustAiCardDeck[117]);
            _missionlocustAiCardDeck.Add(_locustAiCardDeck[118]);
            _missionlocustAiCardDeck.Add(_locustAiCardDeck[101]);
            _missionlocustAiCardDeck.Add(_locustAiCardDeck[102]);
            _missionlocustAiCardDeck.Add(_locustAiCardDeck[103]);
            _missionlocustAiCardDeck.Add(_locustAiCardDeck[104]);
            _missionlocustAiCardDeck.Add(_locustAiCardDeck[105]);
            _missionlocustAiCardDeck.Add(_locustAiCardDeck[106]);
            _missionlocustAiCardDeck.Add(_locustAiCardDeck[107]);
            _missionlocustAiCardDeck.Add(_locustAiCardDeck[108]);
            _missionlocustAiCardDeck.Add(_locustAiCardDeck[117]);
            _missionlocustAiCardDeck.Add(_locustAiCardDeck[118]);
            _missionlocustAiCardDeck.Add(_locustAiCardDeck[113]);
            _missionlocustAiCardDeck.Add(_locustAiCardDeck[114]);
            _missionlocustAiCardDeck.Add(_locustAiCardDeck[115]);
            _missionlocustAiCardDeck.Add(_locustAiCardDeck[116]);
        }
    }
    private void PopulateMissionNineCards()
    {
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[117]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[118]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[119]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[101]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[102]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[103]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[104]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[105]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[106]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[107]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[108]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[109]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[110]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[111]);
        _missionlocustAiCardDeck.Add(_locustAiCardDeck[112]);
    }
}