public class LocustAiCard
{
    public LocustAiCard(string banner, string primaryAttack, string otherwiseAttack, bool hasASecondDraw, List<string> listOfLocustSounds = null)
    {
        Banner = banner;
        PrimaryAttack = primaryAttack;
        OtherWiseAttack = otherwiseAttack;
        HasASecondDraw = hasASecondDraw;
        listOfLocustSounds ??= new List<string>();
        LocustSounds = listOfLocustSounds;
    }
    public string Banner { get; set; }
    public string PrimaryAttack { get; set; }
    public string OtherWiseAttack { get; set; }
    public bool HasASecondDraw { get; set; }
    public List<string> LocustSounds { get; set; } = new List<string>();

}