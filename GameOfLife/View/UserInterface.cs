namespace GameOfLife
{
    /// <summary>
    /// User's interaction with game.
    /// </summary>
    public class UserInterface
    {
        /// <summary>
        /// Displays game rules.
        /// </summary>
        public static void WelcomeScreen()
        {
            Console.WriteLine(GameMessages.welcomeMessage);
            Console.WriteLine();
            Console.WriteLine(GameMessages.gameRules);
        }

        /// <summary>
        /// Gets valid number from the user.
        /// </summary>
        /// <param name="message">Text message for the user.</param>
        /// <param name="minInputValue">Defined minimal value.</param>
        /// <param name="maxInputValue">Defined maximal value.</param>
        /// <returns>User's input in defined range.</returns>
        public static int GetValidUserInput(string message, int minInputValue, int maxInputValue)
        {
            while (true)
            {
                Console.WriteLine(message);
                string value = Console.ReadLine();

                if (int.TryParse(value, out int number))
                {
                    if (number >= minInputValue && number <= maxInputValue)
                    {
                        return number;
                    }
                }
                else
                {
                    Console.WriteLine(GameMessages.errorMessage);
                }
            }
        }

        /// <summary>
        /// Handles incorrect users' input.
        /// </summary>
        public static void IncorrectDataInput()
        {
            Console.WriteLine(GameMessages.errorMessage);
        }
    }
}