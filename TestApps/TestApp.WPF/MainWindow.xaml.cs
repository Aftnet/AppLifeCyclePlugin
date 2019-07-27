using System.Windows;
using TestApp.Shared;

namespace TestApp.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private LifeCycleResponder Responder { get; } = LifeCycleResponder.Instance;

        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
