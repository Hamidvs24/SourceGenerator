
using DTO.Product;
using DTO.Responses;

namespace BLL.Abstract;

public interface IProductService
{
    Task<IDataResult<List<ProductToListDto>>> GetAsync();

    Task<IDataResult<ProductToListDto>> GetAsync(int id);

    Task<IResult> AddAsync(ProductToAddDto dto);

    Task<IResult> UpdateAsync(int id, ProductToUpdateDto dto);

    Task<IResult> SoftDeleteAsync(int id);
}
