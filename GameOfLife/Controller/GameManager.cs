using Newtonsoft.Json;

namespace GameOfLife
{
    /// <summary>
    /// Management of the game.
    /// </summary>
    public class GameManager : IGameManager
    {
        /// <summary>
        /// Starts the game.
        /// </summary>
        public void Play()
        {
            UserInterface.WelcomeScreen();

            int column = UserInterface.GetValidUserInput(GameMessages.inputColomnMessage, GameParameters.minInputValue, GameParameters.maxInputValue);
            int row = UserInterface.GetValidUserInput(GameMessages.inputRowMessage, GameParameters.minInputValue, GameParameters.maxInputValue);
            Game game = new(column, row);
            GameView.View(game.GameField);

            while (true)
            {
                game.GetNextGeneration();
                GameView.View(game.GameField);
                Console.WriteLine($"Iteration: {game.CountOfIteration}");
                Console.WriteLine($"Live cells: {game.CountOfLiveCells}");
                Console.WriteLine(GameMessages.pauseGame);
                Thread.Sleep(1000);

                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Spacebar)
                {
                    Console.WriteLine(GameMessages.stopGame);
                    string choice = Console.ReadLine().ToLower();
                    if (choice == "s")
                    {
                        SaveGame(game);
                    }
                    else if (choice == "l")
                    {
                        game = LoadGame();
                    }
                    else if (choice == "x")
                    {
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Saves current game generation to the file.
        /// </summary>
        /// <param name="game">Current game generation.</param>
        public static void SaveGame(Game game)
        {
            File.WriteAllText(GameMessages.fileName, JsonConvert.SerializeObject(game));
        }

        /// <summary>
        /// Loads previously saved game file.
        /// </summary>
        public static Game? LoadGame()
        {
            Game loadgame = JsonConvert.DeserializeObject<Game>(File.ReadAllText(GameMessages.fileName));
            return loadgame;

        }
    }
}