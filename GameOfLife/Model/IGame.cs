namespace GameOfLife
{
    /// <summary>
    /// Interface for mechanics of the game.
    /// </summary>
    public interface IGame
    {
        /// <summary>
        /// Sets first random generation of live and dead cells in game field.
        /// </summary>
        void SetRandomFirstGeneration();

        /// <summary>
        /// Gets the next generation of live and dead cells.
        /// </summary>
        void GetNextGeneration();
    }
}