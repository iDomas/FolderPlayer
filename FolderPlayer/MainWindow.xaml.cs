using System.Windows;
using FolderPlayer.Services.Persistence;


namespace FolderPlayer
{
    public partial class MainWindow : Window
    {
        private readonly IDataPersistence _dataPersistence;

        public MainWindow(IDataPersistence dataPersistence)
        {
            InitializeComponent();
            _dataPersistence = dataPersistence;
            Closing += Dispose;
        }

        public void Dispose(object? sender, EventArgs e)
        {
            _dataPersistence.WriteData();
        }
    }
}