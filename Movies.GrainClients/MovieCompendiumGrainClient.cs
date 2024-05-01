using Movies.Contracts;
using Orleans;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.GrainClients
{
	public class MovieCompendiumGrainClient : IMovieCompendiumGrainClient
	{
		private readonly IGrainFactory _grainFactory;

		public MovieCompendiumGrainClient(IGrainFactory grainFactory)
		{
			_grainFactory = grainFactory;
		}

		public async Task<HashSet<MovieDataModel>> GetAllMoviesAsync()
		{
			IMovieCompendiumGrain grain = _grainFactory.GetGrain<IMovieCompendiumGrain>(GrainDirectoryNames.MovieCompendium);
			var result = await grain.GetAllMoviesAsync();
			return result;
		}

		public async Task<List<string>> GetMovieGenreListAsync()
		{
			IMovieCompendiumGrain grain = _grainFactory.GetGrain<IMovieCompendiumGrain>(GrainDirectoryNames.MovieCompendium);
			HashSet<MovieDataModel> result = await grain.GetAllMoviesAsync();
			var x = result.SelectMany(r => r.Genres).Distinct().ToList();
			return x;
		}

		public async Task<HashSet<MovieDataModel>> GetTop5MoviesByRatingAsync()
		{
			IMovieCompendiumGrain grain = _grainFactory.GetGrain<IMovieCompendiumGrain>(GrainDirectoryNames.MovieCompendium);
			var result = await grain.GetTop5MoviesByRatingAsync();
			return result;
		}


		public async Task<HashSet<MovieDataModel>> GetMoviesByGenreAsync(string genre)
		{
			IMovieCompendiumGrain grain = _grainFactory.GetGrain<IMovieCompendiumGrain>(GrainDirectoryNames.MovieCompendium);
			var result = await grain.GetMoviesByGenreAsync(genre);
			return result;
		}
	
		public async Task<HashSet<MovieDataModel>> GetMoviesMatchAsync(string filter)
		{
			IMovieCompendiumGrain grain = _grainFactory.GetGrain<IMovieCompendiumGrain>(GrainDirectoryNames.MovieCompendium);
			var result = await grain.GetMoviesMatchAsync(filter);
			return result;
		}
		public async Task<HashSet<MovieDataModel>> FindMoviesAsync(string genre, string filter)
		{
			IMovieCompendiumGrain grain = _grainFactory.GetGrain<IMovieCompendiumGrain>(GrainDirectoryNames.MovieCompendium);
			var result = await grain.FindMovies(genre, filter);
			return result;
		}
	
		public Task AddOrUpdateProductAsync(MovieDataModel movieDataModel)
		{
			movieDataModel.Genres = new string[0];
			var grain = _grainFactory.GetGrain<IMovieGrain>(movieDataModel.Id);
			return grain.CreateOrUpdateMovieAsync(movieDataModel);
		}

		public Task RemoveMovieAsync(long movieId)
		{
			throw new System.NotImplementedException();
		}

		public async Task UpdateCacheAsync(MovieDataModel n)
		{
			IMovieCompendiumGrain grain = _grainFactory.GetGrain<IMovieCompendiumGrain>(GrainDirectoryNames.MovieCompendium);
			await grain.UpdateCache(n);
		}

	}
}