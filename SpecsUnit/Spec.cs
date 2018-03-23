using Moq;
using Moq.AutoMock;
using NUnit.Framework;

namespace SpecsUnit
{


    public interface ISpec<out T> 
    {
        T SUT { get; }

        Mock<TMock> GetMock<TMock>() where TMock : class;
    }


    [TestFixture]
    public abstract class Spec<T> : ISpec<T> where T : class
    {
        public T SUT { get; private set; }

        private readonly AutoMocker _autoMocker;


        protected Spec()
        {
            _autoMocker = new AutoMocker();
        }


        [OneTimeSetUp]
        public void SetupTests()
        {
            InitialiseSUT();
            Given();
            When();
        }


        public Mock<TMock> GetMock<TMock>() where TMock : class => 
            _autoMocker.GetMock<TMock>();


        protected virtual void InitialiseSUT()
        {
            SUT = _autoMocker.CreateInstance<T>();
        }


        protected virtual void Given()
        {
            
        }

        protected virtual void When()
        {
            
        }




    }
}