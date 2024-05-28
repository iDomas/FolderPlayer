using System.Windows.Controls;
using FolderPlayer.ViewModel;

namespace FolderPlayer.Controls
{
    public partial class MusicControl : UserControl
    {
        public MusicControl()
        {
            InitializeComponent();
            
            var musicViewModel = new MusicControlViewModel();
            DataContext = musicViewModel;
            Loaded += async (sender, args) => await musicViewModel.LoadMusicFiles();
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           Console.WriteLine("Selection changed");
        }
    }
}