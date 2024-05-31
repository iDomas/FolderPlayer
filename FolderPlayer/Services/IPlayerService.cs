namespace FolderPlayer.Services
{
    public interface IPlayerService
    {
        event EventHandler<bool> IsPlayingEvent;
        event EventHandler<double> ProgressEvent;

        void Play();

        void Pause();

        void Stop();

    }
}
