using System;
using Scripts.Importer.Parts;
using UnityEngine;
using Constants;
using AssemblyCSharp.Assets.Scripts.VisualEditorMenu;

namespace AssemblyCSharp.Assets.Scripts
{

    public class GameState : MonoBehaviour, IPausePublisher
    {

        public event EventHandler<PauseEventArgs> RaisePauseEvent;
        public event EventHandler<PauseEventArgs> RaiseUnpauseEvent;
        public event EventHandler<PauseEventArgs> RaisePauseStateChanged;

        public bool IsPaused;

        [SerializeField]
        private Movable Movable;

        [SerializeField]
        private Jumpable Jumpable;

        public void TogglePause()
        {
            IsPaused = !IsPaused;
            RaiseEvents(IsPaused);
        }

        public void SetPauseState(bool isPaused)
        {
            IsPaused = isPaused;
            RaiseEvents(isPaused);
        }

        void RaiseEvents(bool isPausedState)
        {
            if (isPausedState)
            {
                OnRaisePauseEvent(new PauseEventArgs(isPausedState));
            }
            else
            {
                OnRaiseUnpauseEvent(new PauseEventArgs(isPausedState));
            }
            OnRaisePauseStateChanged(new PauseEventArgs(isPausedState));
        }

        public virtual void OnRaisePauseEvent(PauseEventArgs eventArgs)
        {
            var handler = RaisePauseEvent;
            if (handler != null)
            {
                eventArgs.IsPaused = this.IsPaused;
                handler(this, eventArgs);
            }
        }

        public virtual void OnRaiseUnpauseEvent(PauseEventArgs eventArgs)
        {
            var handler = RaiseUnpauseEvent;
            if (handler != null)
            {
                eventArgs.IsPaused = this.IsPaused;
                handler(this, eventArgs);
            }
        }

        public virtual void OnRaisePauseStateChanged(PauseEventArgs eventArgs)
        {
            var handler = RaisePauseStateChanged;
            if (handler != null)
            {
                eventArgs.IsPaused = this.IsPaused;
                handler(this, eventArgs);
            }
        }

        public void ResetPartState()
        {
            Movable.RunData.Reset();
            Jumpable.jumpData.Reset();
        }

        private void OnDestroy()
        {
            this.RaisePauseEvent = null;
            this.RaiseUnpauseEvent = null;
            this.RaisePauseStateChanged = null;
        }
    }
}
