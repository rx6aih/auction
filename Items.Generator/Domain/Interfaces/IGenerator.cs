namespace Items.Generator.Domain.Interfaces;

public interface IGenerator
{
    public Task<List<Item>> GenerateItems(int count);
}