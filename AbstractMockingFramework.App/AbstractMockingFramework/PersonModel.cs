using System;

namespace AbstractMockingFramework
{
    public class PersonModel : IPersonModel
    {
        private int _normalProperty;

        public PersonModel(string id)
        {
            Id = id;
        }

        public string Id { get; }

        public int NormalProperty
        {
            get { return _normalProperty; }
            set
            {
                if (_normalProperty != value)
                {
                    _normalProperty = value;
                    SomethingChanged?.Invoke(this, null);
                }
            }
        }

        public int Calculate()
        {
            throw new NotImplementedException();
        }

        public void DoSomething()
        {
        }

        public void ChangeProperty(string propertyName)
        {
        }

        public event EventHandler SomethingChanged;
    }

    public interface IPersonModel
    {
        string Id { get; }

        int NormalProperty { get; set; }

        int Calculate();

        void DoSomething();

        void ChangeProperty(string proeprtyName);

        event EventHandler SomethingChanged;
    }
}
