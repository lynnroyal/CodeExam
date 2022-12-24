// See https://aka.ms/new-console-template for more information

using System.Collections;

public static class Program
{
    public static void Main(string[] args)
    {
        var game = new Game();

        var play1 = new Player(){IsFirst = false, Name = "电脑", IsComputer = true};
        var play2 = new Player(){IsFirst = true, Name = "玩家"};
        play1.Join(game);
        play2.Join(game);

        while (true)
        {
            game.Sticks.PrintScreen();
            
            if (game.CurrentPlayer.IsComputer)
            {
                game.CurrentPlayer.PickUp();
            }
            else
            {
                Console.WriteLine("请输入你的选择(行数,数量)");
                var cmd = Console.ReadLine();

                var arrCmd = cmd.Split(",");

                try
                {
                    game.CurrentPlayer.PickUp(Convert.ToInt32(arrCmd[0]), Convert.ToInt32(arrCmd[1]));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }
            

            if (game.IsGameOver)
            {
                break;
            }
        }

        if (game.IsGameOver)
        {
            Console.WriteLine("游戏结束");
        }
    }
}