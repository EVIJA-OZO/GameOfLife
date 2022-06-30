using Newtonsoft.Json;

namespace GameOfLife
{
    public class DataManager
    {
        /// <summary>
        /// Saves current game generation to the file.
        /// </summary>
        /// <param name="game">Current game generation.</param>
        public static void SaveGame(Game game)
        {
            File.WriteAllText(GameMessages.fileName, JsonConvert.SerializeObject(game));
        }

        /// <summary>
        /// Loads previously saved game file.
        /// </summary>
        public static Game? LoadGame()
        {
            Game loadgame = JsonConvert.DeserializeObject<Game>(File.ReadAllText(GameMessages.fileName));
            return loadgame;

        }
    }
}