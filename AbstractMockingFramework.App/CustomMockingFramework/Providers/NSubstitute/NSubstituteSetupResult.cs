using CustomMockingFramework.Common;

namespace CustomMockingFramework.Providers.NSubstitute
{
    internal class NSubstituteSetupResult<T> : SetupResult<T>
    {
        public NSubstituteSetupResult(T result)
            : base(result, MockingFrameworkType.NSubstitute)
        {
        }
    }
}
