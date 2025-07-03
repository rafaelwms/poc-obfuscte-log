using Microsoft.Extensions.Logging;

namespace ObfuscateLogPoc.Domain.Obfuscate.Service;

public class PayloadLoggerService : IPayloadLoggerService
{
    private readonly ILogger<PayloadLoggerService> _logger;
    private readonly IObfuscationService _obfuscationService;
    
    public PayloadLoggerService(ILogger<PayloadLoggerService> logger, IObfuscationService obfuscationService)
    {
        _logger = logger;
        _obfuscationService = obfuscationService;
    }
    
    public Task LogPayloadAsync<T>(T payload, bool isSensitive)
    {
        if(payload is null)
        {
            _logger.LogWarning("Payload is null.");
            return Task.CompletedTask;
        }
        
        if (isSensitive)
        {
            var obfuscatedPayload = _obfuscationService.ObfuscateSensitiveData(payload);
            _logger.LogInformation("Obfuscated Payload: {Payload}", obfuscatedPayload);
        }
        else
        {
            _logger.LogInformation("Payload: {Payload}", payload);
        }

        return Task.CompletedTask;
    }
}