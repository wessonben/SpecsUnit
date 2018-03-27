using Moq;
using NUnit.Framework;

namespace SpecsUnit.Tests
{
    public class WhenTestingObjectWithNoDependencies : Spec<TestObjectNoDependencies>
    {
        [Test]
        public void Then_sut_is_initialised() =>
            Assert.IsNotNull(SUT);

        [Test]
        public void Then_sut_is_expected_type() =>
            Assert.IsInstanceOf<TestObjectNoDependencies>(SUT);

        [Test]
        public void Then_sut_test_property_is_initialised() =>
            Assert.AreEqual(SUT.Value, 101);
    }

    public class WhenTestingObjectWithOneDependency : Spec<TestObjectOneDependency>
    {
        [Test]
        public void Then_sut_is_initialised() => 
            Assert.IsNotNull(SUT);

        [Test]
        public void Then_sut_is_expected_type() => 
            Assert.IsInstanceOf<TestObjectOneDependency>(SUT);

        [Test]
        public void Then_mock_dependency_can_be_returned() =>
            Assert.IsInstanceOf<Mock<ITestDependency>>(GetMock<ITestDependency>());
    }

    public class WhenTestingObjectWithTwoDependencies : Spec<TestObjectTwoDependencies>
    {
        [Test]
        public void Then_sut_is_initialised() =>
            Assert.IsNotNull(SUT);

        [Test]
        public void Then_sut_is_expected_type() =>
            Assert.IsInstanceOf<TestObjectTwoDependencies>(SUT);

        [Test]
        public void Then_first_mock_dependency_can_be_returned() =>
            Assert.IsInstanceOf<Mock<ITestDependency>>(GetMock<ITestDependency>());

        [Test]
        public void Then_second_mock_dependency_can_be_returned() =>
            Assert.IsInstanceOf<Mock<ITestDependency2>>(GetMock<ITestDependency2>());
    }
}