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

        public bool validateConfiguration(DependenciesConfiguration configuration)
        {

            // Need to check if TImplementation type is abstract.
            // if types are equal, IsSubclassOf doesnt work 


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
