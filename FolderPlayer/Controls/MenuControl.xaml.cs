using FolderPlayer.ViewModel;
using System.Windows.Controls;
using FolderPlayer;
using Microsoft.Extensions.DependencyInjection;


namespace FolderPlayer.Controls
{
    public partial class MenuControl : UserControl
    {
        private readonly MenuControlViewModel _viewModel;

        public MenuControl()
        {
            InitializeComponent();

            _viewModel = App.AppHost!.Services.GetRequiredService<MenuControlViewModel>();
            DataContext = _viewModel;
            Loaded += async (sender, args) => await _viewModel.LoadFolders();
        }
    }
}
