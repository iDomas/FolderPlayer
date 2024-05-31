using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderPlayer.Services
{
    public interface IPlayerService
    {
        event EventHandler<bool> IsPlayingEvent;

        void Play();

        void Pause();

        void Stop();

    }
}
