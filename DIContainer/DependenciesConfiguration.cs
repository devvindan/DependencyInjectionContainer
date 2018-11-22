using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIContainer
{
    public class DependenciesConfiguration
    {

        public DependenciesConfiguration()
        {

        }

        public void Register<TDependency, TImplementation>()
        {
            Type dependencyType = typeof(TDependency);
            Type implementationType = typeof(TImplementation);
            
            // Need to check if TImplementation type is abstract.

            // Need to check for recursive creation.

            // Need to check for generics.

            // Need to check for IEnumerable and multiple TImplementations.


            throw new NotImplementedException();
        }

    }
}
