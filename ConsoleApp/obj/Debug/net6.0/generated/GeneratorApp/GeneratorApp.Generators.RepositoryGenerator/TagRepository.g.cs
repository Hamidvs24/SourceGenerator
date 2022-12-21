
using DAL.Abstract;
using DAL.DatabaseContext;
using DAL.GenericRepositories.Concrete;
using ENTITIES.Entities;

namespace DAL.Concrete;

public class TagRepository : GenericRepository<Tag>, ITagRepository
{
    private readonly DataContext _dataContext;

    public TagRepository(DataContext dataContext)
        : base(dataContext)
    {
        _dataContext = dataContext;
    }
}
