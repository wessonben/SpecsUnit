using Microsoft.Extensions.DependencyModel;

namespace SpecsUnit.Tests
{
    public interface ITestDependency
    {
        string GetString();
    }

    public interface ITestDependency2
    {
        int GetNumber();
    }


    public class TestObjectNoDependencies
    {
        public int Value { get; private set; }

        public TestObjectNoDependencies()
        {
            Value = 101;
        }
    }

    public class TestObjectOneDependency
    {
        public ITestDependency Dependency { get; }

        public TestObjectOneDependency(ITestDependency dependency)
        {
            Dependency = dependency;
        }

        public string GetString() => Dependency.GetString();
    }

    public class TestObjectTwoDependencies
    {
        private readonly ITestDependency _dependency1;
        private readonly ITestDependency2 _dependency2;
        
        public TestObjectTwoDependencies(ITestDependency dependency, ITestDependency2 dependency2)
        {
            _dependency1 = dependency;
            _dependency2 = dependency2;
        }

        public void TestMethod()
        {
            _dependency1.GetString();
            _dependency2.GetNumber();
        }
    }
}