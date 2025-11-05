namespace Items.Api.Domain.Interfaces;

public interface IItemsService
{
    public Task CreateItemAsync(Item item);
    public Task<IEnumerable<Item>> GetAllItemsAsync();
    public Task<Item?> GetItemByIdAsync(int id);
    public Task<Item?> GetItemByNameAsync(string name);
    public Task UpdateItemAsync(Item item);
    public Task DeleteItemAsync(int id);
}