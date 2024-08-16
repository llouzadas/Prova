using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace FreightSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>(); // Aponta para a classe Startup definida no arquivo Startup.cs
               });
    }
}