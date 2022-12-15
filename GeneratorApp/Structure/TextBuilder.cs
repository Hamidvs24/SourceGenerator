namespace GeneratorApp.Structure
{
    public class TextBuilder
    {
        public static string BuildTextForIEntityService(Entity entity)
        {
            var text = @"
using DTO.{entityName};
using DTO.Responses;

namespace BLL.Abstract;

public interface I{entityName}Service
{
    Task<IDataResult<List<{entityName}ToListDto>>> GetAsync();

    Task<IDataResult<{entityName}ToListDto>> GetAsync(int id);

    Task<IResult> AddAsync({entityName}ToAddDto dto);

    Task<IResult> UpdateAsync(int id, {entityName}ToUpdateDto dto);

    Task<IResult> SoftDeleteAsync(int id);
}
";

            text = text.Replace("{entityName}", entity.Name);
            return text;
        }

        public static string BuildTextForEntityService(Entity entity)
        {
            var text = @"
using AutoMapper;
using BLL.Abstract;
using CORE.Localization;
using DAL.UnitOfWorks.Abstract;
using DTO.Responses;
using DTO.{entityName};
using ENTITIES;

namespace BLL.Concrete;

public class {entityName}Service : I{entityName}Service
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public {entityName}Service(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult> AddAsync({entityName}ToAddDto dto)
    {
        var data = _mapper.Map<{entityName}>(dto);

        await _unitOfWork.{entityName}Repository.AddAsync(data);
        await _unitOfWork.CommitAsync();

        return new SuccessResult(Messages.Success.Translate());
    }

    public async Task<IResult> SoftDeleteAsync(int id)
    {
        var data = await _unitOfWork.{entityName}Repository.GetAsync(m => m.{entityName}Id == id);

        _unitOfWork.{entityName}Repository.SoftDelete(data);
        await _unitOfWork.CommitAsync();

        return new SuccessResult(Messages.Success.Translate());
    }

    public async Task<IDataResult<List<{entityName}ToListDto>>> GetAsync()
    {
        var datas = _mapper.Map<List<{entityName}ToListDto>>(await _unitOfWork.{entityName}Repository.GetListAsync());

        return new SuccessDataResult<List<{entityName}ToListDto>>(datas, Messages.Success.Translate());
    }

    public async Task<IDataResult<{entityName}ToListDto>> GetAsync(int id)
    {
        var data = _mapper.Map<{entityName}ToListDto>(await _unitOfWork.{entityName}Repository.GetAsync(m => m.{entityName}Id == id));

        return new SuccessDataResult<{entityName}ToListDto>(data, Messages.Success.Translate());
    }

    public async Task<IResult> UpdateAsync(int id, {entityName}ToUpdateDto dto)
    {
        var data = _mapper.Map<{entityName}>(dto);
        data.{entityName}Id = id;

        _unitOfWork.{entityName}Repository.Update(data);
        await _unitOfWork.CommitAsync();

        return new SuccessResult(Messages.Success.Translate());
    }
}
";

            text = text.Replace("{entityName}", entity.Name);
            return text;
        }
    }
}