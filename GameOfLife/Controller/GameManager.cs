using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    /// <summary>
    /// Management of the game
    /// </summary>
    public class GameManager
    {
        /// <summary>
        /// Starts the game
        /// </summary>
        public void Play()
        {
            UserInterface userInterface = new UserInterface();
            GameView gameView = new GameView();
            UserInterface.WelcomeScreen();
            
            int column = userInterface.ValidateUserInput(UserInterface.inputColomnMessage, GameParameters.minInputValue, GameParameters.maxInputValue);
            int row = userInterface.ValidateUserInput(UserInterface.inputRowMessage, GameParameters.minInputValue, GameParameters.maxInputValue);
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
