using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIUnitTests.ToyClasses
{
    public class Dog : IAnimal
    {

        public string name = "Jack";

        public void Speak()
        {
            Console.WriteLine("Bark!");
        }
    }
}
