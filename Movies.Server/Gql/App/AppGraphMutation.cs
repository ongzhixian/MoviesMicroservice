using GraphQL;
using GraphQL.Types;
using Movies.Contracts;
using Movies.Server.Gql.Types;

namespace Movies.Server.Gql.App
{
	public class AppGraphMutation : ObjectGraphType
	{
		public AppGraphMutation(
			IMovieGrainClient movieClient
			, IMovieCompendiumGrainClient movieCompendiumClient)
		{
			Field<MovieDataGraphType>(
				"createMovie",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<MovieDataInputGraphType>> { Name = "movie" }),
				resolve: context =>
				{
					MovieDataModel newMovie = context.GetArgument<MovieDataModel>("movie");

					return movieCompendiumClient.AddOrUpdateProductAsync(newMovie);
				});


			FieldAsync<MovieDataGraphType>(
				"updateMovie",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<MovieDataInputGraphType>> { Name = "movie" }),
				resolve: async context =>
				{
					MovieDataModel newMovie = context.GetArgument<MovieDataModel>("movie");

					MovieDataModel n = await movieClient.Get(newMovie.Id);

					n.Rate = newMovie.Rate;

					await movieClient.Set(n);

					return n;
				});
		}
	}
}