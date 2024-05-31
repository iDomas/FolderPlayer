#nullable enable
using System.Collections.ObjectModel;
using System.IO;
using FolderPlayer.Model;
using FolderPlayer.Services;

namespace FolderPlayer.ViewModel
{
    public class MusicControlViewModel
    {
        private readonly IMusicFileService _musicFileService;
        private readonly IPlayerService _playerService;


        public MusicControlViewModel(IPlayerService playerService, IMusicFileService musicFileService)
        {
            _musicFileService = musicFileService;
            _playerService = playerService;
            MusicFiles = _musicFileService.GetMusicFiles();
        }

        public ObservableCollection<MusicFile> MusicFiles { get; }

        public MusicFile? SelectedMusicFile
        {
            get { return _musicFileService.GetSelectedMusicFile(); }
            set
            {
                _musicFileService.SelectMusicFile(value);
                if (value == null) return;
                _playerService.Play();
            }
        }
    }
}