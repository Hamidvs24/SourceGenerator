
using AutoMapper;
using BLL.Abstract;
using CORE.Localization;
using DAL.UnitOfWorks.Abstract;
using DTO.Responses;
using DTO.Product;
using ENTITIES;

namespace BLL.Concrete;

public class ProductService : IProductService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult> AddAsync(ProductToAddDto dto)
    {
        var data = _mapper.Map<Product>(dto);

        await _unitOfWork.ProductRepository.AddAsync(data);
        await _unitOfWork.CommitAsync();

        return new SuccessResult(Messages.Success.Translate());
    }

    public async Task<IResult> SoftDeleteAsync(int id)
    {
        var data = await _unitOfWork.ProductRepository.GetAsync(m => m.ProductId == id);

        _unitOfWork.ProductRepository.SoftDelete(data);
        await _unitOfWork.CommitAsync();

        return new SuccessResult(Messages.Success.Translate());
    }

    public async Task<IDataResult<List<ProductToListDto>>> GetAsync()
    {
        var datas = _mapper.Map<List<ProductToListDto>>(await _unitOfWork.ProductRepository.GetListAsync());

        return new SuccessDataResult<List<ProductToListDto>>(datas, Messages.Success.Translate());
    }

    public async Task<IDataResult<ProductToListDto>> GetAsync(int id)
    {
        var data = _mapper.Map<ProductToListDto>(await _unitOfWork.ProductRepository.GetAsync(m => m.ProductId == id));

        return new SuccessDataResult<ProductToListDto>(data, Messages.Success.Translate());
    }

    public async Task<IResult> UpdateAsync(int id, ProductToUpdateDto dto)
    {
        var data = _mapper.Map<Product>(dto);
        data.ProductId = id;

        _unitOfWork.ProductRepository.Update(data);
        await _unitOfWork.CommitAsync();

        return new SuccessResult(Messages.Success.Translate());
    }
}
