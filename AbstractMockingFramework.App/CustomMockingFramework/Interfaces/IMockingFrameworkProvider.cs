using System;

namespace CustomMockingFramework.Interfaces
{
    public interface IMockingFrameworkProvider
    {
        T CreateMock<T>(params object[] argumentsForConstructor) where T : class;

        ISetupResultBase CreateSetup<T, R>(T mock, Func<T, R> func) where T : class;

        void SetupReturn<TValue>(ISetupResultBase mock, TValue value);

        void AssertWasCalled<T>(T mock, Action<T> action, int expectedCallCount = 1) where T : class;

        void AssertEventWasRaised<T, R>(T mock, Func<T, R> action, int expectedCallCount = 1) where T : class;
    }
}
