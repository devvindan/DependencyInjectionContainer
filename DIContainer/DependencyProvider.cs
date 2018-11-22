using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIContainer
{
    public class DependencyProvider
    {
        public DependencyProvider(DependenciesConfiguration configuration)
        {

        }

        public TImplementation Resolve<TImplementation>()
        {
            throw new NotImplementedException();
        }
    }
}
