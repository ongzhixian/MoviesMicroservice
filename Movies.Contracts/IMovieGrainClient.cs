using System.Threading.Tasks;

namespace Movies.Contracts
{
	public interface IMovieGrainClient
	{
		Task<MovieDataModel> Get(long id);

		Task Set(MovieDataModel movieDataModel);
	}
}
