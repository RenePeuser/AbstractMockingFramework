using CustomMockingFramework.Common;
using Rhino.Mocks.Interfaces;

namespace CustomMockingFramework.Providers.RhinoMock
{
    internal class RhinoMockSetupResult<T> : SetupResult<IMethodOptions<T>>
    {
        public RhinoMockSetupResult(IMethodOptions<T> result)
            : base(result, MockingFrameworkType.RhinoMock)
        {
        }
    }
}
