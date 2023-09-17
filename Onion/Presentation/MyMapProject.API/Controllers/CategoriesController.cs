using Application.Features.CQRS.Commands;
using Application.Features.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyMapProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator mediator;

        public CategoriesController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await this.mediator.Send(new GetCategoriesQueryRequest());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await this.mediator.Send(new GetCategoryQueryRequest(id));
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryCommandRequest request)
        {
            var result = await this.mediator.Send(request);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryCommandRequest request)
        {
            await this.mediator.Send(request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await this.mediator.Send(new DeleteCategoryCommandRequest(id));
            return NoContent();
        }
    }
}
