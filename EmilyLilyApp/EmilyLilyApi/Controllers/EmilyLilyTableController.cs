using Azure.Data.Tables;
using EmilyLilyApi.Models;
using EmilyLilyApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmilyLilyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmilyLilyTableController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<EmilyLilyEarring>> Get([FromServices] TableServices _tableServices)
        {
            return await _tableServices.GetItems();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmilyLilyEarring>> GetId(string id, [FromServices] TableServices _tableServices)
        {
            var item = await _tableServices.GetItemId(id);

            if (item is null)
            {
                return NotFound();
            }

            return item;
        }

        [HttpPost]
        public async Task<ActionResult<EmilyLilyEarring>> Post(EmilyLilyEarring item, [FromServices] TableServices _tableServices)
        {
            await _tableServices.AddItemAsync(item);
            return CreatedAtAction(nameof(Post), new { id = item.RowKey }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, EmilyLilyEarring item, [FromServices] TableServices _tableServices)
        {
            if (id != item.RowKey)
            {
                return BadRequest();
            }

            var exisitingItem = await _tableServices.GetItemId(id);
            if (exisitingItem is null)
            {
                return NotFound();
            }
                       
            await _tableServices.UpdateItemAsync(item);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id, [FromServices] TableServices _tableServices)
        {
            var item = await _tableServices.GetItemId(id);

            if (item is null)
            {
                return NotFound();
            }

            await _tableServices.DeleteItemAsync(id);
            return NoContent();
        }
    }
}
