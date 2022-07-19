namespace GameOfLife
{
    /// <summary>
    /// Management of the game.
    /// </summary>
    public class GameManager : IGameManager
    {
        /// <summary>
        /// List that holds all games.
        /// </summary>
        public List<Game> games = new();

        /// <summary>
        /// List that holds selected 8 games numbers that will be displayed to console.
        /// </summary>
        public List<int> selectedEightGames = new(8);

        /// <summary>
        /// Count of total active games.
        /// </summary>
        public int TotalNumberOfGames { get; set; }

        /// <summary>
        /// Count of total alive cells in list "games".
        /// </summary>
        public int TotalAliveCells { get; set; }

        /// <summary>
        /// The number of columns entered by the user.
        /// </summary>
        public int Column { get; set; }

        /// <summary>
        /// The number of rows entered by the user.
        /// </summary>
        public int Row { get; set; }

        /// <summary>
        /// Takes and processes the user's input to start the chosen game.
        /// </summary>
        public void Play()
        {
            UserInterface.WelcomeScreen();
            switch (Console.ReadKey(true).Key)
            {
                // Single game.
                case ConsoleKey.D1:
                    SingleGame();
                    break;
                // Multiple games.
                case ConsoleKey.D2:
                    StartMultipleGames();
                    ShowSelectedGames();
                    break;
                default:
                    UserInterface.IncorrectDataInput();
                    break;
            }
        }

        /// <summary>
        /// Starts the game.
        /// </summary>
        public void SingleGame()
        {
            bool exit = false;
            Column = UserInterface.GetValidUserInput(GameMessages.inputColomnMessage, GameParameters.minInputValue, GameParameters.maxInputValue);
            Row = UserInterface.GetValidUserInput(GameMessages.inputRowMessage, GameParameters.minInputValue, GameParameters.maxInputValue);
            Game game = new(Column, Row);
            games.Add(game);
            DisplayGame.Display(game.GameField, game);

            while (!exit)
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
                        DataManager.SaveGame(games);
                    }
                    else if (choice == "l")
                    {
                        games = DataManager.LoadGame();
                        game = games[0];
                    }
                    else if (choice == "x")
                    {
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Starts multiple games.
        /// </summary>
        public void StartMultipleGames()
        {
            Column = UserInterface.GetValidUserInput(GameMessages.inputColomnMessage, GameParameters.minInputValue, GameParameters.maxInputValue);
            Row = UserInterface.GetValidUserInput(GameMessages.inputRowMessage, GameParameters.minInputValue, GameParameters.maxInputValue);
            TotalNumberOfGames = UserInterface.GetValidUserInput(GameMessages.numberOfGames, GameParameters.minMultipleGames, GameParameters.maxMultipleGames);

            for (int gameNumber = 0; gameNumber < TotalNumberOfGames; gameNumber++)
            {
                Game game = new(Column, Row);
                games.Add(game);
            }

            GetSelectedGames();
        }

        /// <summary>
        /// Gets valid eight game numbers from the user.
        /// </summary>
        private void GetSelectedGames()
        {
            selectedEightGames = new List<int>();

            while (selectedEightGames.Count < 8)
            {
                Console.WriteLine(GameMessages.selectEightGames);
                string value = Console.ReadLine();
                if (int.TryParse(value, out int gameNumber))
                {
                    if (gameNumber <= games.Count)
                    {
                        selectedEightGames.Add(gameNumber);
                    }
                    else
                    {
                        Console.WriteLine(GameMessages.errorMessage);
                    }
                }
            }
        }

        /// <summary>
        /// Shows users selected 8 games to console.
        /// </summary>
        public void ShowSelectedGames()
        {
            bool exit = false;
            DisplayGame.DisplayMultipleGames(games, selectedEightGames, TotalAliveCells);

            while (!exit)
            {
                TotalAliveCells = 0;
                foreach (var game in games)
                {
                    game.GetNextGeneration();
                    TotalAliveCells += game.CountOfLiveCells;
                }

                DisplayGame.DisplayMultipleGames(games, selectedEightGames, TotalAliveCells);
                Thread.Sleep(1000);

                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Spacebar)
                {
                    Console.WriteLine(GameMessages.stopGame);
                    string choice = Console.ReadLine().ToLower();

                    if (choice == "s")
                    {
                        DataManager.SaveGame(games);
                    }
                    else if (choice == "l")
                    {
                        games = DataManager.LoadGame();
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