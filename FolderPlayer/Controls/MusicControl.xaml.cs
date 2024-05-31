using System.Windows.Controls;
using FolderPlayer.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace FolderPlayer.Controls
{
    public partial class MusicControl : UserControl
    {
        public MusicControl()
        {
            InitializeComponent();

            var musicViewModel = App.AppHost!.Services.GetRequiredService<MusicControlViewModel>();
            DataContext = musicViewModel;
            //Loaded += async (sender, args) => await musicViewModel.LoadMusicFiles();
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           Console.WriteLine("Selection changed");
        }
    }
}