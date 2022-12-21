
using AutoMapper;
using BLL.Abstract;
using CORE.Localization;
using DAL.UnitOfWorks.Abstract;
using DTO.Responses;
using DTO.Tag;
using ENTITIES;

namespace BLL.Concrete;

public class TagService : ITagService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public TagService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult> AddAsync(TagToAddDto dto)
    {
        var data = _mapper.Map<Tag>(dto);

        await _unitOfWork.TagRepository.AddAsync(data);
        await _unitOfWork.CommitAsync();

        return new SuccessResult(Messages.Success.Translate());
    }

    public async Task<IResult> SoftDeleteAsync(int id)
    {
        var data = await _unitOfWork.TagRepository.GetAsync(m => m.TagId == id);

        _unitOfWork.TagRepository.SoftDelete(data);
        await _unitOfWork.CommitAsync();

        return new SuccessResult(Messages.Success.Translate());
    }

    public async Task<IDataResult<List<TagToListDto>>> GetAsync()
    {
        var datas = _mapper.Map<List<TagToListDto>>(await _unitOfWork.TagRepository.GetListAsync());

        return new SuccessDataResult<List<TagToListDto>>(datas, Messages.Success.Translate());
    }

    public async Task<IDataResult<TagToListDto>> GetAsync(int id)
    {
        var data = _mapper.Map<TagToListDto>(await _unitOfWork.TagRepository.GetAsync(m => m.TagId == id));

        return new SuccessDataResult<TagToListDto>(data, Messages.Success.Translate());
    }

    public async Task<IResult> UpdateAsync(int id, TagToUpdateDto dto)
    {
        var data = _mapper.Map<Tag>(dto);
        data.TagId = id;

        _unitOfWork.TagRepository.Update(data);
        await _unitOfWork.CommitAsync();

        return new SuccessResult(Messages.Success.Translate());
    }
}
