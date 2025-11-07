using Items.Generator.Domain.Enums;

namespace Items.Generator.Infrastructure.Services;

public class Generator : IGenerator
{
    public Task<List<Item>> GenerateItems(int count)
    {
        var rnd = new Random();
        var items = new List<Item>();

        for (int i = 0; i < count; i++)
        {
            var randNumber = rnd.Next(0, 100);
            
        }
    }

    private Rarity GetRarity(int number)
    {
        switch (number)
        {
            case 100 or 99:
                return Rarity.Common;
            case >= 94 and <= 98:
                return Rarity.Legendary;
            case >= 80 and <= 93:
                return Rarity.Epic;
            case >= 60 and <= 79:
                return Rarity.Rare;
            case >= 35 and <= 59:
                return Rarity.Uncommon;
            default:
                return Rarity.Common;
        }
    }
}