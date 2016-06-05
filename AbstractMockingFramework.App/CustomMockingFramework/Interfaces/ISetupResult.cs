namespace CustomMockingFramework.Interfaces
{
    public interface ISetupResult<out T> : ISetupResultBase
    {
        T Result { get; }
    }
}
