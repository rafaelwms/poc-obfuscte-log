using System.Reflection;
using System.Text.Json;
using Microsoft.Extensions.Compliance.Classification;
using Microsoft.Extensions.Compliance.Redaction;
using Microsoft.Extensions.Logging;
using ObfuscateLogPoc.Domain.Obfuscate.Atributes;

namespace ObfuscateLogPoc.Domain.Obfuscate.Service;

public class ObfuscationService : IObfuscationService
{
    private readonly ILogger<ObfuscationService> _logger;
    private readonly IRedactorProvider _redactorProvider;
    
    public ObfuscationService(ILogger<ObfuscationService> logger, IRedactorProvider redactorProvider)
    {
        _logger = logger;
        _redactorProvider = redactorProvider;
    }
    
    public string ObfuscateSensitiveData<T>(T input)
    {
        if (input == null)
            return string.Empty;
        
        var redactor = _redactorProvider.GetRedactor(new DataClassificationSet());
        
        var propertyValues = GetProcessedPropertyValues(input, redactor);
        
        return JsonSerializer.Serialize(propertyValues);
    }

    private static Dictionary<string, object?> GetProcessedPropertyValues<T>(T input, Microsoft.Extensions.Compliance.Redaction.Redactor redactor)
    {
        var propertyValues = new Dictionary<string, object?>();
        
        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (var property in properties)
        {
            var value = property.GetValue(input);
            
            
            var isSensitive = property.GetCustomAttributes<SensitiveDataAttribute>().Any();

            propertyValues[property.Name] = (isSensitive, value) switch
            {
                (true, string stringValue) => redactor.Redact(stringValue),
                (_, _) => value
            };
        }
        
        return propertyValues;
    }
}