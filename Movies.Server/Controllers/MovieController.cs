using Microsoft.AspNetCore.Mvc;
using Movies.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Movies.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MovieController : ControllerBase
	{
		private readonly IMovieGrainClient _movieClient;
		private readonly IMovieCompendiumGrainClient _movieCompendiumClient;

		public MovieController(
			IMovieGrainClient movieClient,
			IMovieCompendiumGrainClient movieCompendiumClient
		)
		{
			_movieClient = movieClient;
			_movieCompendiumClient = movieCompendiumClient;
		}

		// GET: api/<MovieController>
		[HttpGet]
		public async Task<IActionResult> GetAsync([FromQuery] string genre, [FromQuery] string search)
		{
			HashSet<MovieDataModel> m;

			if ( genre == null )
			{
				m = await _movieCompendiumClient.GetAllMoviesAsync();
			}
			else
			{
				m = await _movieCompendiumClient.GetMoviesByGenreAsync(genre);
			}

			m = await _movieCompendiumClient.FindMoviesAsync(genre, search);

			return Ok(m);
		}

		[HttpGet]
		[Route("highest-rated")]
		public async Task<IActionResult> GetHighestRateAsync(int numberOfRanks = 5)
		{
			var n = await _movieCompendiumClient.GetTop5MoviesByRatingAsync();

			return Ok(n);
		}

		[HttpGet]
		[Route("genre-list")]
		public async Task<IActionResult> GetGenreListAsync(int numberOfRanks = 5)
		{
			var n = await _movieCompendiumClient.GetMovieGenreListAsync();

			return Ok(n);
		}

	

		// GET api/<MovieController>/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetAsync(int id)
		{
			MovieDataModel n = await _movieClient.Get(id);

			return Ok(n);
		}

		// POST api/<MovieController>
		[HttpPost]
		public async Task<IActionResult> PostAsync([FromBody] AddMovieRequest request)
		{

			System.Console.WriteLine("asd");

			try
			{
				await _movieCompendiumClient.AddOrUpdateProductAsync(new MovieDataModel
				{
					Name = request.Name,
					Rate = request.Rate,
				});

				return Ok(new {
					Result = "success"
				});
			}
			catch (System.Exception ex)
			{
				return BadRequest(ex);
			}
		
		}

		// PUT api/<MovieController>/5
		[HttpPut("{id}")]
		public async Task<IActionResult> PutAsync(int id, [FromBody] UpdateMovieRequest value)
		{
			MovieDataModel n = await _movieClient.Get(id);

			n.Rate = value.Rate;

			await _movieClient.Set(n);

			await _movieCompendiumClient.UpdateCacheAsync(n);

			return Ok();
		}

		// DELETE api/<MovieController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}

	public class AddMovieRequest
	{
		public string Name { get; set; }
		public decimal Rate { get; set; }
	}

	public class UpdateMovieRequest
	{
		public int Id { get; set; }
		public decimal Rate { get; set; }
	}
}