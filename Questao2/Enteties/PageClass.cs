using Newtonsoft.Json;

namespace Questao2.Enteties
{
    public class PageClass
    {
        [JsonProperty("page")]
        public int Page { get; set; }
        [JsonProperty("per_page")]
        public int PerPage { get; set; }
        [JsonProperty("total")]
        public int TotalRegister { get; set; }
        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }
        [JsonProperty("data")]
        public ListTeamsClass Teams { get; set; } = new ListTeamsClass();
    }
}