using PoliceService.Application.Functions.PoliceUnits.Commands.AssignCrimeCommand;
using System.Text;
using System.Text.Json;

namespace PoliceService.Application.HttpClients
{
    public class CrimeHttpClient : IHttpCrimeClient
    {
        private readonly HttpClient _httpClient;

        public CrimeHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> TryAssignUnit(CrimeAssignViewModel model)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, $"http://crimeservice:80/crimes/assign/?crimeId={model.crimeId}&unitId={model.unitId}");
            var response = await _httpClient.SendAsync(requestMessage);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}