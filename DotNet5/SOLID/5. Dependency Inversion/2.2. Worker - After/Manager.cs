namespace DependencyInversionWorkerAfter
{
	class Manager
	{
		IWorker _worker;

		public void setWorker(IWorker worker)
		{
			_worker = worker;
		}

		public void manage()
		{
			_worker.work();
		}
	}
}
