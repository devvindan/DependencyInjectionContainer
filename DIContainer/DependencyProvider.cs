using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace DIContainer
{
    public class DependencyProvider
    {

        DependenciesConfiguration configuration;

        public DependencyProvider(DependenciesConfiguration configuration)
        {
            validateConfiguration(configuration);
            this.configuration = configuration;         
        }

        public void validateConfiguration(DependenciesConfiguration configuration)
        {
            // Iterate over registered dependencies
            foreach (Type tDependency in configuration.dependenciesContainer.Keys)
            {
                // Checks if TDependency is a reference type
                if (tDependency.IsValueType)
                {
                    throw new ArgumentException("TDependency must be a reference type");
                }

                // Iterate over registred dependency implementations
                foreach (Type tImplementation in configuration.dependenciesContainer[tDependency])
                {
                    // Checks if TImplementation inherits from/implements TDependency
                    if (!tDependency.IsAssignableFrom(tImplementation))
                    {
                        throw new ArgumentException("TImplementation must be inherited from/implement Dependency type.");
                    }

                    // Checks if TImplementation is a not abstract class
                    if (tImplementation.IsAbstract || !tImplementation.IsClass)
                    {
                        throw new ArgumentException("TImplementation must be a non-abstract class");
                    }
                }
            }
        }

        public TDependency Resolve<TDependency>()
        {

            // Need to check for recursive creation.
            // Need to check for generics.
            // Need to check for IEnumerable and multiple TImplementations.

            Type tDependency = typeof(TDependency);


            // First, check if the dependency is registered at all
            if (!configuration.dependenciesContainer.ContainsKey(tDependency))
            {
                throw new KeyNotFoundException($"Dependency {tDependency.ToString()} is not registered.");
            }

        

            // First, check for IEnumerable to return list of registered implementations
            if (tDependency.IsGenericType && tDependency.GetGenericTypeDefinition().Equals(typeof(IEnumerable<>)))
            {

                // Generic implementation

            } else
            {
                if (configuration.dependenciesContainer[tDependency].Count != 1)
                {
                    throw new ArgumentException("TDependency has more than one implementations. IEnumerable must be used.");
                }
            }



            throw new NotImplementedException();
        }
    }
}
