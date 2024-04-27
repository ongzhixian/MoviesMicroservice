using Movies.Contracts;
using Orleans;
using Orleans.Runtime;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Movies.Server.Infrastructure;

internal class SeedMovieStoreTask : IStartupTask
{
	private readonly IGrainFactory _grainFactory;

	public SeedMovieStoreTask(IGrainFactory grainFactory) => _grainFactory = grainFactory;

	public async Task Execute(CancellationToken cancellationToken)
	{
		var jsonFileData = File.ReadAllText(@"movies.json");

		var dataFile = JsonSerializer.Deserialize<MoviesJsonFileStructure>(jsonFileData);
		
		foreach (var movie in dataFile.Movies)
		{
			var movieGrain = _grainFactory.GetGrain<IMovieGrain>(movie.Id);
			
			await movieGrain.CreateOrUpdateMovieAsync(movie);
		}
	}

	private sealed class MoviesJsonFileStructure
	{
		[JsonPropertyName("movies")]
		public MovieDataModel[] Movies { get; set; } = null!;
	}
}