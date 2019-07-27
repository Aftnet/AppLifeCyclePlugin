using Android.Arch.Lifecycle;
using Java.Interop;
using System;

namespace Plugin.AppLifeCycle
{
    internal class AppLifeCycle : AppLifeCycleBase
    {
        private class AndroidLifeCycleObserver : Java.Lang.Object, ILifecycleObserver
        {
            private AppLifeCycle Container { get; }

            public AndroidLifeCycleObserver(AppLifeCycle container)
            {
                Container = container ?? throw new ArgumentNullException(nameof(container));
            }

            [Lifecycle.Event.OnResume]
            [Export]
            public void Resumed()
            {
                Container.Active = true;
            }

            [Lifecycle.Event.OnPause]
            [Export]
            public void Paused()
            {
                Container.Active = false;
            }

            [Lifecycle.Event.OnStart]
            [Export]
            public void Started()
            {
                Container.Suspended = false;
            }

            [Lifecycle.Event.OnStop]
            [Export]
            public void Stopped()
            {
                Container.Suspended = true;
            }
        }

        private AndroidLifeCycleObserver Observer { get; }
        public AppLifeCycle()
        {
            Observer = new AndroidLifeCycleObserver(this);
            ProcessLifecycleOwner.Get().Lifecycle.AddObserver(Observer);
        }
    }
}
