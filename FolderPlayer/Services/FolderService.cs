using FolderPlayer.Model;
using System.Collections.ObjectModel;

namespace FolderPlayer.Services
{

    public class FolderService : IFolderService
    {
        private ObservableCollection<Folder> Folders { get; } = new();

        public void AddFolder(Folder folder)
        {
            Folders.Add(folder);
        }

        public ObservableCollection<Folder> GetFolders()
        {
            return Folders;
        }
    }
}
