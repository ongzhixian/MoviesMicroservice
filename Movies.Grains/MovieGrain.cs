using Movies.Contracts;
using Orleans;
using Orleans.Providers;
using System;
using System.Threading.Tasks;

namespace Movies.Grains
{
	[StorageProvider(ProviderName = "Default")]
	public class MovieGrain : Grain<MovieDataModel>, IMovieGrain
	{
		public Task CreateOrUpdateMovieAsync(MovieDataModel movie) => UpdateState(movie);

		private async Task UpdateState(MovieDataModel movie)
		{
			State = movie;

			var movieCompendiumGrain = GrainFactory.GetGrain<IMovieCompendiumGrain>(GrainDirectoryNames.MovieCompendium);
		
			await movieCompendiumGrain.AddOrUpdateMovieAsync(movie);
		}

		public Task<MovieDataModel> Get()
		{
			Console.WriteLine(State);
			return Task.FromResult(State);
		}
	}
}
