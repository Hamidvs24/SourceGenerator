
using DAL.Abstract;
using DAL.DatabaseContext;
using DAL.GenericRepositories.Concrete;
using ENTITIES.Entities;

namespace DAL.Concrete;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    private readonly DataContext _dataContext;

    public ProductRepository(DataContext dataContext)
        : base(dataContext)
    {
        _dataContext = dataContext;
    }
}
