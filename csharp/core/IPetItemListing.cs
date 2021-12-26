namespace csharp;

public interface IPetItemShop {
    ICollection<IPetItemListing> Listings { get; init; }
    void CreateOrder(IPetItemCart cart) {}
    void ListItem(IPetItem item, int quantity, decimal price);
    void UnlistItem(IPetItem item);
    void UpdatePrice(IPetItem item, decimal price);
    void UpdateQuantity(IPetItem item, int quantity);
    IPetItem GetPetItem(string itemName);
}

public interface ICartToOrderConvertor {
    IPetItemOrder CreateOrderFromCart(IPetItemCart cart);
}

public interface IPetItemCart {
    void AddItem(IPetItem item, int quantity, decimal price);
    void RemoveItem(string itemName);
    void UpdateQuantity(string itemName, int quantity);
    void Clear();
}

public interface IPetItemOrder : IEntity<int> {
    ICollection<IPetItemListing> Items { get; set; }
    DateTime Date { get; init; }
    decimal Total { get; }
}

public interface IPetItemListing {
    public IPetItem PetItem { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}

public interface IPetItem : IEntity<int> {
    string Description { get; set; }
    string Image { get; set; }
    ItemType ItemType { get; set; }
    string Name { get; set; }
    PetType PetType { get; set; }
}
