namespace GameOfLife
{
    [Serializable]
    /// <summary>
    /// Mechanics of the game.
    /// </summary>
    public class Game : IGame
    {
        /// <summary>
        /// Array that will contain the game field.
        /// </summary>
        public int[,] GameField { get; set; }
        /// <summary>
        /// Count of current game iterations.
        /// </summary>
        public int CountOfIteration { get; set; }
        /// <summary>
        /// Count of live cells in current generation.
        /// </summary>
        public int CountOfLiveCells { get; set; }

        /// <summary>
        /// Starts the game with first random generation.
        /// </summary>
        /// <param name="column">The number of columns entered by the user.</param>
        /// <param name="row">The number of rows entered by the user.</param>
        public Game(int column, int row)
        {
            CountOfIteration = 0;
            CountOfLiveCells = 0;
            GameField = new int[column, row];
            SetRandomFirstGeneration();
        }

        /// <summary>
        /// Sets first random generation of live and dead cells in game field.
        /// </summary>
        public void SetRandomFirstGeneration()
        {
            Random random = new();
            for (int colomn = 0; colomn < GameField.GetLength(0); colomn++)
            {
                for (int row = 0; row < GameField.GetLength(1); row++)
                {
                    GameField[colomn, row] = random.Next(3) == 0 ? 1 : 0;
                }
            }
        }

        /// <summary>
        /// Gets the next generation of live and dead cells.
        /// </summary>
        public void GetNextGeneration()
        {
            int[,] newGameField = new int[GameField.GetLength(0), GameField.GetLength(1)];
            CountOfLiveCells = 0;
            for (int column = 0; column < GameField.GetLength(0); column++)
            {
                for (int row = 0; row < GameField.GetLength(1); row++)
                {
                    newGameField[column, row] = AliveCells(column, row);
                    CountOfLiveCells += newGameField[column, row];
                }
            }
            GameField = newGameField;
            CountOfIteration++;
        }

        /// <summary>
        /// Checks if current cell will be alive in next generation:
        /// Any live cell with two or three live neighbours survives,
        /// Any dead cell with three live neighbours becomes a live cell,
        /// All other live cells die in the next generation.Similarly, all other dead cells stay dead.
        /// </summary>
        /// <param name="column">Current cell column position.</param>
        /// <param name="row">Current cell row position.</param>
        /// <returns>Number 1 if cell will be alive or 0 if not.</returns>
        private int AliveCells(int column, int row)
        {
            int neighbors = CountNeighbors(column, row);
            bool aliveCell = GameField[column, row] == 1;
            if (neighbors == 3)
            {
                return 1;
            }
            else if (neighbors == 2 && aliveCell)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Counts the number of alive neighbors that current cell has.
        /// </summary>
        /// <param name="currentColumn">Current cell column position.</param>
        /// <param name="currentRow">Current cell row position.</param>
        /// <returns>Count of alive neighbors.</returns>
        private int CountNeighbors(int currentColumn, int currentRow)
        {
            int previousColumn = currentColumn - 1 < 0 ? GameField.GetLength(0) - 1 : currentColumn - 1;
            int nextColumn = currentColumn + 1 > GameField.GetLength(0) - 1 ? 0 : currentColumn + 1;
            int previousRow = currentRow - 1 < 0 ? GameField.GetLength(1) - 1 : currentRow - 1;
            int nextRow = currentRow + 1 > GameField.GetLength(1) - 1 ? 0 : currentRow + 1;

            int count = GameField[previousColumn, previousRow];
            count += GameField[currentColumn, previousRow];
            count += GameField[nextColumn, previousRow];
            count += GameField[previousColumn, currentRow];
            count += GameField[nextColumn, currentRow];
            count += GameField[previousColumn, nextRow];
            count += GameField[currentColumn, nextRow];
            count += GameField[nextColumn, nextRow];
            return count;
        }
    }
}