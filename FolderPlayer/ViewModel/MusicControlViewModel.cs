#nullable enable
using System.Collections.ObjectModel;
using System.IO;
using FolderPlayer.Model;

namespace FolderPlayer.ViewModel
{
    public class MusicControlViewModel
    {
        public ObservableCollection<MusicFile> MusicFiles { get; } = new();
        
        public MusicFile? SelectedMusicFile { get; set; }
        
        public MusicControlViewModel()
        {
            
        }

        public async Task LoadMusicFiles()
        {
            const string directory = "E:\\Music\\2024\\rockish";
            var files = Directory.GetFiles(directory);
            
            foreach (var file in files)
            {
                MusicFiles.Add(new MusicFile
                {
                    Name = Path.GetFileName(file),
                    Path = file
                });
            }
        }
    }
}