
using AutoMapper;
using BLL.Abstract;
using CORE.Localization;
using DAL.UnitOfWorks.Abstract;
using DTO.Responses;
using DTO.User;
using ENTITIES;

namespace BLL.Concrete;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult> AddAsync(UserToAddDto dto)
    {
        var data = _mapper.Map<User>(dto);

        await _unitOfWork.UserRepository.AddAsync(data);
        await _unitOfWork.CommitAsync();

        return new SuccessResult(Messages.Success.Translate());
    }

    public async Task<IResult> SoftDeleteAsync(int id)
    {
        var data = await _unitOfWork.UserRepository.GetAsync(m => m.UserId == id);

        _unitOfWork.UserRepository.SoftDelete(data);
        await _unitOfWork.CommitAsync();

        return new SuccessResult(Messages.Success.Translate());
    }

    public async Task<IDataResult<List<UserToListDto>>> GetAsync()
    {
        var datas = _mapper.Map<List<UserToListDto>>(await _unitOfWork.UserRepository.GetListAsync());

        return new SuccessDataResult<List<UserToListDto>>(datas, Messages.Success.Translate());
    }

    public async Task<IDataResult<UserToListDto>> GetAsync(int id)
    {
        var data = _mapper.Map<UserToListDto>(await _unitOfWork.UserRepository.GetAsync(m => m.UserId == id));

        return new SuccessDataResult<UserToListDto>(data, Messages.Success.Translate());
    }

    public async Task<IResult> UpdateAsync(int id, UserToUpdateDto dto)
    {
        var data = _mapper.Map<User>(dto);
        data.UserId = id;

        _unitOfWork.UserRepository.Update(data);
        await _unitOfWork.CommitAsync();

        return new SuccessResult(Messages.Success.Translate());
    }
}
