namespace GameOfLife
{
    /// <summary>
    /// Interface for mechanics of the game.
    /// </summary>
    public interface IGame
    {
        void SetRandomFirstGeneration();
        void GetNextGeneration();
    }
}