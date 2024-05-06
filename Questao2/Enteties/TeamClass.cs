using Newtonsoft.Json;

namespace Questao2.Enteties
{
    public class TeamClass
    {
        [JsonProperty("competition")]
        public string Competition { get; set; } = string.Empty;
        [JsonProperty("year")]
        public int Year { get; set; }
        [JsonProperty("round")]
        public string Round { get; set; } = string.Empty;
        [JsonProperty("team1")]
        public string Team1 { get; set; } = string.Empty;
        [JsonProperty("team2")]
        public string Team2 { get; set; } = string.Empty;
        [JsonProperty("team1goals")]
        public string Team1Goals { get; set; } = string.Empty;
        [JsonProperty("team2goals")]
        public string Team2Goals { get; set; } = string.Empty;
    }
}