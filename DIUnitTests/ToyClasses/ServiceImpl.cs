using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIUnitTests.ToyClasses
{
    class ServiceImpl<TRepository> : IService<TRepository> where TRepository : TDependency
    {

        TRepository repository;

        public void DoWhatYouAreBestAt(TRepository repository)
        {
            repository.DoNothing();
        }

        public ServiceImpl(TRepository repository)
        {
            this.repository = repository;
        }

    }
}
