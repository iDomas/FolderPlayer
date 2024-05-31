using System.Collections.ObjectModel;
using FolderPlayer.Model;

namespace FolderPlayer.Services
{
    public interface IMusicFileService
    {
        ObservableCollection<MusicFile> GetMusicFiles();
        void LoadMusicFiles(string path);

        void SelectMusicFile(MusicFile? file);

        MusicFile? GetSelectedMusicFile();
    }
}
