using Moq;
using NUnit.Framework;

namespace SpecsUnit.Tests
{
    public class WhenSettingUpDependentMethodCalls : Spec<TestObjectOneDependency>
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
        public void Then_dependent_method_is_invoked() =>
            GetMock<ITestDependency>().Verify(x => x.GetString(), Times.Once);

        [Test]
        public void Then_expected_result_is_returned() =>
            Assert.AreEqual(_result, Message);
    }


    public class WhenVerifyingDependentMethodCalls : Spec<TestObjectTwoDependencies>
    {
        protected override void When()
        {
            base.Given();
            SUT.TestMethod();
        }

        [Test]
        public void Then_first_dependent_method_is_invoked() =>
            GetMock<ITestDependency>().Verify(x => x.GetString(), Times.Once);

        [Test]
        public void Then_second_dependent_method_is_invoked() =>
            GetMock<ITestDependency2>().Verify(x => x.GetNumber(), Times.Once);
    }

}