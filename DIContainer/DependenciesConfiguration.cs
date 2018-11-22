using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIContainer
{
    public class DependenciesConfiguration
    {

        // Defining configuration structures

        // Bool value is true if object lifetime type is Singletone
        Dictionary<Type, bool> lifetimeSettings;

        // Dictionary to story created objects for sigletone types
        Dictionary<Type, Object> objectContainer;

        // Dictionary to map Abstracy Dependency to Concrete Implementation(s)
        Dictionary<Type, List<Type>> dependenciesContainer;

        public void Register<TDependency, TImplementation>()
        {
            Type dependencyType = typeof(TDependency);
            Type implementationType = typeof(TImplementation);


            


            // Need to check for recursive creation.

            // Need to check for generics.

            // Need to check for IEnumerable and multiple TImplementations.


            throw new NotImplementedException();
        }

        public void Register(Type tDependancy, Type tImplementation)
        {
            throw new NotImplementedException();
        }



    }
}
