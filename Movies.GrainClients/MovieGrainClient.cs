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

		public Task Set(MovieDataModel movieDataModel)
		{
			var grain = _grainFactory.GetGrain<IMovieGrain>(movieDataModel.Id);
			return grain.CreateOrUpdateMovieAsync(movieDataModel);
		}

		Task<MovieDataModel> IMovieGrainClient.Get(long id)
		{
			var grain = _grainFactory.GetGrain<IMovieGrain>(id);
			return grain.Get();
		}
	}
}
