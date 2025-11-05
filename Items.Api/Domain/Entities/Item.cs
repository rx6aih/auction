namespace Items.Api.Domain.Entities;

public class Item
{
    public override bool Equals(object obj)
    {
        var item = obj as Item;
        
        if(item != null && (this.Name != item.Name || this.Description != item.Description || this.Rarity != item.Rarity))
            return false;
        return true;
    }

    public override int GetHashCode()
    {
        return this.Id.GetHashCode();
    }

    public int Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    public string Description { get; set; } = string.Empty;
    
    public Rarity Rarity { get; set; }
}