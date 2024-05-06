namespace Questao2.Operations
{
    public class OperationHttpClass : IDisposable
    {
        private string _urlBase = "https://jsonmock.hackerrank.com/api/football_matches";

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public string ExecutaUrl(string parameter)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, _urlBase + parameter);
                HttpResponseMessage resp = httpClient.Send(request);

                resp.EnsureSuccessStatusCode();

                return resp.Content.ReadAsStringAsync().Result;
            }
        }
    }
}