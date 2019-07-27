using Plugin.AppLifeCycle.Abstractions;
using System;
using System.Diagnostics;

namespace TestApp.Shared
{
    public class LifeCycleResponder
    {
        private static readonly Lazy<LifeCycleResponder> instance;
        public static LifeCycleResponder Instance => instance.Value;

        private IAppLifeCycle LifeCycle { get; }

        static LifeCycleResponder()
        {
            instance = new Lazy<LifeCycleResponder>(() => new LifeCycleResponder(Plugin.AppLifeCycle.CrossAppLifecycle.Current), System.Threading.LazyThreadSafetyMode.ExecutionAndPublication);
        }

        private LifeCycleResponder(IAppLifeCycle lifeCycle)
        {
            LifeCycle = lifeCycle ?? throw new ArgumentNullException();

            LifeCycle.Activating += (d,e)=> { Trace.WriteLine($"App activating. {LifeCycle}"); };
            LifeCycle.Deactivating += (d, e) => { Trace.WriteLine($"App deactivating. {LifeCycle}"); };
            LifeCycle.Resuming += (d, e) => { Trace.WriteLine($"App resuming. {LifeCycle}"); };
            LifeCycle.Suspending += (d, e) => { Trace.WriteLine($"App suspending. {LifeCycle}"); };
        }
    }
}
