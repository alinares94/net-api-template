namespace $safeprojectname$.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StatusController : ControllerBase
{
    private readonly IStatusService _service;

    public StatusController(IStatusService service)
    {
        _service = service;
    }

    /// <summary>
    /// Obtiene el estado de la API
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _service.GetAsync());
    }
}
