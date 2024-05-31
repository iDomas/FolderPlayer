using FolderPlayer.Model;

namespace FolderPlayer.Services.Persistence
{
    public interface IDataPersistence
    {
        PersistenceData GetData();
        void WriteData();

        void PassFolderToPersistence(Folder folder);
    }
}
