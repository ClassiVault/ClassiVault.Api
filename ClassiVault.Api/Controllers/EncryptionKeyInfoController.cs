using ClassiVault.Api.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class EncryptionKeyInfoController : ControllerBase
{
  private readonly IEncryptionKeyInfoService _service;

  public EncryptionKeyInfoController(IEncryptionKeyInfoService service)
  {
    _service = service;
  }

  [HttpGet]
  public async Task<ActionResult<List<EncryptionKeyInfo>>> GetAll()
  {
    return await _service.GetAllAsync();
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<EncryptionKeyInfo>> GetOne(long id)
  {
    var result = await _service.GetOneAsync(id);
    if (result == null)
    {
      return NotFound();
    }
    return result;
  }

  [HttpPost]
  public async Task<ActionResult<EncryptionKeyInfo>> Add(EncryptionKeyInfo encryptionKeyInfo)
  {
    return await _service.AddAsync(encryptionKeyInfo);
  }

  [HttpPut]
  public async Task<ActionResult<EncryptionKeyInfo>> Update(EncryptionKeyInfo encryptionKeyInfo)
  {
    return await _service.UpdateAsync(encryptionKeyInfo);
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(long id)
  {
    await _service.DeleteAsync(id);
    return NoContent();
  }
}