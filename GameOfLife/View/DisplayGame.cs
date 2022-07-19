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
        /// <param name="game">Current game generation.</param>
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

        /// <summary>
        /// Makes view of multiple games field (2X4).
        /// </summary>
        /// <param name="games">List that holds all games.</param>
        /// <param name="selectedEightGames">List that holds selected 8 games numbers.</param>
        public static void DisplayMultipleGames(List<Game> games, List<int> selectedEightGames, int TotalAliveCells)
        {
            Console.Clear();
            Console.WriteLine($"Total games: {games.Count}");
            Console.WriteLine($"Iteration: {games[0].CountOfIteration}");
            Console.WriteLine($"Total live cells: {TotalAliveCells}");
            Console.WriteLine(GameMessages.pauseGame);

            for (int rowNumber = 0; rowNumber < 2; rowNumber++)
            {
                DisplayFields(games, selectedEightGames, games[0].GameField, rowNumber);
            }
        }

        /// <summary>
        /// Displays four game fields horizontally.
        /// </summary>
        /// <param name="games">List that holds all games.</param>
        /// <param name="selectedEightGames">List that holds selected 8 games numbers.</param>
        /// <param name="args">Array containing the game field.</param>
        /// <param name="rowNumber">The number of current game fields row.</param>
        private static void DisplayFields(List<Game> games, List<int> selectedEightGames, int[,] args, int rowNumber)
        {
            bool gameTitleShowed = false;
            Console.WriteLine();

            for (int row = 0; row < args.GetLength(1); row++)
            {
                if (!gameTitleShowed)
                {
                    gameTitleShowed = GameTitle(games, selectedEightGames, rowNumber);
                }

                for (int fieldNumber = 0; fieldNumber < 4; fieldNumber++)
                {
                    Console.Write(" ");

                    for (int column = 0; column < args.GetLength(0); column++)
                    {
                        Console.Write(games[selectedEightGames[fieldNumber + 4 * rowNumber]].GameField[column, row] == 1 ? "*" : " ");
                    }

                    Console.Write("             ");
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Creates titles of games fields in multiple game mode.
        /// </summary>
        /// <param name="games">List that holds all games.</param>
        /// <param name="selectedEightGames">List that holds selected 8 games numbers.</param>
        /// <param name="rowNumber">The number of current game fields row.</param>
        /// <returns>True - that title was made and is visible on console.</returns>
        private static bool GameTitle(List<Game> games, List<int> selectedEightGames, int rowNumber)
        {
            int gameNumber;
            string spaceBetween = "";
            string titleString;
            gameNumber = 4 * rowNumber;
            Console.WriteLine();

            for (int fieldNumber = 0; fieldNumber < 4; fieldNumber++)
            {
                titleString = $" Game #{selectedEightGames[fieldNumber + 4 * rowNumber]}. Alive:{games[selectedEightGames[gameNumber]].CountOfLiveCells}";

                for (int k = 0; k < games[0].GameField.GetLength(0) * 2 - titleString.Length; k++)
                {
                    spaceBetween += " ";
                }

                Console.Write(titleString);
                Console.Write(spaceBetween);
                spaceBetween = "";
                gameNumber++;
            }

            Console.WriteLine();
            return true;
        }
    }
}