using Moq;
using NUnit.Framework;

namespace SpecsUnit.Tests
{
    public class WhenTestingBehaviour : Spec<TestObject>
    {
        private const string Message = "Test Message";
        private string _result;

        protected override void Given()
        {
            base.Given();
            GetMock<ITestDependency>()
                .Setup(x => x.GetString())
                .Returns(Message);
        }

        protected override void When()
        {
            base.Given();
            _result = SUT.GetString();
        }

        [Test]
        public void Then_expected_dependent_method_is_invoked() =>
            GetMock<ITestDependency>().Verify(x => x.GetString(), Times.Once);

        [Test]
        public void Then_expected_result_is_returned() =>
            Assert.AreEqual(_result, Message);
    }
}