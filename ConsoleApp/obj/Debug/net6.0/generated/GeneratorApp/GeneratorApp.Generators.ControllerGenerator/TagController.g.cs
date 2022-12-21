
using API.ActionFilters;
using API.Attributes;
using API.Enums;
using BLL.Abstract;
using DTO.Responses;
using DTO.Tag;
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
public class TagController : Controller
{
    private readonly ITagService _tagService;

    public TagController(ITagService tagService)
    {
        _tagService = tagService;
    }

    [SwaggerResponse(StatusCodes.Status200OK, type: typeof(IDataResult<List<TagToListDto>>))]
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var response = await _tagService.GetAsync();
        return Ok(response);
    }

    [SwaggerResponse(StatusCodes.Status200OK, type: typeof(IDataResult<TagToListDto>))]
    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        var response = await _tagService.GetAsync(id);
        return Ok(response);
    }

    [SwaggerResponse(StatusCodes.Status200OK, type: typeof(IResult))]
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] TagToAddDto dto)
    {
        var response = await _tagService.AddAsync(dto);
        return Ok(response);
    }

    [SwaggerResponse(StatusCodes.Status200OK, type: typeof(IResult))]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] TagToUpdateDto dto)
    {
        var response = await _tagService.UpdateAsync(id, dto);
        return Ok(response);
    }

    [SwaggerResponse(StatusCodes.Status200OK, type: typeof(IResult))]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var response = await _tagService.SoftDeleteAsync(id);
        return Ok(response);
    }
}
