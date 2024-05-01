using Microsoft.AspNetCore.Mvc;
using Movies.Contracts;
using System;
using System.Threading.Tasks;

namespace Movies.Server.Controllers
{
	[Route("api/[controller]")]
	public class SampleDataController : Controller
	{
		private readonly ISampleGrainClient _client;
		private readonly IMovieGrainClient _movieClient;
		private readonly IMovieCompendiumGrainClient _movieCompendiumClient;

		public SampleDataController(
			ISampleGrainClient client,
			IMovieGrainClient movieClient,
			IMovieCompendiumGrainClient movieCompendiumClient
		)
		{
			_client = client;
			_movieClient = movieClient;
			_movieCompendiumClient = movieCompendiumClient;
		}

		// GET api/sampledata/1234
		[HttpGet("{id}")]
		public async Task<SampleDataModel> Get(string id)
		{
			//var result2 = await _movieClient.Get(Convert.ToInt64(id)).ConfigureAwait(false);
			////_movieClient.Set()

			//var m = await _movieCompendiumClient.GetAllMoviesAsync();

			//var n = await _movieCompendiumClient.GetTop5MoviesByRatingAsync();

			//var p = await _movieCompendiumClient.GetMoviesByGenreAsync("action");

			//var q = await _movieCompendiumClient.GetMoviesMatchAsync("mill");

			var result = await _client.Get(id).ConfigureAwait(false);
			return result;
		}

		// POST api/sampledata/1234
		[HttpPost("{id}")]
		public async Task Set([FromRoute] string id, [FromForm] string name)
			=> await _client.Set(id, name).ConfigureAwait(false);

		[HttpGet]
		[Route("Top5")]
		public async Task<SampleDataModel> GetTop5(string id)
		{
			await _movieClient.Get(1).ConfigureAwait(false);

			var result = await _client.Get(id).ConfigureAwait(false);
			return result;
		}
	}
}