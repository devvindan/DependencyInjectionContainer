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

        // Simple check for resolving basic implementation.
        [TestMethod]
        public void TestResolvingBasicImplementation()
        {
            var dependencies = new DependenciesConfiguration();
            dependencies.Register<TDependency, TImplementation>(true);
            var provider = new DependencyProvider(dependencies);
            var obj = provider.Resolve<TDependency>();
            Assert.IsInstanceOfType(obj[0], typeof(TImplementation));
        }

        // Checks for for resolving dependencies with multiple implementations
        [TestMethod]
        public void TestResolvingMultipleImplementations()
        {
            var dependencies = new DependenciesConfiguration();
            dependencies.Register<TDependency, TImplementation>(true);
            dependencies.Register<TDependency, TComplexImplementation>(true);
            var provider = new DependencyProvider(dependencies);
            var resolved = provider.Resolve<TDependency>();
            Assert.AreEqual(resolved.Count, 2);

            Type[] actual = new Type[] { resolved[0].GetType(), resolved[1].GetType() };
            Type[] expected = new Type[] { typeof(TComplexImplementation), typeof(TImplementation) };

            CollectionAssert.AreEquivalent(actual, expected);
        }

        // Check for resolving dependencies that can't be created.
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestResolvingUncreatableDependencies()
        {
            var dependencies = new DependenciesConfiguration();
            dependencies.Register<TDependency, TPrivateImplementation>(true);
            var provider = new DependencyProvider(dependencies);
            var obj = provider.Resolve<TDependency>();
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
