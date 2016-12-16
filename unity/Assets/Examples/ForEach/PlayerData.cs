public class Player
{
    readonly string playerName;
    public string PlayerName { get { return playerName; } }

    readonly int maxHp;
    public int MaxHp { get { return maxHp; } }

    public Player(string playerName, int maxHp)
    {
        this.playerName = playerName;
        this.maxHp = maxHp;
    }
}
