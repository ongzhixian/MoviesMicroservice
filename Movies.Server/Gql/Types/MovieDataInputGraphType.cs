using GraphQL.Types;
using Movies.Contracts;

namespace Movies.Server.Gql.Types
{
	public class MovieDataInputGraphType : InputObjectGraphType<MovieDataModel>
	{
		public MovieDataInputGraphType()
		{
			Name = "MovieInput";
			Description = "Movie data graphtype.";

			Field<IntGraphType>("id");
			Field<StringGraphType>("name");
			Field<FloatGraphType>("rate");
		}
	}
	
}