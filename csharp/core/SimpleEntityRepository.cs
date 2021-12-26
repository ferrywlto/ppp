namespace csharp;

public interface IEntity<TKey> {
    TKey Id { get; set; }
}

public interface ICommand<in T, in TKey> where T : IEntity<TKey> {
    void Create(T item);
    void Update(T item);
    void Delete(TKey key);
}

public interface IQuery<T, in TKey> where T : IEntity<TKey> {
    T Query(TKey key);
    ICollection<T> QueryAll();
}

public interface IRepository<T, TKey> : ICommand<T, TKey>, IQuery<T, TKey> where T : IEntity<TKey> {}

public abstract class Repository<T, TKey> : IRepository<T, TKey> where T : IEntity<TKey> {
    protected ICollection<T> Items = new List<T>();
    public abstract void Create(T item);
    public abstract void Update(T item);
    public abstract void Delete(TKey key);
    public abstract T Query(TKey key);
    public abstract ICollection<T> QueryAll();
}
