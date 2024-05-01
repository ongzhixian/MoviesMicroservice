using GraphQL.Types;
using Movies.Contracts;
using Movies.Server.Gql.Types;
using System;

namespace Movies.Server.Gql.App
{
	public class AppGraphQuery : ObjectGraphType
	{
		public AppGraphQuery(
			ISampleGrainClient sampleClient
			, IMovieGrainClient movieClient
			, IMovieCompendiumGrainClient movieCompendiumClient)
		{
			Name = "AppQueries";


			Field<SampleDataGraphType>("sample",
				arguments: new QueryArguments(new QueryArgument<StringGraphType>
				{
					Name = "id"
				}),
				resolve: ctx => sampleClient.Get(ctx.Arguments["id"].ToString())
			);


			Field<MovieDataGraphType>("movie",
				arguments: new QueryArguments(new QueryArgument<IntGraphType>
				{
					Name = "id"
				}),
				resolve: ctx => movieClient.Get(Convert.ToInt64(ctx.Arguments["id"]))
			);


			Field<ListGraphType<MovieDataGraphType>>("movies"
				, arguments: new QueryArguments(
				  new QueryArgument<IntGraphType> { Name = "first" }
				  , new QueryArgument<StringGraphType> { Name = "name" }
				  , new QueryArgument<StringGraphType> { Name = "genre" }
				)
				, resolve: ctx => {

					if (ctx.Arguments.Count == 0) return movieCompendiumClient.GetAllMoviesAsync();

					if (ctx.Arguments.ContainsKey("first"))
					{
						var x = ctx.Arguments["first"];
						return movieCompendiumClient.GetTop5MoviesByRatingAsync();
					}

					string genre = null;
					string name = null;

					if (ctx.Arguments.ContainsKey("name"))
					{
						name = ctx.Arguments["name"].ToString();
					}
					if (ctx.Arguments.ContainsKey("genre"))
					{
						genre = ctx.Arguments["genre"].ToString();
					}

					return movieCompendiumClient.FindMoviesAsync(genre, name);
				}
			);

		}
	}
}
