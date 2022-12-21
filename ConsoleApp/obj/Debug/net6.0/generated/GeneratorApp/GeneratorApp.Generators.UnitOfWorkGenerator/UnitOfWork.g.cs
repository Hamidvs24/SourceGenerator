
using DAL.Abstract;
using DAL.DatabaseContext;
using DAL.UnitOfWorks.Abstract;

namespace DAL.UnitOfWorks.Concrete;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataContext _dataContext;

    private bool _isDisposed;

    public UnitOfWork(
        DataContext dataContext,
        ITagRepository tagRepository,
        IUserRepository userRepository,
        IProductRepository productRepository
    )
    {
        _dataContext = dataContext;
        TagRepository = tagRepository;
        UserRepository = userRepository;
        ProductRepository = productRepository;
    }

    public ITagRepository TagRepository { get; set; }
    public IUserRepository UserRepository { get; set; }
    public IProductRepository ProductRepository { get; set; }

    public async Task CommitAsync()
    {
        await _dataContext.SaveChangesAsync();
    }

    public async ValueTask DisposeAsync()
    {
        if (!_isDisposed)
        {
            _isDisposed = true;
            await DisposeAsync(true);
            GC.SuppressFinalize(this);
        }
    }

    public void Dispose()
    {
        if (_isDisposed) return;
        _isDisposed = true;
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing) _dataContext.Dispose();
    }

    private async ValueTask DisposeAsync(bool disposing)
    {
        if (disposing) await _dataContext.DisposeAsync();
    }
}
