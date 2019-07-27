using TestApp.Shared;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TestApp.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private LifeCycleResponder Responder { get; } = LifeCycleResponder.Instance;

        public MainPage()
        {
            this.InitializeComponent();
        }
    }
}
