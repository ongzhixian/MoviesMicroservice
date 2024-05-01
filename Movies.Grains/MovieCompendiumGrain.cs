using Movies.Contracts;
using Orleans;
using Orleans.Runtime;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using System.Linq;
using Orleans.Concurrency;

namespace Movies.Grains
{
	[Reentrant]
	public class MovieCompendiumGrain : Grain, IMovieCompendiumGrain
	{
		private readonly IPersistentState<HashSet<long>> _movieIds;
		private readonly IPersistentState<long> _lastMovieId;

		private readonly Dictionary<long, MovieDataModel> _movieCache = new Dictionary<long, MovieDataModel>();

		public MovieCompendiumGrain(
			[PersistentState(stateName: "MovieCompendium")]
			IPersistentState<HashSet<long>> state,
			[PersistentState(stateName: "LastMovieId")]
			IPersistentState<long> lastMovieId
			)
		{
			_movieIds = state;
			_lastMovieId = lastMovieId;
		}

		public override Task OnActivateAsync()
		{
			Console.WriteLine($"MovieCompendiumGrain activated!");
			PopulateMovieCacheAsync();
			return base.OnActivateAsync();
		}

		public async Task AddOrUpdateMovieAsync(MovieDataModel movieDataModel)
		{
			if (movieDataModel.Id == 0)
				movieDataModel.Id = _lastMovieId.State + 1;
		
			if (movieDataModel.Id > _lastMovieId.State) 
				_lastMovieId.State = movieDataModel.Id;

			_movieIds.State.Add(movieDataModel.Id);

			_movieCache[movieDataModel.Id] = movieDataModel;

			await _movieIds.WriteStateAsync();
		}

		public Task<HashSet<MovieDataModel>> GetAllMoviesAsync()
		{
			var x = new HashSet<MovieDataModel>(_movieCache.Values);

			return Task.FromResult(x);
		}

		public Task<HashSet<MovieDataModel>> GetTop5MoviesByRatingAsync()
		{
			var x = new HashSet<MovieDataModel>(_movieCache.Values.OrderByDescending(r => r.Rate).Take(5));

			return Task.FromResult(x);
		}


		public Task<HashSet<MovieDataModel>> GetMoviesByGenreAsync(string genre)
		{
			var x = new HashSet<MovieDataModel>(
				_movieCache.Values.Where(r => r.Genres.Contains(genre, StringComparer.InvariantCultureIgnoreCase))
				);

			return Task.FromResult(x);
		}
	
		public Task<HashSet<MovieDataModel>> GetMoviesMatchAsync(string filter)
		{
			var x = new HashSet<MovieDataModel>(
				_movieCache.Values.Where(r => r.Name.IndexOf(filter, StringComparison.InvariantCultureIgnoreCase) >= 0)
				);

			return Task.FromResult(x);
		}

		public Task<HashSet<MovieDataModel>> FindMovies(string genre, string filter)
		{
			var x = new HashSet<MovieDataModel>(
				_movieCache.Values.Where(r => 
					((filter == null) || (r.Name.IndexOf(filter, StringComparison.InvariantCultureIgnoreCase) >= 0))
					&& ((genre == null) || (r.Genres.Contains(genre, StringComparer.InvariantCultureIgnoreCase)))
				));

			return Task.FromResult(x);
		}

		public Task RemoveMovieAsync(long movieId) => throw new System.NotImplementedException();



		private void PopulateMovieCacheAsync()
		{
			if (_movieIds == null || _movieIds.State.Count <= 0)
			{
				return;
			}

			Parallel.ForEach(
				_movieIds.State, // Explicitly use the current task-scheduler.
				new ParallelOptions
				{
					TaskScheduler = TaskScheduler.Current
				},
				async (id, _) =>
				{
					var movieGrain = GrainFactory.GetGrain<IMovieGrain>(id);
					_movieCache[id] = await movieGrain.Get();
				});
		}

		public Task UpdateCache(MovieDataModel n)
		{
			_movieCache[n.Id] = n;

			return Task.CompletedTask;
		}
	}
}