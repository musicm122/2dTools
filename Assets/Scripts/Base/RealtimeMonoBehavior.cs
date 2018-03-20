using System;
using UnityEngine;

namespace AssemblyCSharp.Assets.Scripts.Base
{
    public abstract class RealtimeMonoBehavior : MonoBehaviour
    {
        private double lastInterval;
        public float updateInterval = 0.5F;


        private void Start()
        {
            DefaultIntervalStart();
            lastInterval = Time.realtimeSinceStartup;
            RealtimeIntervalStart();
        }

        private void Update()
        {
            DefaultIntervalUpdate();
            float timeNow = Time.realtimeSinceStartup;
            if (timeNow > lastInterval + updateInterval)
            {
                lastInterval = timeNow;
                RealtimeIntervalUpdate();
            }
        }

        public virtual void DefaultIntervalUpdate()
        {
            //this.Print("DefaultIntervalUpdate Called");
        }

        public virtual void DefaultIntervalStart()
        {
            //this.Print("DefaultIntervalStart Called");
        }

        public virtual void RealtimeIntervalStart()
        {
            //this.Print("RealtimeIntervalStart Called");
        }

        public virtual void RealtimeIntervalUpdate()
        {
            //this.Print("RealtimeIntervalUpdate Called");
        }
    }
}
