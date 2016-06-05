using System;
using CustomMockingFramework.Interfaces;
using NSubstitute;

namespace CustomMockingFramework.Providers.NSubstitute
{
    internal class NSubstituteProvider : IMockingFrameworkProvider
    {
        public T CreateMock<T>(params object[] argumentsForConstructor) where T : class
        {
            return Substitute.For<T>(argumentsForConstructor);
        }

        public ISetupResultBase CreateSetup<T, R>(T mock, Func<T, R> func) where T : class
        {
            return new NSubstituteSetupResult<R>(func.Invoke(mock));
        }

        public void SetupReturn<TValue>(ISetupResultBase mock, TValue value)
        {
            var nsubstituteSetupResult = (NSubstituteSetupResult<TValue>)mock;
            nsubstituteSetupResult.Result.Returns(value);
        }

        public void AssertWasCalled<T>(T mock, Action<T> action, int expectedCallCount = 1) where T : class
        {
            mock.Received(expectedCallCount);
            action.Invoke(mock);
        }

        public void AssertEventWasRaised<T, R>(T mock, Func<T, R> action, int expectedCallCount = 1) where T : class
        {
            

        }
    }
}
