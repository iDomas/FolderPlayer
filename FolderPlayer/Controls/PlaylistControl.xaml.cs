using System.Windows.Controls;
using FolderPlayer.Model;
using FolderPlayer.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace FolderPlayer.Controls
{
    public partial class PlaylistControl : UserControl
    {
        private readonly PlaylistControlViewModel _viewModel;


        public PlaylistControl()
        {
            InitializeComponent();

            _viewModel = App.AppHost!.Services.GetRequiredService<PlaylistControlViewModel>();
            DataContext = _viewModel;
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 0) return;
            var item = e.AddedItems[0];
            if (item is Folder folder)
            {
                _viewModel.LoadMusicFiles(folder.Path);
            }
        }
    }
}