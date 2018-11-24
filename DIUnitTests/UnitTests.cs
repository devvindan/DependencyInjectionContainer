using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIContainer;
using DIUnitTests.ToyClasses;

namespace DIUnitTests
{
    [TestClass]
    public class UnitTests
    {


        [TestInitialize]
        public void InitializeTest()
        {

        }

        // Checks that TDependency is a reference type
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestReferenceTypeValidation()
        {
            var dependencies = new DependenciesConfiguration();
            dependencies.Register<int, int>(true);
            var provider = new DependencyProvider(dependencies);
        }

        // Checks that TImplementation must be inherieted/implement TException
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestImplementationInheritenceValidation()
        {
            var dependencies = new DependenciesConfiguration();
            dependencies.Register<String, Boolean>(true);
            var provider = new DependencyProvider(dependencies);
        }

        // Checks that TImplementation is a not abstract class
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestImplementationTypeValidation()
        {
            var dependencies = new DependenciesConfiguration();
            dependencies.Register<TDependency, TAbstractImplementation>(true);
            var provider = new DependencyProvider(dependencies);
        }

        // Checks that the same TImplementations are not registered twice
        [TestMethod]
        public void TestDuplicateImplementations()
        {
            var dependencies = new DependenciesConfiguration();
            dependencies.Register<TDependency, TImplementation>(true);
            dependencies.Register<TDependency, TImplementation>(true);
            var provider = new DependencyProvider(dependencies);          

            Assert.AreEqual(dependencies.dependenciesContainer[typeof(TDependency)].Count, 1);
        }

        // Check for attempts to get unregistered dependencies.
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void TestUnregisteredDependencies()
        {
            var dependencies = new DependenciesConfiguration();
            var provider = new DependencyProvider(dependencies);
            var obj = provider.Resolve<TDependency>();
        }


        // Checks for attemts to resolve TDependency with multiple registered implementations the wrong way
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestResolvingMultipleDependenciesTheWrongWay()
        {
            var dependencies = new DependenciesConfiguration();
            dependencies.Register<TDependency, TImplementation>(true);
            dependencies.Register<TDependency, TComplexImplementation>(true);
            var provider = new DependencyProvider(dependencies);
            // Had to be resolved like IEnumerable<TDependency>
            var obj = provider.Resolve<TDependency>();
        }

        // Simple check for resolving basic dependency.
        [TestMethod]
        public void TestResolvingBasicDependency()
        {
            var dependencies = new DependenciesConfiguration();
            dependencies.Register<TDependency, TImplementation>(true);
            var provider = new DependencyProvider(dependencies);
            var obj = provider.Resolve<TDependency>();
            Assert.IsInstanceOfType(obj, typeof(TImplementation));
        }

        [TestMethod]
        public void TestRecursiveDependencies()
        {
            
        }

        [TestMethod]
        public void TestSingletonDependencies()
        {
            // must be multithreading-protected

        }

        [TestMethod]
        public void TestMultipleImplementations()
        {
            
        }

        [TestMethod]
        public void TestGenericDependencies()
        {

        }

    }
}
