using System;
using CustomMockingFramework.Interfaces;
using Rhino.Mocks;

namespace CustomMockingFramework.Providers.RhinoMock
{
    public class RhinoMockProvider : IMockingFrameworkProvider
    {
        public T CreateMock<T>(params object[] argumentsForConstructor) where T : class
        {
            return MockRepository.GenerateMock<T>(argumentsForConstructor);
        }

        public ISetupResultBase CreateSetup<T, R>(T mock, Func<T, R> func) where T : class
        {
            return new RhinoMockSetupResult<R>(mock.Stub(_ => func.Invoke(mock)));
        }

        public void SetupReturn<TValue>(ISetupResultBase mock, TValue value)
        {
            var rhinoMockSetupResult = (RhinoMockSetupResult<TValue>)mock;
            rhinoMockSetupResult.Result.Return(value);
        }

        public void AssertWasCalled<T>(T mock, Action<T> action, int expectedCallCount = 1) where T : class
        {
            mock.AssertWasCalled(action, option => option.Repeat.Times(expectedCallCount));
        }

        public void AssertEventWasRaised<T, R>(T mock, Func<T, R> action, int expectedCallCount = 1) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
