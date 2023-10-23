using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;


[ExcludeFromCodeCoverage]
public class Program
{
    //sets appsettings and local app settings plus the EVs
    

    public static async void Main(string[] args)
    {
        try
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder();

            IHost host = builder.Build();

            //set credential
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").Contains("Local"))
            {
                string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                                           "Credentials",
                                           "credential.json");
                Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
            }

            Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.Console().CreateLogger();//().MinimumLevel.Debug().WriteTo.Console().CreateLogger();


            //create host builder
            CreateHostBuilder();
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "something went wrong");
        }
        finally
        {
            await Log.CloseAndFlushAsync();
        }
    }

    private static void CreateHostBuilder()
    {
        
    }
}