using System.Collections.ObjectModel;
using System.IO;
using FolderPlayer.Command;
using FolderPlayer.Model;
using FolderPlayer.Services;
using Microsoft.Win32;

namespace FolderPlayer.ViewModel
{
    public class MenuControlViewModel : IDisposable
    {
        private OpenFolderDialog _dialog;
        private readonly IFolderService _folderService;

        public MenuControlViewModel(IFolderService folderService)
        {
            AddFolderCommand = new DelegateCommand<Folder>((x) => AddFolder());
            _folderService = folderService;
            Folders = _folderService.GetFolders();
        }

        public ObservableCollection<Folder> Folders;
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
                var folder = new Folder
                {
                    Name = Path.GetFileName(_dialog.FolderName),
                    Path = _dialog.FolderName
                };
                _folderService.AddFolder(folder);
            }
        }

        public void Dispose()
        {
        
        }

    }
}
