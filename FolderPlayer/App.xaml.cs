using System.Windows;
using FolderPlayer.Services;
using FolderPlayer.Services.Persistence;
using FolderPlayer.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FolderPlayer
{
    public partial class App : Application
    {
        public static IHost? AppHost { get; private set; }

        public App()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            AppHost = Host.CreateDefaultBuilder()
                .ConfigureServices((context, collection) =>
                {
                    ConfigureServices(collection);
                })
                .Build(); 
        }


        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost!.StartAsync();
            base.OnStartup(e);
            var mainWindow = AppHost.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await AppHost!.StopAsync();
            base.OnExit(e);
        }

        private void ConfigureServices(IServiceCollection? services)
        {
            if (services == null) return;
            services.AddLogging();

            services.AddSingleton<IDataPersistence, DataPersistence>();

            services.AddSingleton<IFolderService, FolderService>();
            services.AddSingleton<IMusicFileService, MusicFileService>();
            services.AddSingleton<IPlayerService, PlayerService>();

            services.AddSingleton<MainWindow>();
            services.AddTransient<MenuControlViewModel>();
            services.AddTransient<MusicControlViewModel>();
            services.AddTransient<PlaylistControlViewModel>();
            services.AddTransient<PlayerControlViewModel>();
            services.AddTransient<ProgressBarControlViewModel>();
        }
    }
}
