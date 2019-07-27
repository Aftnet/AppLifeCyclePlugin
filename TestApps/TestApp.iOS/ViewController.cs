using Foundation;
using System;
using TestApp.Shared;
using UIKit;

namespace TestApp.iOS
{
    public partial class ViewController : UIViewController
    {
        private LifeCycleResponder Responder { get; } = LifeCycleResponder.Instance;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}