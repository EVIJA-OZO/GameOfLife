using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    /// <summary>
    /// User's interaction with game
    /// </summary>
    public class UserInterface
    {
        public static string welcomeMessage = "Welcome to the Game of Life!";
        public static string gameRules = "Press any key to start a game and select size of game field.";
        public static string inputColomnMessage = "Please, input amount of colomns in range 5 to 50:";
        public static string inputRowMessage = "Please, input amount of rows in range 5 to 50:";
        public static string errorMessage = "Entered value is incorrect, please try again!";

        /// <summary>
        /// Displays game rules
        /// </summary>
        public static void WelcomeScreen()
        {
            Console.WriteLine(welcomeMessage);
            Console.WriteLine(gameRules);
            Console.ReadKey();
        }

        /// <summary>
        /// Gets input from the user
        /// </summary>
        /// <param name="message">Text message for the user</param>
        /// <returns> Returns user input as integer</returns>
        public static int GetUserInput(string message)
        {
            while (true)
            {
                Console.WriteLine(message);
                string value = Console.ReadLine();

                if (int.TryParse(value, out int result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine(errorMessage);
                }
            }
        }

        /// <summary>
        /// Gets if user's input is in defined range
        /// </summary>
        /// <param name="message">Text message for the user</param>
        /// <param name="minInputValue">Defined minimal value</param>
        /// <param name="maxInputValue">Defined maximal value</param>
        /// <returns>User's input in defined range</returns>
        public int ValidateUserInput (string message, int minInputValue, int maxInputValue)
        {
            while (true)
            {
                int number = GetUserInput(message);

                if (number >= minInputValue && number <= maxInputValue)
                {
                    return number;
                }
                else
                {
                    Console.WriteLine(errorMessage);
                    
                }
            }
        }




    }
}
