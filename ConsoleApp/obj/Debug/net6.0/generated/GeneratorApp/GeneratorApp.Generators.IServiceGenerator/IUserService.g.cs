
using DTO.User;
using DTO.Responses;

namespace BLL.Abstract;

public interface IUserService
{
    Task<IDataResult<List<UserToListDto>>> GetAsync();

    Task<IDataResult<UserToListDto>> GetAsync(int id);

    Task<IResult> AddAsync(UserToAddDto dto);

    Task<IResult> UpdateAsync(int id, UserToUpdateDto dto);

    Task<IResult> SoftDeleteAsync(int id);
}
