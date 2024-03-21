using System.Runtime.CompilerServices;

public class LocationCardDeck
{
    private Dictionary<string, LocationCard> _locationCardDeck = new(); 
    private List<List<LocationCard>> _missionLocationcardDeck = new();
    
    public LocationCardDeck(int MissionNumber)
    {
        CreateLocationDeck();
        switch (MissionNumber)
        {
            case 1: 
            PopulateMissionOneCards();
            break;
            case 2:
            PopulateMissionTwoCards();
            break;
            case 7:
            PopulateMissionSevenCards();
            break;
            case 8:
            PopulateMissionEightCards();
            break;
            default:
            break;
        }
    }

    public List<List<LocationCard>> MissionLocationCardDeck 
    {
        get => _missionLocationcardDeck;
        set
        {
            if (value != _missionLocationcardDeck)
            {
                _missionLocationcardDeck = value;
            }
        }
    }

    private void CreateLocationDeck()
    {
        //A section
        _locationCardDeck.Add("1A", new LocationCard("1A", "AMMUNITION", "Discard this card and gain\n up to 3 ammo tokens.\n Place these tokens on any\n of your Weapon cards.", new List<string>{"B","C","AC","ABC"}));
        _locationCardDeck.Add("2A", new LocationCard("2A", "WEAPON", "Discard this card and draw\n 2 Random Weapon cards.\n Keep 1 (with 2 ammo)\n and discard the other.", new List<string>{"B","C","AC","ABC"}));
        _locationCardDeck.Add("3A", new LocationCard("3A", "", "", new List<string>{"A","B","AB","AAB"}));
        _locationCardDeck.Add("4A", new LocationCard("4A", "WEAPON", "Discard this card and draw\n 2 Random Weapon cards.\n Keep 1 (with 2 ammo)\n and discard the other.", new List<string>{"C","AC","BC","ABC"}));
        _locationCardDeck.Add("5A", new LocationCard("5A", "", "", new List<string>{"A","B","AB","AAB"}));
        _locationCardDeck.Add("6A", new LocationCard("6A", "", "", new List<string>{"A","B","AA","AAC"}));
        _locationCardDeck.Add("7A", new LocationCard("7A", "AMMUNITION", "Discard this ard and gain\n up to 3 ammo tokens.\n Place these tokens on any\n of your Wapon cards.", new List<string>{"C","AC","BC","ABC"}));
        _locationCardDeck.Add("8A", new LocationCard("8A", "", "", new List<string>{"A", "B", "AB", "AAB"}));
        _locationCardDeck.Add("9A", new LocationCard("9A", "", "", new List<string>{"A", "B", "AB", "AAB"}));
        _locationCardDeck.Add("10A", new LocationCard("10A", "GRENADES", "Discard this card and\n gain 1 grenade token.", new List<string>{"B", "C", "AC", "ABC"}));
        _locationCardDeck.Add("11A", new LocationCard("11A", "", "", new List<string>{"A", "B", "AB", "AAA"}));
        _locationCardDeck.Add("12A", new LocationCard("12A", "GRENADES", "Discard this card and\n gain 1 grenade token", new List<string>{"B", "C", "AC", "CC"}));
        _locationCardDeck.Add("13A", new LocationCard("13A", "GRENADES", "Discard this card and\n gain 1 grenade token", new List<string>{"B", "C", "AC", "CC"}));
        _locationCardDeck.Add("14A", new LocationCard("14A", "JUNKER", "Move to any area of the map.", new List<string>{"A", "B", "AB", "AAB"}));
        _locationCardDeck.Add("15A", new LocationCard("15A", "", "", new List<string>{"AA","AB","BC","ABC"}));
        _locationCardDeck.Add("16A", new LocationCard("16A", "AMMUNITION", "Discard this card and gain\n up to 3 ammo tokens.\n Place these tokens on any\n of your weapon cards.", new List<string>{"A","B","AA","ABB"}));
        _locationCardDeck.Add("17A", new LocationCard("17A", "HAMMER OF DAWN", "Discard this card and receive\n the Hammer of Dawn Special\n Weapon card (with 0 ammo).", new List<string>{"B","AA","AB","AAB"}));
        //B section
        _locationCardDeck.Add("1B", new LocationCard("1B", "", "", new List<string>{"A","B","AB","AAB"}));
        _locationCardDeck.Add("2B", new LocationCard("2B", "", "", new List<string>{"A","B","AA","AAB"}));
        _locationCardDeck.Add("3B", new LocationCard("3B", "WEAPON", "Discard this card and draw\n 2 Random Weapon cards.\n Keep 1 (with 2 ammo)\n and discard the other", new List<string>{"C","AC","BC","ABC"}));
        _locationCardDeck.Add("4B", new LocationCard("4B", "", "", new List<string>{"A","B","AB","AAB"}));
        _locationCardDeck.Add("5B", new LocationCard("5B", "", "", new List<string>{"A","B","AB","AAB"}));
        _locationCardDeck.Add("6B", new LocationCard("6B", "AMMUNITION", "Discard this card and gain\n up to 3 ammo tokens.\n Place these tokens on any\n of your Weapon cards.", new List<string>{"B","AA","AB","ABC"}));
        _locationCardDeck.Add("7B", new LocationCard("7B", "GRENADES", "Discard this card and\n gain 1 grenade tokoen", new List<string>{"B","AA","AB","ABC"}));
        _locationCardDeck.Add("8B", new LocationCard("8B", "AMMUNITION", "Discard this card and gain\n up to 3 ammo tokens.\n Place these tokens on any\n of your Weapon cards.", new List<string>{"A","B","AB","AAB"}));
        _locationCardDeck.Add("9B", new LocationCard("9B", "", "", new List<string>{"A","B","AB","AAB"}));
        _locationCardDeck.Add("10B", new LocationCard("10B", "", "", new List<string>{"B","C","AC","ABC"}));
        _locationCardDeck.Add("11B", new LocationCard("11B", "AMMUNITION", "Discard this card and gain\n up to 3 ammo tokens.\n Place these tokens on any\n of your Weapon cards.", new List<string>{"B","AA","AB","AAB"}));
        _locationCardDeck.Add("12B", new LocationCard("12B", "KEYCODE", "Discard this card and unlock\n the next level's Location deck.", new List<string>{"B","C","AC","ABC"}));
        _locationCardDeck.Add("13B", new LocationCard("13B", "GRENADES", "Discard this card and\n gain 1 grenade token.", new List<string>{"B","C","AC","ABC"}));
        _locationCardDeck.Add("14B", new LocationCard("14B", "", "", new List<string>{"A","B","AB","ABC"}));
        _locationCardDeck.Add("15B", new LocationCard("15B", "AMMUNITION", "Discard this card and gain\n up to 3 ammo tokens.\n Place these tokens on any\n of your Weapon cards.", new List<string>{"AA","AB","BC","ABC"}));
        _locationCardDeck.Add("16B", new LocationCard("16B", "TONKA HEAVY MS", "If you started your turn here,\n make a 6 dice attack against any\n Locust on this map tile. You do\n not play an Order card this turn.", new List<string>{"A","B","AA","AAB"}));
        _locationCardDeck.Add("17B", new LocationCard("17B", "WEAPON", "Discard this card and draw\n 2 Random Weapon cards.\n Keep 1 (with 2 ammo)\n and discard the other.", new List<string>{"B","AA","AB","AAB"}));

    }

    private void PopulateMissionOneCards()
    {
        List<LocationCard> temp = new();
        temp.Add(_locationCardDeck["2A"]);
        temp.Add(_locationCardDeck["9A"]);
        temp.Add(_locationCardDeck["12A"]);
        temp.Add(_locationCardDeck["16A"]);

        List<List<LocationCard>> temp2 = new();
        temp2.Add(temp);
        MissionLocationCardDeck = temp2;
    }

    private void PopulateMissionTwoCards()
    {
        List<List<LocationCard>> temp4 = new();
        List<LocationCard> temp = new();
        temp.Add(_locationCardDeck["6A"]);
        temp.Add(_locationCardDeck["7A"]);
        temp.Add(_locationCardDeck["11A"]);
        temp4.Add(temp);

        List<LocationCard> temp2 = new();
        temp2.Add(_locationCardDeck["1A"]);
        temp2.Add(_locationCardDeck["10A"]);
        temp2.Add(_locationCardDeck["15A"]);
        temp4.Add(temp2);

        List<LocationCard> temp3 = new();
        temp3.Add(_locationCardDeck["17A"]);
        temp4.Add(temp3);
        MissionLocationCardDeck = temp4;
    }

    private void PopulateMissionSevenCards()
    {
        List<List<LocationCard>> temp3 = new();
        List<LocationCard> temp = new();
        temp.Add(_locationCardDeck["2B"]);
        temp.Add(_locationCardDeck["6B"]);
        temp.Add(_locationCardDeck["8B"]);
        temp3.Add(temp);

        List<LocationCard> temp2 = new();
        temp2.Add(_locationCardDeck["1A"]);
        temp2.Add(_locationCardDeck["3A"]);
        temp2.Add(_locationCardDeck["10A"]);
        temp3.Add(temp2);
        MissionLocationCardDeck = temp3;
    }

        private void PopulateMissionEightCards()
    {
        List<List<LocationCard>> temp3 = new();
        List<LocationCard> temp = new();
        temp.Add(_locationCardDeck["2A"]);
        temp.Add(_locationCardDeck["8A"]);
        temp.Add(_locationCardDeck["10A"]);
        temp.Add(_locationCardDeck["15A"]);
        temp3.Add(temp);

        List<LocationCard> temp2 = new();
        temp2.Add(_locationCardDeck["17B"]);
        temp3.Add(temp2);
        MissionLocationCardDeck = temp3;
    }
}