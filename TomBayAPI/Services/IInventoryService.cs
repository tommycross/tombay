using TomBay;

public interface IInventoryService
{
    public Task<IEnumerable<InventoryItem>> GetAllItemsAsync();
    public Task<InventoryItem> GetItemByIdAsync(int id);
    public Task AddItemAsync(InventoryItem product);
    public Task UpdateItemAsync(InventoryItem item);
    public Task DeleteItemAsync(int id);

}