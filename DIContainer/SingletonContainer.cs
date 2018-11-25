using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIContainer
{
    public class SingletonContainer
    {
        public volatile object instance;
        public object syncRoot = new object();

        public SingletonContainer()
        {
            instance = null;
        }

    }
}
