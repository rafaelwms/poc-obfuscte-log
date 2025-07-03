using ObfuscateLogPoc.Domain.Obfuscate.Atributes;

namespace ObfuscateLogPoc.Domain.Entities;

public class Person
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [SensitiveData]
    public string Email { get; set; }
    [SensitiveData]
    public string DocumentNumber { get; set; }
}