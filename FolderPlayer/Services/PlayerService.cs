using System.Diagnostics;
using System.Windows.Threading;
using FolderPlayer.Controls;
using Microsoft.Extensions.Logging;
using NAudio.Wave;

namespace FolderPlayer.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly ILogger<PlayerControl> _logger;
        private AudioFileReader? _audioFile;
        private DispatcherTimer _timer;
        private IWavePlayer _waveOut;
        private readonly IMusicFileService _musicFileService;
        private double _progress { get; set; }

        private bool _isPlaying = false;
        public event EventHandler<bool> IsPlayingEvent;

        public PlayerService(ILogger<PlayerControl> logger, IMusicFileService musicFileService)
        {
            _logger = logger;
            _musicFileService = musicFileService;

            _waveOut = new WaveOutEvent();
            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(500)
            };
            _timer.Tick += Timer_Tick;
        }

        public void Play()
        {
            var musicFile = _musicFileService.GetSelectedMusicFile();
            if (musicFile == null) IsPlayingEvent.Invoke(this, false);
            Play(musicFile.Path);
            IsPlayingEvent.Invoke(this, true);
        }

        public void Pause()
        {
            _waveOut.Pause();
            _timer.Stop();
            IsPlayingEvent.Invoke(this, false);
        }

        public void Stop()
        {
            try
            {
                _waveOut.Stop();
                _audioFile.Position = 0;
                _progress = 0;
                _timer.Stop();
                IsPlayingEvent.Invoke(this, false);
                _audioFile.Dispose();
                _audioFile = null;
            }
            catch
            {
                IsPlayingEvent.Invoke(this,false);
            }
        }

        private void Play(string audioFilePath)
        {
            if (_audioFile == null)
            {
                _audioFile = new AudioFileReader(audioFilePath);
                _waveOut.Init(_audioFile);
            }
            _waveOut.Play();
        }

        private void Timer_Tick(object? sender, EventArgs? e)
        {
            _progress = (_audioFile.CurrentTime.TotalSeconds / _audioFile.TotalTime.TotalSeconds) * 100;
            Debug.WriteLine(_progress);
        }

    }
}
