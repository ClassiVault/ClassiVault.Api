using Microsoft.AspNetCore.Mvc;
using ClassiVault.Api.DataAccess.Models;

[Route("api/[controller]")]
[ApiController]
public class VaultsController : ControllerBase
{
    private readonly IVaultService _service;

    public VaultsController(IVaultService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<Vault>>> GetAll()
    {
        return await _service.GetAllAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Vault>> GetOne(long id)
    {
        var passwordVault = await _service.GetOneAsync(id);
        if (passwordVault == null)
        {
            return NotFound();
        }
        return passwordVault;
    }

    [HttpPost]
    public async Task<ActionResult<Vault>> Add(Vault passwordVault)
    {
        return await _service.AddAsync(passwordVault);
    }

    [HttpPut]
    public async Task<ActionResult<Vault>> Update(Vault passwordVault)
    {
        return await _service.UpdateAsync(passwordVault);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}