
using DAL.Abstract;

namespace DAL.UnitOfWorks.Abstract;

public interface IUnitOfWork : IAsyncDisposable
{
    public ITagRepository TagRepository { get; set; }
    public IUserRepository UserRepository { get; set; }
    public IProductRepository ProductRepository { get; set; }

    public Task CommitAsync();
}
