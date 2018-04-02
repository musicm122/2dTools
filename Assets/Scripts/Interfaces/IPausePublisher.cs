using System;
using AssemblyCSharp.Assets.Scripts.VisualEditorMenu;

namespace AssemblyCSharp.Assets.Scripts
{
    public interface IPausePublisher
    {
        event EventHandler<PauseEventArgs> RaisePauseEvent;
        event EventHandler<PauseEventArgs> RaiseUnpauseEvent;
        event EventHandler<PauseEventArgs> RaisePauseStateChanged;

        void OnRaisePauseEvent(PauseEventArgs eventArgs);
        void OnRaisePauseStateChanged(PauseEventArgs eventArgs);
        void OnRaiseUnpauseEvent(PauseEventArgs eventArgs);
        void TogglePause();
    }
}