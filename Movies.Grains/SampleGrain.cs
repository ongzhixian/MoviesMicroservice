using Movies.Contracts;
using Orleans;
using Orleans.Providers;
using System;
using System.Threading.Tasks;

namespace Movies.Grains
{
	[StorageProvider(ProviderName = "Default")]
	public class SampleGrain : Grain<SampleDataModel>, ISampleGrain
	{
		public Task<SampleDataModel> Get()
		{
			//State.Name = "Some Name";
			//State.Id = "SomeID";
			Console.WriteLine(State);
			return Task.FromResult(State);
		}

		public Task Set(string name)
		{
			State = new SampleDataModel { Id = this.GetPrimaryKeyString(), Name = name };
			return Task.CompletedTask;
		}
	}
}

