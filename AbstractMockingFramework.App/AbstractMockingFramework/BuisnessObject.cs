namespace AbstractMockingFramework
{
    public class BuisnessObject
    {
        private readonly IPersonModel _personModel;

        public BuisnessObject(IPersonModel personModel)
        {
            _personModel = personModel;
        }

        public void DoSomething()
        {
            _personModel.DoSomething();
        }

    }
}
