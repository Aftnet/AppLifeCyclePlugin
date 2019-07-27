using System;

using AppKit;
using Foundation;
using TestApp.Shared;

namespace TestApp.macOS
{
    public partial class ViewController : NSViewController
    {
        private LifeCycleResponder Responder { get; } = LifeCycleResponder.Instance;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Do any additional setup after loading the view.
        }

        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }
    }
}
