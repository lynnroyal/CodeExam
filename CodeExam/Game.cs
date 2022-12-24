public class Game
{
    public int[] Sticks = {3, 5, 7};
    // public int[] Sticks = {0,2,1};

    public bool IsGameOver => Sticks.IsEmpty();

    public List<Player> Players { get; set; } = new();
        
    public int Round { get; set; } = 1;

    public Player CurrentPlayer
    {
        get
        {
            if (Round % 2 == 1)
            {
                return Players.FirstOrDefault(a => a.IsFirst);
            }

            return Players.FirstOrDefault(a => !a.IsFirst);
        }
    }

    private readonly int[] _digits;

    public Game()
    {
    }

    public Game setSticks(int[] sticks)
    {
        return this;
    }
}