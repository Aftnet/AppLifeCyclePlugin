using TestApp.Shared;

namespace TestApp.NetCore
{
    class Program
    {
        private static LifeCycleResponder Responder { get; } = LifeCycleResponder.Instance;

        static Program()
        {
        }

        public static void Main()
        {

        }
    }
}
