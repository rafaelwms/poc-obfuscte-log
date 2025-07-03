using Microsoft.AspNetCore.Mvc;
using ObfuscateLogPoc.Domain.Entities;
using ObfuscateLogPoc.Domain.Obfuscate.Service;

namespace WebObfuscateLog.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ObsfucateLogController : ControllerBase
{

    private readonly IPayloadLoggerService _payloadLoggerService;

    public ObsfucateLogController(IPayloadLoggerService payloadLoggerService)
    {
        _payloadLoggerService = payloadLoggerService;
    }

    [HttpPost]
    public IActionResult LogPerson(Person person)
    {
        _payloadLoggerService.LogPayloadAsync(person, true);
            
        return Ok(person);
    }
}