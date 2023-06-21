using BogdaroneApp.Domain.DataAccess;

namespace BogdaroneApp.QuickData.Repositories;

/// <summary>
/// Base class for repositories that implement the <see cref="IRepository{T}"/> and <see cref="IScopedRepository"/> interfaces.
/// </summary>
/// <typeparam name="T">The type of entity that the repository manages.</typeparam>
internal abstract class Repository<T> : IRepository<T>, IScopedRepository 
    where T: class
{
    /// <summary>
    /// This constructor is used by the DI container.
    /// </summary>
    internal protected Repository() { }

    public Repository(IDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public IDbContext DbContext { get; private set; }

    IDbContext IScopedRepository.DbContext { 
        get => this.DbContext;
        set => this.DbContext = value;
    }

    public abstract void Add(T entity);
    public abstract void Delete(T entity);
    public abstract IEnumerable<T> GetAll();
    public abstract T GetById(string id);
    public abstract void Update(T entity);
}