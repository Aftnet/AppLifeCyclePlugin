using Plugin.AppLifeCycle.Abstractions;
using System;
using System.Threading.Tasks;

namespace Plugin.AppLifeCycle
{
    internal abstract class AppLifeCycleBase : IAppLifeCycle
    {
        public event EventHandler Activating;
        public event EventHandler Deactivating;
        public event EventHandler Resuming;
        public event EventHandler Suspending;
        public event EventHandler<bool> ExtendedExecutionAllowedChanged;

        private bool active = false;
        public bool Active
        {
            get => active;
            protected set
            {
                if (active != value)
                {
                    active = value;
                    if (active)
                    {
                        Activating?.Invoke(this, EventArgs.Empty);
                    }
                    else
                    {
                        Deactivating?.Invoke(this, EventArgs.Empty);
                    }
                }
            }
        }

        private bool suspended = false;
        public bool Suspended
        {
            get => suspended;
            protected set
            {
                if (suspended != value)
                {
                    suspended = value;
                    if (suspended)
                    {
                        Active = false;
                        Suspending?.Invoke(this, EventArgs.Empty);
                    }
                    else
                    {
                        Resuming?.Invoke(this, EventArgs.Empty);
                    }
                }
            }
        }

        private bool extendedExecutionAllowed = false;
        public bool ExtendedExecutionAllowed
        {
            get => extendedExecutionAllowed;
            protected set
            {
                if (extendedExecutionAllowed != value)
                {
                    extendedExecutionAllowed = value;
                    ExtendedExecutionAllowedChanged?.Invoke(this, value);
                }
            }
        }

        public virtual Task<bool> RequestExtendedExecutionAsync()
        {
            return Task.FromResult(false);
        }

        public virtual Task RelinquishExtendedExecution()
        {
            return Task.CompletedTask;
        }

        public override string ToString()
        {
            return $"App LifeCycle: Active={Active}, Suspended={Suspended}";
        }
    }
}
