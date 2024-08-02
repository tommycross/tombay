using TomBay;

public static class MockDataStore
{
    static MockDataStore()
    {
        Items = new List<InventoryItem>
        {
            new InventoryItem { Id = 1, Name = "Carpet" },
            new InventoryItem { Id = 2, Name = "TV Cabinet" },
            new InventoryItem { Id = 3, Name = "Frying Pan" },
        };
    }

    public static List<InventoryItem> Items { get; set; }

    public static InventoryItem GetProductById(int id) => Items.FirstOrDefault(p => p.Id == id);
    public static void AddProduct(InventoryItem product) => Items.Add(product);
    public static void UpdateProduct(InventoryItem product)
    {
        var index = Items.FindIndex(p => p.Id == product.Id);
        if (index != -1)
            Items[index] = product;
    }
    public static void DeleteProduct(int id) => Items.RemoveAll(p => p.Id == id);
}