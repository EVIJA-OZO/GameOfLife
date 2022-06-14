namespace GameOfLife
{
    /// <summary>
    /// Management of the game.
    /// </summary>
    public class GameManager
    {
        /// <summary>
        /// Starts the game.
        /// </summary>
        public void Play()
        {
            UserInterface userInterface = new UserInterface();
            GameView gameView = new GameView();
            UserInterface.WelcomeScreen();
            
            int column = userInterface.GetValidUserInput(UserInterface.inputColomnMessage, GameParameters.minInputValue, GameParameters.maxInputValue);
            int row = userInterface.GetValidUserInput(UserInterface.inputRowMessage, GameParameters.minInputValue, GameParameters.maxInputValue);
            Game game = new Game(column, row);
            gameView.View(game.gameField);
            while (true)
            {
                game.GetNextGeneration();
                gameView.View(game.gameField);
                Thread.Sleep(1000);
            }
        }
    }
}
