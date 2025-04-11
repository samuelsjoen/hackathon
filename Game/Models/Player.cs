public class Player
{
    public string Name { get; set; }
    public int Score { get; set; }

    public Player(string name, int score)
    {
        this.Name = name;
        this.Score = score;
    }
}