using System;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

public class Program
{
    public static async Task Main(string [] args)
    {
        try
        {
            CultureInfo.CurrentCulture = new CultureInfo("en-GB");
            var config = new ConfigurationBuilder()
                .AddJsonFile(Directory.GetCurrentDirectory() + "/appsettings.json")
                .Build();
            var ap = new ApodClient(config["ApiKey"]);
            foreach (var photo in await ap.GetAsync(Convert.ToInt32(args[1])))
            {
                Console.WriteLine(photo.ToString());
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
