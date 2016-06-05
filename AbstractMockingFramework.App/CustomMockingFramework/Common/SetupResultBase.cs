using CustomMockingFramework.Interfaces;

namespace CustomMockingFramework.Common
{
    internal class SetupResultBase : ISetupResultBase
    {
        public SetupResultBase(MockingFrameworkType mockingFrameworkType)
        {
            MockingFrameworkType = mockingFrameworkType;
        }

        public MockingFrameworkType MockingFrameworkType { get; }
    }
}
