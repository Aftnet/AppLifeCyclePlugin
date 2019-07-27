using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.ExtendedExecution;
using Windows.UI.Xaml;

namespace Plugin.AppLifeCycle
{
    internal class AppLifeCycle : AppLifeCycleBase
    {
        private ExtendedExecutionSession Session { get; set; } = null;

        public AppLifeCycle()
        {
            var app = Application.Current;
            var window = Window.Current;
            window.Activated += (d, e) =>
            {
                if (e.WindowActivationState == Windows.UI.Core.CoreWindowActivationState.Deactivated)
                {
                    Active = false;
                }
                else
                {
                    Active = true;
                }
            };

            app.Resuming += (d, e) =>
            {
                Suspended = false;
            };
            app.Suspending += (d, e) =>
            {
                Suspended = true;
            };
        }

        public override async Task<bool> RequestExtendedExecutionAsync()
        {
            if (ExtendedExecutionAllowed)
            {
                return true;
            }

            Dispose();
            Session = new ExtendedExecutionSession()
            {
                Reason = ExtendedExecutionReason.Unspecified
            };
            Session.Revoked += SessionRevoked;
            var result = await Session.RequestExtensionAsync();

            ExtendedExecutionAllowed = result == ExtendedExecutionResult.Allowed;
            if (!ExtendedExecutionAllowed)
            {
                Dispose();
            }

            return ExtendedExecutionAllowed;
        }

        public override Task RelinquishExtendedExecution()
        {
            ExtendedExecutionAllowed = false;
            if (Session == null)
            {
                return Task.CompletedTask;
            }

            Dispose();

            return Task.CompletedTask;
        }

        private void Dispose()
        {
            if (Session != null)
            {
                Session.Revoked -= SessionRevoked;
                Session.Dispose();
            }

            Session = null;
        }

        private void SessionRevoked(object sender, ExtendedExecutionRevokedEventArgs args)
        {
            ExtendedExecutionAllowed = false;
        }
    }
}
