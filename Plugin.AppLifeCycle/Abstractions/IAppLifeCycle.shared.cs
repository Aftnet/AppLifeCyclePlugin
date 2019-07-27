using System;
using System.Threading.Tasks;

namespace Plugin.AppLifeCycle.Abstractions
{
    public interface IAppLifeCycle
    {
        event EventHandler Activating;
        event EventHandler Deactivating;
        event EventHandler Resuming;
        event EventHandler Suspending;
        event EventHandler<bool> ExtendedExecutionAllowedChanged;

        bool Active { get; }
        bool Suspended { get; }
        bool ExtendedExecutionAllowed { get; }
        Task<bool> RequestExtendedExecutionAsync();
        Task RelinquishExtendedExecution();
    }
}
