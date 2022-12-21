
using DTO.Tag;
using DTO.Responses;

namespace BLL.Abstract;

public interface ITagService
{
    Task<IDataResult<List<TagToListDto>>> GetAsync();

    Task<IDataResult<TagToListDto>> GetAsync(int id);

    Task<IResult> AddAsync(TagToAddDto dto);

    Task<IResult> UpdateAsync(int id, TagToUpdateDto dto);

    Task<IResult> SoftDeleteAsync(int id);
}
