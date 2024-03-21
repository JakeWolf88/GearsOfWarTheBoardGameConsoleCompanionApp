public class LocustAiCard
{
    public LocustAiCard(string banner, string primaryAttack, string otherwiseAttack, bool hasASecondDraw)
    {
        Banner = banner;
        PrimaryAttack = primaryAttack;
        OtherWiseAttack = otherwiseAttack;
        HasASecondDraw = hasASecondDraw;
    }
    public string Banner { get; set; }
    public string PrimaryAttack { get; set; }
    public string OtherWiseAttack { get; set; }
    public bool HasASecondDraw { get; set; }

}