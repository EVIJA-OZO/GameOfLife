namespace GameOfLife
{
    /// <summary>
    /// Interface for management of the game.
    /// </summary>
    public interface IGameManager
    {
        /// <summary>
        /// Takes and processes the user's input to start the chosen game.
        /// </summary>
        void Play();

        /// <summary>
        /// Starts the game.
        /// </summary>
        void SingleGame();

        /// <summary>
        /// Starts multiple games.
        /// </summary>
        void StartMultipleGames();

        /// <summary>
        /// Shows users selected games to console.
        /// </summary>
        void ShowSelectedGames();
    }
}
