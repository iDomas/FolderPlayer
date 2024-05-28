using System.Windows.Controls;
using FolderPlayer.ViewModel;

namespace FolderPlayer.Controls
{
    public partial class MenuControl : UserControl
    {
        private readonly MenuControlViewModel _viewModel;

        public MenuControl()
        {
            InitializeComponent();

            _viewModel = new MenuControlViewModel();
            DataContext = _viewModel;
            Loaded += async (sender, args) => await _viewModel.LoadFolders();
        }
    }
}