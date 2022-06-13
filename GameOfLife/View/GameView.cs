using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    /// <summary>
    /// 
    /// </summary>
    public class GameView
    {
        /// <summary>
        /// Makes view of the game field
        /// </summary>
        /// <param name="args">Array containing the game field</param>
        public void View(int[,] args)
        {
            Console.Clear();

            for (int x = 0; x < args.GetLength(0); x++)
            {
                for (int y = 0; y < args.GetLength(1); y++)
                {
                    Console.Write(args[x, y] == 1 ? "*" : " ");
                }

                Console.WriteLine();
            }
        }
    }
}
