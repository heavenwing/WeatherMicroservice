namespace WeatherMicroservice
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Nancy;

    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get("/", (x) =>
            {
                // AddToLog("Delay 1\n");
                // await Task.Delay(1000);

                // AddToLog("Delay 2\n");
                // await Task.Delay(1000);

                // AddToLog("Executing async http client\n");
                // var client = new HttpClient();
                // var res = await client.GetAsync("http://nancyfx.org");
                // var content = await res.Content.ReadAsStringAsync();

                // AddToLog("Response: " + content.Split('\n')[0] + "\n");

                // return (Response)GetLog();

                var latString = (string)this.Request.Query["lat"];
                //Console.WriteLine(latString.GetType());

                var longString = (string)this.Request.Query["long"];

                var latitude = latString.TryParse();
                var longitude = longString.TryParse();

                if (latitude.HasValue && longitude.HasValue)
                {
                    var forecast = new List<WeatherReport>();
                    for (var days = 1; days < 6; days++)
                    {
                        forecast.Add(new WeatherReport(latitude.Value, longitude.Value, days));
                    }
                    return forecast;
                }
                else
                {
                    return $"Retrieving Weather for lat: {latitude}, long: {longitude}";
                }
            });
        }

        private void AddToLog(string logLine)
        {
            if (!Context.Items.ContainsKey("Log"))
            {
                Context.Items["Log"] = string.Empty;
            }

            Context.Items["Log"] = (string)Context.Items["Log"] + DateTime.Now + " : " + logLine;
        }

        private string GetLog()
        {
            if (!Context.Items.ContainsKey("Log"))
            {
                Context.Items["Log"] = string.Empty;
            }

            return (string)Context.Items["Log"];
        }
    }
}
