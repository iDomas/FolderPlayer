using System.ComponentModel;
using System.Runtime.CompilerServices;
using FolderPlayer.Command;
using FolderPlayer.Services;

namespace FolderPlayer.ViewModel
{
    public class PlayerControlViewModel : INotifyPropertyChanged
    {
        private readonly IPlayerService _playerService;
        private bool _isPlaying;

        public PlayerControlViewModel(IPlayerService playerService)
        {
            _playerService = playerService;
            _playerService.IsPlayingEvent += IsPlayingEvent;
            TogglePlayPauseCommand = new DelegateCommand((x) => PlayPause());
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public DelegateCommand TogglePlayPauseCommand { get; set; }

        public void Play() => _playerService.Play();

        public void Pause() => _playerService.Pause();

        public bool IsPlaying
        {
            get => _isPlaying;
            set
            {
                _isPlaying = value;
                OnPropertyChanged();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void IsPlayingEvent(object? sender, bool isPlaying)
        {
            IsPlaying = isPlaying;
        }

        private void PlayPause()
        {
            if (_isPlaying)
            {
                Pause();
            }
            else
            {
                Play();
            }
        }
    }
}
