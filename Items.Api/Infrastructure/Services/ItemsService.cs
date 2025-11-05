namespace Items.Api.Infrastructure.Services;

public class ItemsService : IItemsService
{
    private readonly ItemsDbContext _dbContext;

    public ItemsService(ItemsDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task CreateItemAsync(Item item)
    {
        if (_dbContext.Items.Any(x => x.Equals(item)))
            throw new ArgumentException("Предмет уже существует");
        
        await _dbContext.AddAsync(item);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Item>> GetAllItemsAsync() =>  await _dbContext.Items.ToListAsync();
    
    public async Task<Item?> GetItemByIdAsync(int id) =>  await _dbContext.Items.FirstOrDefaultAsync(i => i.Id == id);

    public async Task<Item?> GetItemByNameAsync(string name) => await _dbContext.Items.FirstOrDefaultAsync(i => i.Name == name);

    public async Task UpdateItemAsync(Item item)
    {
        var itemToUpdate = _dbContext.Items.FirstOrDefault(i => i.Id == item.Id);

        if (itemToUpdate != null && itemToUpdate.Equals(item))
            throw new ArgumentException("Предмет никак не изменяется или передан пустым.");
        
        _dbContext.Update(item);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteItemAsync(int id)
    {
        var itemToDelete = await _dbContext.Items.FirstOrDefaultAsync(i => i.Id == id);

        if (itemToDelete == null)
            throw new ArgumentException("Предмета с таким id не существует.");
        
        _dbContext.Items.Remove(itemToDelete);
        await _dbContext.SaveChangesAsync();
    }

}