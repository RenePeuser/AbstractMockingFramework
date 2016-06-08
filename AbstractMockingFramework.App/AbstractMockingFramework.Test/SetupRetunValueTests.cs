using System;
using System.Linq;
using System.Reflection;
using CustomMockingFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AbstractMockingFramework.Test
{
    [TestClass]
    public class SetupRetunValueTests
    {
        private IPersonModel _personModel;

        [TestInitialize]
        public void Init()
        {
            _personModel = MockingFramework.Create<IPersonModel>();
        }

        [TestMethod]
        public void TestSetupReturnProperty()
        {
            _personModel.Setup(item => item.Id).Returns("Test");

            Assert.AreEqual("Test", _personModel.Id);
        }

        [TestMethod]
        public void TestSetupReturnMethod()
        {
            _personModel.Setup(item => item.Calculate()).Returns(888);

            Assert.AreEqual(888, _personModel.Calculate());
        }
    }

    [TestClass]
    public class MethodCallCounter
    {
        private IPersonModel _personModel;

        [TestInitialize]
        public void Init()
        {
            _personModel = MockingFramework.Create<IPersonModel>();
        }

        [TestMethod]
        public void TestMethodWasCalledOnce()
        {
            _personModel.DoSomething();

            _personModel.AssertWasCalled(item => item.DoSomething());
        }

        [TestMethod]
        public void TestMethodWasCalledTwice()
        {
            _personModel.DoSomething();
            _personModel.DoSomething();

            _personModel.AssertWasCalled(item => item.DoSomething(), 2);
        }

        [TestMethod]
        public void TestMethodWasCalledWithExpectedParameters()
        {
            _personModel.ChangeProperty("test");

            _personModel.AssertWasCalled(item => item.ChangeProperty("test"));
        }
    }

    [TestClass]
    public class EventWasRaised
    {
        private IPersonModel _personModel;

        [TestInitialize]
        public void Init()
        {
            _personModel = MockingFramework.Create<IPersonModel>();
        }

        //[TestMethod]
        //public void TestEventWasRaised()

        //{
        //    _personModel.Raise(nameof(_personModel.SomethingChanged), new EventArgs());

        //    _personModel.SomethingChanged += (s, e) => { };
        //}
    }

    public static class EventHandlerExtensions
    {
        internal static void Raise<TMock, TEventArgs>(this TMock mock, string eventName, TEventArgs eventArgs) where TMock : class where TEventArgs : EventArgs
        {
            IPersonModel person = new PersonModel("Id1");
            var eventResult = person.GetType().GetEvent(eventName);

            var members =
                mock.GetType()
                    .GetMembers(BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.Default |
                                BindingFlags.NonPublic | BindingFlags.Public);

            var events =
                mock.GetType()
                    .GetEvents(BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.Default |
                                BindingFlags.NonPublic | BindingFlags.Public);

            MemberInfo eventMember = members.FirstOrDefault(item => item.Name.Contains(eventName));
        }
    }
}

