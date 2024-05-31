using System.Collections.ObjectModel;
using FolderPlayer.Model;
using FolderPlayer.Services;

namespace FolderPlayer.ViewModel
{
    public class PlaylistControlViewModel
    {
        private readonly IFolderService _folderService;
        private readonly IMusicFileService _musicFileService;


        public PlaylistControlViewModel(IFolderService folderService, IMusicFileService musicFileService)
        {
            _folderService = folderService;
            _musicFileService = musicFileService;
            Folders = _folderService.GetFolders();
        }

        public ObservableCollection<Folder> Folders { get; }

        public Folder? SelectedFolder { get; set; }

        public void LoadMusicFiles(string path)
        {
            _musicFileService.LoadMusicFiles(path);
        }
    }
}
