using CustomMockingFramework.Interfaces;
using CustomMockingFramework.Providers.RhinoMock;

namespace CustomMockingFramework
{
    public class MockingFramework
    {
        internal static readonly IMockingFrameworkProvider ActiveMockingFrameworkProvider = new RhinoMockProvider();

        public static T Create<T>(params object[] argumentsForConstructor) where T : class
        {
            return ActiveMockingFrameworkProvider.CreateMock<T>();
        }
    }
}
