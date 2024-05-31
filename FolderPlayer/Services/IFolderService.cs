using System.Collections.ObjectModel;
using FolderPlayer.Model;

namespace FolderPlayer.Services
{
    public interface IFolderService
    {
        void AddFolder(Folder folder);

        ObservableCollection<Folder> GetFolders();


    }
}
