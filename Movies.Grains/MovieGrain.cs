using Movies.Contracts;
using Orleans;
using Orleans.Providers;
using System;
using System.Threading.Tasks;

namespace Movies.Grains;

[StorageProvider(ProviderName = "Default")]
public class MovieGrain : Grain<MovieDataModel>, IMovieGrain
{

	public Task CreateOrUpdateMovieAsync(MovieDataModel movie)
	{
		State = movie;
		return Task.CompletedTask;
	}

	public Task<MovieDataModel> Get()
	{
		Console.WriteLine(State);
		return Task.FromResult(State);
	}

	public Task Set(string name)
	{
		State = new MovieDataModel { Id = this.GetPrimaryKeyLong(), Name = name };
		return Task.CompletedTask;
	}

	private async Task UpdateStateAsync(MovieDataModel movie)
	{
		State = movie;
		//return Task.CompletedTask;

		//var oldCategory = _product.State.Category;

		//_product.State = product;
		//await _product.WriteStateAsync();

		//var inventoryGrain = GrainFactory.GetGrain<IInventoryGrain>(_product.State.Category.ToString());
		//await inventoryGrain.AddOrUpdateProductAsync(product);

		//if (oldCategory != product.Category)
		//{
		//	// If category changed, remove the product from the old inventory grain.
		//	var oldInventoryGrain = GrainFactory.GetGrain<IInventoryGrain>(oldCategory.ToString());
		//	await oldInventoryGrain.RemoveProductAsync(product.Id);
		//}
	}
}

