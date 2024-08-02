namespace TomBay;

public class InventoryService : IInventoryService
{
    public Task<IEnumerable<InventoryItem>> GetAllItemsAsync()
    {
        return Task.FromResult(MockDataStore.Items.AsEnumerable());
    }

    public Task<InventoryItem> GetItemByIdAsync(int id)
    {
        return Task.FromResult(MockDataStore.GetProductById(id));
    }

    public Task AddItemAsync(InventoryItem product)
    {
        MockDataStore.AddProduct(product);
        return Task.CompletedTask;
    }

    public Task UpdateItemAsync(InventoryItem item)
    {
        MockDataStore.UpdateProduct(item);
        return Task.CompletedTask;
    }

    public Task DeleteItemAsync(int id)
    {
        MockDataStore.DeleteProduct(id);
        return Task.CompletedTask;
    }
}