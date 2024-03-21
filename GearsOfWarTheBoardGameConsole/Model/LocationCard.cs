public class LocationCard
{
    public LocationCard(string name, string title, string desription, List<string> enemies)
    {
        Name = name;
        Title = title;
        Description = desription;
        Enemies = enemies;
    }

    public string Name { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public List<string> Enemies { get; set; }
}