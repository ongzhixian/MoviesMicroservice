using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.Contracts
{
	public interface IMovieCompendiumGrainClient
	{
	
		Task<HashSet<MovieDataModel>> GetAllMoviesAsync();

		Task<HashSet<MovieDataModel>> GetTop5MoviesByRatingAsync();

		Task<List<string>> GetMovieGenreListAsync();

		Task<HashSet<MovieDataModel>> GetMoviesByGenreAsync(string genre);

		Task<HashSet<MovieDataModel>> GetMoviesMatchAsync(string filter);

		Task<HashSet<MovieDataModel>> FindMoviesAsync(string genre, string filter);

		Task AddOrUpdateProductAsync(MovieDataModel movieDataModel);

		Task RemoveMovieAsync(long movieId);

		Task UpdateCacheAsync(MovieDataModel n);
	}
}
