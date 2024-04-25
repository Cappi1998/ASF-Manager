using ASF_Manager.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ASF_Manager
{
    class GetOwnedGames
    {
        public static List<int> GetGames(string SteamID64)
        {
            string UrlRequest = "https://api.steampowered.com/IPlayerService/GetOwnedGames/v1/";

            int countOwnedGames = 0;

        TryAgain:
            var rest = new RequestBuilder(UrlRequest).GET()
                   .AddPOSTParam("key", Main._Main.txt_steamAPI.Text)
                   .AddPOSTParam("steamid", SteamID64)
                   .Execute();

            if (rest.StatusCode == 0)
            {
                ++countOwnedGames;

                if (countOwnedGames >= 5)
                {
                    return null;
                }
                goto TryAgain;
            }

            if (rest == null) return null;

            if (rest.Content == "{\"response\":{}}")
            {
                Log.error($"No games owned found, your profile may be private");
                Log.info($"<{SteamID64}> Perfil Privado");
                return null;
            }


            OwnedGames.Root response = JsonConvert.DeserializeObject<OwnedGames.Root>(rest.Content);

            List<int> GamesOwned = new List<int>();

            if (response.response.total_count == 0 && response.response.games == null)
            {
                return GamesOwned;
            }

            foreach (var game in response.response.games)
            {
                GamesOwned.Add(game.appid);
            }

            Log.info($"<{SteamID64}> Total Games Owned Found: {GamesOwned.Count}");
            return GamesOwned;
        }
    }
}
