using Microsoft.AspNetCore.Mvc;
using ClassiVault.Api.DataAccess.Models;
using ClassiVault.Api.DataAccess.Services;

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
        var vaults = await _service.GetOneAsync(id);
        if (vaults == null)
        {
            return NotFound();
        }
        return vaults;
    }

    [HttpPost]
    public async Task<ActionResult<Vault>> Add(Vault vault)
    {
        return await _service.AddAsync(vault);
    }

    [HttpPut]
    public async Task<ActionResult<Vault>> Update(Vault vault)
    {
        return await _service.UpdateAsync(vault);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}