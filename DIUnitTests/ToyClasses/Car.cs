using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIUnitTests.ToyClasses
{
    public class Car : IVehicle
    {

        public int mass = 100;

        public void Beep()
        {
            Console.WriteLine("Beep like a car!");
        }
    }
}
