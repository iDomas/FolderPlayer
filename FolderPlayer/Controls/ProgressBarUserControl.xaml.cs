using System.Windows.Controls;
using FolderPlayer.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace FolderPlayer.Controls
{
    public partial class ProgressBarUserControl : UserControl
    {
        private readonly ProgressBarControlViewModel _viewModel;

        public ProgressBarUserControl()
        {
            InitializeComponent();

            _viewModel = App.AppHost!.Services.GetRequiredService<ProgressBarControlViewModel>();
            DataContext = _viewModel;
        }
    }
}
