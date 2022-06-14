﻿namespace GameOfLife
{
    /// <summary>
    /// View of the game field.
    /// </summary>
    public class GameView
    {
        /// <summary>
        /// Makes view of the game field.
        /// </summary>
        /// <param name="args">Array containing the game field.</param>
        public void View(int[,] args)
        {
            Console.Clear();
            for (int row = 0; row < args.GetLength(0); row++)
            {
                for (int column = 0; column < args.GetLength(1); column++)
                {
                    Console.Write(args[row , column] == 1 ? "*" : " ");
                }
                Console.WriteLine();
            }
        }
    }
}