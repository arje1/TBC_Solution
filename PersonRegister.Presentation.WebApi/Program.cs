using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using PersonRegister.Infrastructure.Database.Extensions;

namespace PersonRegister.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // თუ IIS-ზე გაშვებისას პრობლემა შეიქმნა ბაზის ავტომატური გენერირების გამო, 
            // ბაზის შექმნა გაუშვით ხელით და მეორის(.2) ნაცვლად გაუშვით პირველი(.1) სტრიქონი. 
            //CreateHostBuilder(args).Build().Run();                          //.1
            CreateHostBuilder(args).Build().MigrateDatabase().Run();  //.2
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
