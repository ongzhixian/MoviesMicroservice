using Orleans;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.Contracts
{
	public interface IMovieCompendiumGrain : IGrainWithStringKey
	{
		Task<HashSet<MovieDataModel>> GetAllMoviesAsync();

		Task<HashSet<MovieDataModel>> GetTop5MoviesByRatingAsync();

		Task<HashSet<MovieDataModel>> GetMoviesByGenreAsync(string genre);

		Task<HashSet<MovieDataModel>> GetMoviesMatchAsync(string filter);

		Task<HashSet<MovieDataModel>> FindMovies(string genre, string filter);

		Task AddOrUpdateMovieAsync(MovieDataModel movieDataModel);

		Task RemoveMovieAsync(long movieId);

		Task UpdateCache(MovieDataModel n);
	}
}