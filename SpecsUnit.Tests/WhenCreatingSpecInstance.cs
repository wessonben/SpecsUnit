using Moq;
using NUnit.Framework;

namespace SpecsUnit.Tests
{
    
    public class WhenCreatingSpecInstance : Spec<TestObject>
    {
        [Test]
        public void Then_sut_is_initialised() => 
            Assert.IsNotNull(SUT);

        [Test]
        public void Then_sut_is_expected_type() => 
            Assert.IsInstanceOf<TestObject>(SUT);

        [Test]
        public void Then_sut_dependency_is_initialised() =>
            Assert.IsNotNull(SUT.Dependency);

        [Test]
        public void Then_mock_dependency_can_be_returned() =>
            Assert.IsInstanceOf<Mock<ITestDependency>>(GetMock<ITestDependency>());
    }
}