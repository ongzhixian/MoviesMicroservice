using Movies.Contracts;
using Orleans;
using System.Threading.Tasks;

namespace Movies.GrainClients
{
	public class MovieGrainClient : IMovieGrainClient
	{
		private readonly IGrainFactory _grainFactory;

		public MovieGrainClient(IGrainFactory grainFactory)
		{
			_grainFactory = grainFactory;
		}

		//public Task<SampleDataModel> Get(string id)
		//{
		//	var grain = _grainFactory.GetGrain<ISampleGrain>(id);
		//	return grain.Get();
		//}

		public Task Set(string key, string name)
		{
			var grain = _grainFactory.GetGrain<ISampleGrain>(key);
			return grain.Set(name);
		}

		Task<MovieDataModel> IMovieGrainClient.Get(long id)
		{
			var grain = _grainFactory.GetGrain<IMovieGrain>(id);
			return grain.Get();
		}
	}
}