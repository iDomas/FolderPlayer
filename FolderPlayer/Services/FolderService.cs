using FolderPlayer.Model;
using System.Collections.ObjectModel;
using FolderPlayer.Services.Persistence;

namespace FolderPlayer.Services
{

    public class FolderService : IFolderService
    {
        private readonly IDataPersistence _dataPersistence;
        private ObservableCollection<Folder> Folders { get; } = new();

        public FolderService(IDataPersistence dataPersistence)
        {
            _dataPersistence = dataPersistence;
            LoadFoldersFromStorage();
        }

        public void AddFolder(Folder folder)
        {
            Folders.Add(folder);
            if (folder.IsNew) _dataPersistence.PassFolderToPersistence(folder);
        }

        public ObservableCollection<Folder> GetFolders()
        {
            return Folders;
        }

        private void LoadFoldersFromStorage()
        {
            foreach (var folder in _dataPersistence.GetData().Folders)
            { 
                AddFolder(folder);
            }
        }
    }
}
