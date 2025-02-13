using Avtobus1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Avtobus1.API
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class LinksController(ILinkService service) : ControllerBase
    {
        private readonly ILinkService _service = service;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return new JsonResult(await _service.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return new JsonResult(await _service.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PostModel model)
        {
            var result = await _service.Create(model.Value!);
            Response.StatusCode = result is null ? 401 : 201;
            return result is null ? BadRequest("Provided link has wrong format") : new JsonResult(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Link link)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = 401;
                return new JsonResult(ModelState["Link"]?.Errors[0].ErrorMessage);
            }

            var result = await _service.Update(link);
            Response.StatusCode = result is null ? 401 : 201;
            return result is null ? BadRequest($"There is now entry with {link.Id} id") : new JsonResult(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _service.Delete(id);
            return result ? Ok("Entity was successfully deleted") : BadRequest($"No entity with {id} id");
        }

        public class PostModel
        {
            public string? Value { get; set; }
        }
    }
}
