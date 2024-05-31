using System.Windows.Controls;
using FolderPlayer.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace FolderPlayer.Controls
{
    /// <summary>
    /// Interaction logic for PlayerControl.xaml
    /// </summary>
    public partial class PlayerControl : UserControl
    {
        private readonly PlayerControlViewModel _viewModel;

        public PlayerControl()
        {
            InitializeComponent();

            _viewModel = App.AppHost!.Services.GetRequiredService<PlayerControlViewModel>();
            DataContext = _viewModel;
        }
    }
}
