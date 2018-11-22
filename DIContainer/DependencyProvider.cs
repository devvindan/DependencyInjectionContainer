using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIContainer
{
    public class DependencyProvider
    {

        DependenciesConfiguration configuration;

        public void validateConfiguration(DependenciesConfiguration configuration)
        {
            // Iterate over registered dependencies
            foreach(Type tDependency in configuration.dependenciesContainer.Keys)
            {

                // Checks if TDependency is a reference type
                if (tDependency.IsValueType)
                {
                    throw new ArgumentException("TDependency must be a reference type");
                }

                // Iterate over registred dependency implementations
                foreach(Type tImplementation in configuration.dependenciesContainer[tDependency])
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
            


            throw new NotImplementedException();
        }


        public DependencyProvider(DependenciesConfiguration configuration)
        {
            if (validateConfiguration(configuration))
            {
                this.configuration = configuration;
            } else
            {
                throw new ArgumentException("Invalid dependencies configuration.");
            }
            
        }

        public TImplementation Resolve<TImplementation>()
        {
            throw new NotImplementedException();
        }
    }
}
