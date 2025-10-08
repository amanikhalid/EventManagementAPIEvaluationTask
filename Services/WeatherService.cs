using System.Net.Http;
using System.Text.Json;

namespace EventManagementAPIEvaluationTask.Services
{
    public interface IWeatherService
    {
        Task<string?> GetWeatherForecastAsync(string location, DateTime date);
    }

    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _http;

        public WeatherService(HttpClient http)
        {
            _http = http;
        }

        public async Task<string?> GetWeatherForecastAsync(string location, DateTime date)
        {
          

            double latitude = 23.6;
            double longitude = 58.6;

            string apiUrl = $"https://api.open-meteo.com/v1/forecast?latitude={latitude}&longitude={longitude}&daily=temperature_2m_max&timezone=auto&start_date={date:yyyy-MM-dd}&end_date={date:yyyy-MM-dd}";

            var response = await _http.GetAsync(apiUrl);

            if (!response.IsSuccessStatusCode)
                return null;

            using var stream = await response.Content.ReadAsStreamAsync();
            using var doc = await JsonDocument.ParseAsync(stream);

            try
            {
                var temp = doc.RootElement.GetProperty("daily").GetProperty("temperature_2m_max")[0].GetDouble();
                return $"Expected max temp: {temp}°C";
            }
            catch
            {
                return null;
            }
        }
    }
}
