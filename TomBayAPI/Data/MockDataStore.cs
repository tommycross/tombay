using TomBay;

public static class MockDataStore
{
    static MockDataStore()
    {
        Items = new List<InventoryItem>
        {
            new InventoryItem { Id = 1, Name = "Carpet", Description = "A 2x3 metre shallow pile floor rug, blue stripes", Price = 100.00M, ImagePath = "path/to/image.jpg" },
            new InventoryItem { Id = 2, Name = "TV Cabinet", Description = "A long IKEA TV cabinet in white gloss veneer", Price = 50.00M, ImagePath = "path/to/image.jpg" },
            new InventoryItem { Id = 3, Name = "Frying Pan", Description = "A 20cm Salter non stick pan, lightly used", Price = 10.00M, ImagePath = "path/to/image.jpg" },
            new InventoryItem { Id = 4, Name = "Mazda MX5", Description = "A small sports car, Grey, 2008 2.0L, Manual Transmission", Price = 3800.00M, ImagePath= "path/to/image.jpg" }
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