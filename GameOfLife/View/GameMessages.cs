namespace GameOfLife
{
    /// <summary>
    /// Repository for game messages.
    /// </summary>
    public class GameMessages
    {
        public const string welcomeMessage = "Welcome to the Game of Life!";
        public const string gameRules = "Press any key to start a game and select size of game field.";
        public const string inputColomnMessage = "Please, input amount of colomns in range 5 to 50:";
        public const string inputRowMessage = "Please, input amount of rows in range 5 to 50:";
        public const string errorMessage = "Entered value is incorrect, please try again!";
        public const string pauseGame = "Press spacebar to pause the game.";
        public const string stopGame = "Press Enter to continue game, \nPress S to save game, \nPress L to load game, \nOr X to exit game.";
        public const string fileName = "GameOfLife.json";
        public const string fileError = "No game file to load.";
    }
}