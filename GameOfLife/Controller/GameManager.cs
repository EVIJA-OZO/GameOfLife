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
            DisplayGame.Display(game.GameField, game);

            while (true)
            {
                game.GetNextGeneration();
                DisplayGame.Display(game.GameField, game);
                Thread.Sleep(1000);

                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Spacebar)
                {
                    Console.WriteLine(GameMessages.stopGame);
                    string choice = Console.ReadLine().ToLower();
                    if (choice == "s")
                    {
                        DataManager.SaveGame(game);
                    }
                    else if (choice == "l")
                    {
                        game = DataManager.LoadGame();
                    }
                    else if (choice == "x")
                    {
                        break;
                    }
                }
            }
        }
    }
}