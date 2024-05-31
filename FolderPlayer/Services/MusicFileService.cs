using FolderPlayer.Model;
using System.Collections.ObjectModel;
using System.IO;

namespace FolderPlayer.Services
{
    public class MusicFileService : IMusicFileService
    {
        private ObservableCollection<MusicFile> MusicFiles { get; } = new();
        private MusicFile? _selectedMusicFile;

        public ObservableCollection<MusicFile> GetMusicFiles()
        {
            return MusicFiles;
        }

        public void LoadMusicFiles(string path)
        {
            
            var files = Directory.GetFiles(path);
            var filteredMusicFiles = files.Where(FilterMusicFiles);

            if (MusicFiles.Any()) MusicFiles.Clear();
            foreach (var file in filteredMusicFiles)
            {
                MusicFiles.Add(new MusicFile
                {
                    Name = Path.GetFileName(file),
                    Path = file
                });
            }
        }

        public void SelectMusicFile(MusicFile? file)
        {
            _selectedMusicFile = file;
        }

        public MusicFile? GetSelectedMusicFile()
        {
            return _selectedMusicFile;
        }

        private static bool FilterMusicFiles(string file)
        {
            var filter = new []
            {
                ".mp3",
                ".wav",
                ".ogg",
                ".flac",
                ".wma",
                ".m4a",
            };

            return filter.Contains(Path.GetExtension(file));
        }
    }
}
