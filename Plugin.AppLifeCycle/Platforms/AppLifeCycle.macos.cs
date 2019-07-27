namespace Plugin.AppLifeCycle
{
    internal class AppLifeCycle : AppLifeCycleBase
    {
        public AppLifeCycle()
        {
            AppKit.NSApplication.Notifications.ObserveDidBecomeActive((d, e) =>
            {
                Active = true;
            });
            AppKit.NSApplication.Notifications.ObserveWillResignActive((d, e) =>
            {
                Active = false;
            });

            AppKit.NSApplication.Notifications.ObserveDidFinishLaunching((d, e) =>
            {
                Suspended = false;
            });
            AppKit.NSApplication.Notifications.ObserveWillTerminate((d, e) =>
            {
                Suspended = true;
            });
        }
    }
}
