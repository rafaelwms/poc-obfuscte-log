namespace ObfuscateLogPoc.Domain.Obfuscate.Service;

public interface IObfuscationService
{
    string ObfuscateSensitiveData<T>(T input);
}