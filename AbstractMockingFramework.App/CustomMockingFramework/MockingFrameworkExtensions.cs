using System;
using CustomMockingFramework.Interfaces;

namespace CustomMockingFramework
{
    public static class MockingFrameworkExtensions
    {
        public static ISetupResultBase Setup<T, R>(this T mock, Func<T, R> func) where T : class
        {
            return MockingFramework.ActiveMockingFrameworkProvider.CreateSetup(mock, func);
        }

        public static void Returns<TValue>(this ISetupResultBase mock, TValue value)
        {
            MockingFramework.ActiveMockingFrameworkProvider.SetupReturn<TValue>(mock, value);
        }

        public static void AssertWasCalled<T>(this T mock, Action<T> action, int expectedCallCount = 1) where T : class
        {
            MockingFramework.ActiveMockingFrameworkProvider.AssertWasCalled(mock, action, expectedCallCount);
        }

        public static void AssertEventWasCalled<T>(this T mock, string eventName) where T : class
        {
            // MockingFramework.ActiveMockingFrameworkProvider.AssertWasCalled(mock, action, expectedCallCount);
        }
    }
}
