using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MTG.Common;
using MTG.Common.Repositories;
using MTG.Common.Repository.Interfaces;

namespace MTGApplication
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;

            Application.Run(ServiceProvider.GetRequiredService<Oversigt>());
        }
        
        public static IServiceProvider ServiceProvider { get; private set; }
        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {
                    services.AddScoped<MagicContext>();
                    services.AddTransient<IDeckRepository, DeckRepository>();
                    services.AddTransient<Oversigt>();
                    services.AddTransient<DeckForm>();
                });
        }
    }
}