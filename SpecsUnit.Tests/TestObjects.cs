namespace SpecsUnit.Tests
{
    public interface ITestDependency
    {
        string GetString();
    }

    public class TestObject
    {
        public ITestDependency Dependency { get; }

        public TestObject(ITestDependency dependency)
        {
            Dependency = dependency;
        }

        public string GetString() => Dependency.GetString();
    }
}