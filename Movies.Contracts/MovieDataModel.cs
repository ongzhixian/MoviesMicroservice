using System.Text.Json.Serialization;

namespace Movies.Contracts
{
	public class MovieDataModel
	{
		[JsonPropertyName("id")]
		public long Id { get; set; }

		[JsonPropertyName("key")]
		public string Key { get; set; }

		[JsonPropertyName("name")]
		public string Name { get; set; }

		[JsonPropertyName("description")]
		public string Description { get; set; }

		[JsonPropertyName("genres")]
		public string[] Genres { get; set; }

		[JsonPropertyName("rate")]
		public decimal Rate { get; set; }

		[JsonPropertyName("length")]
		public string Length { get; set; }

		[JsonPropertyName("img")]
		public string Img { get; set; }
	}
}
