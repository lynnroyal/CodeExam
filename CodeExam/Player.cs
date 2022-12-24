public class Player
{

    private Game _game;
        
    public bool IsFirst { get; set; }
        
    public bool IsComputer { get; set; }

    public string Name { get; set; }

    public void Join(Game game)
    {
        this._game = game;
        this._game.Players.Add(this);
    }
        
    public void PickUp()
    {

        var sticks = new[]
        {
            _game.Sticks[0],
            _game.Sticks[1],
            _game.Sticks[2],
        };

        var row = 0;
        var num = 0;


        var seqIdx = sticks.MaxToMinIdx();
        for (var i = 0; i < seqIdx.Length; i++)
        {
            var idx = seqIdx[i];
            if (sticks[idx] == 0)
            {
                continue;
            }

            var savePoint = sticks[idx];

            for (var j = 0; j < sticks[idx]; j++)
            {
                sticks[idx]--;
                num++;
                    
                if (!sticks.IsBalanced())
                {
                    row = idx + 1;
                    i = seqIdx.Length;
                    break;
                }
                    
                if (sticks[idx] == 0)
                {
                    sticks[idx] = savePoint;
                    row = 0;
                    num = 0;
                }
            }
        }

        if (row == 0 && num == 0)
        {
            seqIdx = sticks.MaxToMinIdx();

            for (var i = 0; i < sticks.MaxToMinIdx().Length; i++)
            {
                var idx = seqIdx[i];
                if (sticks[idx] == 0)
                {
                    continue;
                }
                row = idx + 1;
                num = 1;
                if (sticks[idx] != 0)
                {
                    sticks[idx] -= 1;
                }
                break;
            }
        }

        _game.Sticks = sticks;
        Console.WriteLine($"{Name}选择了从{row}行取{num}个");
            
        if (_game.Sticks.IsEmpty())
        {
            Console.WriteLine($"{Name}输了");
        }
        _game.Round += 1;

    }

    public void PickUp(int row, int num)
    {
        if (row > 4 || row < 1)
        {
            throw new Exception("行数不正确");
        }
        row -= 1;
        if (num > _game.Sticks[row] || num < 1)
        {
            throw new Exception("数量不正确");
        }
            
            
        Console.WriteLine($"{Name}选择了从{row+1}行取{num}个");
        _game.Sticks[row] -= num;

        if (_game.Sticks.IsEmpty())
        {
            Console.WriteLine($"{Name}输了");
        }
        _game.Round += 1;

    }
}