namespace ObfuscateLogPoc.Domain.Obfuscate.Service;

public interface IPayloadLoggerService
{
    Task LogPayloadAsync<T>(T payload, bool isSensitive);
}