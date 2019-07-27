namespace Plugin.AppLifeCycle
{
    internal class AppLifeCycle : AppLifeCycleBase
    {
        public AppLifeCycle()
        {
            UIKit.UIApplication.Notifications.ObserveDidBecomeActive((d, e) =>
            {
                Active = true;
            });
            UIKit.UIApplication.Notifications.ObserveWillResignActive((d, e) =>
            {
                Active = false;
            });

            UIKit.UIApplication.Notifications.ObserveWillEnterForeground((d, e) =>
            {
                Suspended = false;
            });
            UIKit.UIApplication.Notifications.ObserveDidEnterBackground((d, e) =>
            {
                Suspended = true;
            });
        }
    }
}
