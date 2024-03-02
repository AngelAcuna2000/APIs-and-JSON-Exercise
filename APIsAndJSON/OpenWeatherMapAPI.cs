using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    public class OpenWeatherMapAPI
    {
        public static void GetTemp()
        {
            var apiKeyObj = File.ReadAllText("appsettings.json");

            var apiKey = JObject.Parse(apiKeyObj).GetValue("apiKey").ToString();

            var url = $"https://api.openweathermap.org/data/2.5/weather?lat={35.06017}&lon={-80.69666}&units={"imperial"}&appid={apiKey}\r\n";

            var client = new HttpClient();

            var response = client.GetStringAsync(url).Result;

            var weatherObj = JObject.Parse(response);

            Console.WriteLine($"Temp: {weatherObj["main"]["temp"]} Fahrenheit");
        }
    }
}
