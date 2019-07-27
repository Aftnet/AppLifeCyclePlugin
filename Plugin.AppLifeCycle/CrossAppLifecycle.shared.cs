using Plugin.AppLifeCycle.Abstractions;
using System;
using System.Threading;

namespace Plugin.AppLifeCycle
{
    public static class CrossAppLifecycle
    {
#if !NETSTANDARD1_4
        private static Lazy<AppLifeCycle> appLifeCycle = new Lazy<AppLifeCycle>(() => new AppLifeCycle(), LazyThreadSafetyMode.ExecutionAndPublication);
#endif

        public static bool Supported
        {
            get
            {
#if NETSTANDARD1_4
                return false;
#else
                return true;
#endif
            }
        }

        public static IAppLifeCycle Current
        {
            get
            {
#if NETSTANDARD1_4
                throw new NotImplementedException();
#else
                return appLifeCycle.Value;
#endif
            }
        }
    }
}