using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIUnitTests.ToyClasses
{
    public class TPrivateImplementation : TDependency
    {
        public override void DoNothing()
        {
            // There's nothing here, but what here's mine
        }

        private TPrivateImplementation()
        {
            // You can watch, but you can't touch.
        }

    }
}
