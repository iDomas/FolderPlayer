using System.IO;
using System.Text.Json;
using FolderPlayer.Model;

namespace FolderPlayer.Services.Persistence
{
    public class DataPersistence : IDataPersistence
    {
        private readonly string _storagePath;
        private readonly PersistenceData _data;

        public DataPersistence()
        {
            _storagePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "storage.json");
            _data = ReadData();
        }

        public PersistenceData GetData()
        {
            return _data;
        }

        public void WriteData()
        {
            _data.Folders.ToList().ForEach(folder => folder.IsNew = false);
            var json = JsonSerializer.Serialize(_data);
            File.WriteAllText(_storagePath, json);
        }

        public void PassFolderToPersistence(Folder folder)
        {
            _data.Folders.Add(folder);
        }

        private PersistenceData ReadData()
        {
            if (!File.Exists(_storagePath)) return new PersistenceData();
            var json = File.ReadAllText(_storagePath);
            var data = JsonSerializer.Deserialize<PersistenceData>(json) ?? new PersistenceData(); 
            return data;
        }
    }
}
