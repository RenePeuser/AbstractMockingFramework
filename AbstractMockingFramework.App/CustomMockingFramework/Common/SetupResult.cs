using CustomMockingFramework.Interfaces;

namespace CustomMockingFramework.Common
{
    internal class SetupResult<T> : ISetupResult<T>
    {
        public SetupResult(T result, MockingFrameworkType mockingFrameworkType)
        {
            MockingFrameworkType = mockingFrameworkType;
            Result = result;
        }

        public MockingFrameworkType MockingFrameworkType { get; }

        public T Result { get; }
    }
}
