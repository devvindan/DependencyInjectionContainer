using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIUnitTests.ToyClasses
{
    public class TComplexImplementation : TDependency
    {

        public IAnimal animal;
        public List<IVehicle> vehicles;

        public override void DoNothing()
        {
            // There's nothing here, but what here's mine.
        }

        public TComplexImplementation(IAnimal animal, IEnumerable<IVehicle> vehicles)
        {
            this.animal = animal;
            this.vehicles = (List<IVehicle>) vehicles;
        }

    }
}
