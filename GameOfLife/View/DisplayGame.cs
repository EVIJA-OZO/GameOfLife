namespace GameOfLife
{
    /// <summary>
    /// View of the game field.
    /// </summary>
    public class DisplayGame
    {
        /// <summary>
        /// Makes view of the game field.
        /// </summary>
        /// <param name="args">Array containing the game field.</param>
        public static void Display(int[,] args, Game game)
        {
            Console.Clear();
            for (int row = 0; row < args.GetLength(1); row++)
            {
                for (int column = 0; column < args.GetLength(0); column++)
                {
                    Console.Write(args[column, row] == 1 ? "*" : " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine($"Iteration: {game.CountOfIteration}");
            Console.WriteLine($"Live cells: {game.CountOfLiveCells}");
            Console.WriteLine(GameMessages.pauseGame);
        }
    }
}