using DependencyInversionWorkerAfter.Contracts;
using System.Collections.Generic;

namespace DependencyInversionWorkerAfter
{
    public class Manager
    {
        private IList<IWorker> _workers;

        public Manager(IList<IWorker> workers)
        {
            _workers = workers;
        }        

        public void Manage()
        {
            foreach (var worker in _workers)
            {
                worker.Work();
            }
        }
    }
}
