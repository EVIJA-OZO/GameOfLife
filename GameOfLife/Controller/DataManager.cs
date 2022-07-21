using Newtonsoft.Json;

namespace GameOfLife
{
    /// <summary>
    /// Management of the game data and files.
    /// </summary>
    public class DataManager
    {
        /// <summary>
        /// Saves current game generation to the file.
        /// </summary>
        /// <param name="games">List that holds all games.</param>
        public static void SaveGame(List<Game> games)
        {
            File.WriteAllText(GameMessages.fileName, JsonConvert.SerializeObject(games));
        }

        /// <summary>
        /// Loads previously saved game file.
        /// </summary>
        public static List<Game> LoadGame()
        {
            List<Game> loadGames = JsonConvert.DeserializeObject<List<Game>>(File.ReadAllText(GameMessages.fileName));

            if (loadGames == null)
            {
                return new List<Game>();
            }

            return loadGames;
        }
    }
}