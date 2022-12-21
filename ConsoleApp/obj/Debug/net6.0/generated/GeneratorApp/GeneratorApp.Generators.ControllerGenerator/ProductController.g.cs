
using API.ActionFilters;
using API.Attributes;
using API.Enums;
using BLL.Abstract;
using DTO.Responses;
using DTO.Product;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using IResult = DTO.Responses.IResult;

namespace API.Controllers;

[Route("api/[controller]")]
[ServiceFilter(typeof(LogActionFilter))]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[ValidateToken]
public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [SwaggerResponse(StatusCodes.Status200OK, type: typeof(IDataResult<List<ProductToListDto>>))]
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var response = await _productService.GetAsync();
        return Ok(response);
    }

    [SwaggerResponse(StatusCodes.Status200OK, type: typeof(IDataResult<ProductToListDto>))]
    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        var response = await _productService.GetAsync(id);
        return Ok(response);
    }

    [SwaggerResponse(StatusCodes.Status200OK, type: typeof(IResult))]
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] ProductToAddDto dto)
    {
        var response = await _productService.AddAsync(dto);
        return Ok(response);
    }

    [SwaggerResponse(StatusCodes.Status200OK, type: typeof(IResult))]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ProductToUpdateDto dto)
    {
        var response = await _productService.UpdateAsync(id, dto);
        return Ok(response);
    }

    [SwaggerResponse(StatusCodes.Status200OK, type: typeof(IResult))]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var response = await _productService.SoftDeleteAsync(id);
        return Ok(response);
    }
}
