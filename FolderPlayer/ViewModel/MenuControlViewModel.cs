using System.Collections.ObjectModel;
using System.IO;
using FolderPlayer.Command;
using FolderPlayer.Model;
using Microsoft.Win32;

namespace FolderPlayer.ViewModel
{
    public class MenuControlViewModel : IDisposable
    {
        private OpenFolderDialog _dialog;

        public MenuControlViewModel()
        {
            AddFolderCommand = new DelegateCommand<Folder>((x) => AddFolder());
        }

        public ObservableCollection<Folder> Folders { get; } = new();
        public DelegateCommand<Folder> AddFolderCommand { get; set; }

        public async Task LoadFolders()
        {

        }

        private void AddFolder()
        {
            _dialog = new OpenFolderDialog
            {
                Title = "Select a folder with music",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic),
                Multiselect = true
            };

            if (_dialog.ShowDialog() == true)
            {
                Folders.Add(new Folder
                {
                    Name = Path.GetFileName(_dialog.FolderName),
                    Path = _dialog.FolderName
                });
            }
        }

        public void Dispose()
        {
        
        }

    }
}
