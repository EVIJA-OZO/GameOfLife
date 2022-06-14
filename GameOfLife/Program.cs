﻿namespace GameOfLife
{
    /// <summary>
    /// Main class of the game.
    /// </summary>
    public class Program
    {
        static void Main()
        {
            /// <summary>
            /// Runs the game.
            /// </summary>
            GameManager gameManager = new GameManager();
            gameManager.Play();
        }
    }
}