using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using FolderPlayer.Services;

namespace FolderPlayer.ViewModel
{
    public class ProgressBarControlViewModel : INotifyPropertyChanged
    {
        private readonly IPlayerService _playerService;
        private double _progress;

        public ProgressBarControlViewModel(IPlayerService playerService)
        {
            _playerService = playerService;
            _playerService.ProgressEvent += EventProgressChanged;
        }

        public double Progress
        {
            get => _progress;
            set
            {
                _progress = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void EventProgressChanged(object? sender, double progress)
        {
            Progress = progress;
        }

    }
}
