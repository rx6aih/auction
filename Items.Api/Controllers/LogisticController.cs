namespace Items.Api.Controllers;

[ApiController]
[Route("/api/items/logistic")]
public class LogisticController : ControllerBase
{
    private readonly IItemsService _itemsService;
    
    public LogisticController(IItemsService itemsService)
    {
        _itemsService = itemsService;    
    }

    public async Task<ActionResult> CreateItemAsync(Item item)
    {
        try
        {
            await _itemsService.CreateItemAsync(item);
            return Ok("Предмет успешно создан.");
        }
        catch (ArgumentException e)
        {
            return BadRequest(e.Message);
        }
    }
    
    public async Task<ActionResult<List<Item>>> GetAllItemsAsync() => Ok(await _itemsService.GetAllItemsAsync());

    public async Task<ActionResult<Item>> GetItemByIdAsync([FromQuery] int id) => Ok(await _itemsService.GetItemByIdAsync(id));

    public async Task<ActionResult<Item>> GetItemByNameAsync([FromQuery] string name) => Ok(await _itemsService.GetItemByNameAsync(name));

    public async Task<ActionResult> UpdateItemAsync([FromBody] Item item)
    {
        try
        {
            await _itemsService.UpdateItemAsync(item);
            return Ok("Предмет успешно обновлён.");
        }
        catch (ArgumentException e)
        {
            return BadRequest(e.Message);
        }
    }

    public async Task<ActionResult> DeleteItemByIdAsync(int id)
    {
        try
        {
            await _itemsService.DeleteItemAsync(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}