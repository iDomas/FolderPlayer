namespace FolderPlayer.Model
{
    public class Folder
    {
        public string Path { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
