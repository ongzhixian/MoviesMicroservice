using Orleans;
using System.Threading.Tasks;

namespace Movies.Contracts;

public interface IMovieGrain : IGrainWithIntegerKey
{
	Task CreateOrUpdateMovieAsync(MovieDataModel movie);

	Task<MovieDataModel> Get();

	Task Set(string name);
}
