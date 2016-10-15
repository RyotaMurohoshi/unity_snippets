public class Player
{
    public string Name { get; }
    public int Level { get; }

    public Player(string name, int level)
    {
        Name = name;
        Level = level;
    }

    public override string ToString() => $"{nameof(Player)}[name = {Name}, level = {Level}]";
}
