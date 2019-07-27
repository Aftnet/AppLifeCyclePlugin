using System;

namespace Plugin.AppLifeCycle
{
    internal partial class AppLifeCycle : AppLifeCycleBase
    {
        public AppLifeCycle()
        {
            Active = true;
            AppDomain.CurrentDomain.ProcessExit += (d, e) =>
            {
                Active = false;
                Suspended = true;
            };
        }
    }
}
