using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace MsalAuthInMauiBlazor.Data
{
    public class WeatherForecastService
    {
        private readonly IConfiguration _configuration;
        private readonly Settings _settings;

        public WeatherForecastService(IConfiguration configuration)
        {
            _configuration = configuration;
            _settings = _configuration.GetRequiredSection("Settings").Get<Settings>();
        }

        // Call the Secure Web API.
        public async Task<List<WeatherForecast>> CallSecureWebApi()
        {
            if (Globals.AccessToken == null)
                return new();

            var result = new List<WeatherForecast>();

            // Get the weather forecast data from the Secure Web API.
            var client = new HttpClient();

            // Create the request.
            var message = new HttpRequestMessage(HttpMethod.Get, $"{_settings?.ApiUrl}weatherforecast");

            // Add the Authorization Bearer header.
            message.Headers.Add("Authorization", $"Bearer {Globals.AccessToken}");

            // Send the request.
            var response = await client.SendAsync(message).ConfigureAwait(false);
            
            // Get the response.
            var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (responseString == string.Empty)
            {
                return result;
            }

            // Serialize the response.
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            result = JsonSerializer.Deserialize<List<WeatherForecast>>(responseString, options);

            // Ensure a success status code.
            response.EnsureSuccessStatusCode();

            // Return the response.
            return result!;
        }
    }
}