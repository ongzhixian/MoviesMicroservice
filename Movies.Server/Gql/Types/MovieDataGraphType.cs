using GraphQL.Types;
using Movies.Contracts;

namespace Movies.Server.Gql.Types
{
	public class MovieDataGraphType : ObjectGraphType<MovieDataModel>
	{
		public MovieDataGraphType()
		{
			Name = "Movie";
			Description = "Movie data graphtype.";

			Field(x => x.Id, nullable: true).Description("Unique key.");
			Field(x => x.Name, nullable: true).Description("Name.");
			Field(x => x.Rate, nullable: true).Description("Rate.");
		}
	}
}