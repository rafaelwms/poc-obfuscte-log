using Microsoft.Extensions.Compliance.Classification;
using Microsoft.Extensions.Compliance.Redaction;

namespace ObfuscateLogPoc.Domain.Obfuscate.Redactor;

public class ObfuscateLogRedactorProvider : IRedactorProvider
{
    private class SimpleRedactor : Microsoft.Extensions.Compliance.Redaction.Redactor
    {
        public override int Redact(ReadOnlySpan<char> source, Span<char> destination)
        {
            throw new NotImplementedException();
        }

        public override string Redact(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return "[REDACTED]";
        }

        public override int GetRedactedLength(ReadOnlySpan<char> input) => input.Length;
    }
    public Microsoft.Extensions.Compliance.Redaction.Redactor GetRedactor(DataClassificationSet classifications)
    {
        return new SimpleRedactor();
    }
}