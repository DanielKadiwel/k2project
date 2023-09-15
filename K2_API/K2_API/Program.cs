using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using Cliente_Api;

public class Program
{
    public static void Main(string[] args)
    {
        BuildWebHost(args).Run();
    }

    public static IWebHost BuildWebHost(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
               .UseIISIntegration()
               .UseStartup<Startup>()
               .Build();
}