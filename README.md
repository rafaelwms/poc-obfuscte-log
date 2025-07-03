# Obfuscate Log PoC 🤫

A Proof of Concept for elegant handling of sensitive data in logs using .NET Attributes.

---

## 🇬🇧 English Version

### Overview 🎯

This project is a Proof of Concept (PoC) that addresses a common and critical challenge in the software development lifecycle: logging sensitive data. Exposing Personally Identifiable Information (PII) or other confidential data in logs is a significant security risk.

This solution demonstrates an elegant, attribute-based approach to automatically obfuscate sensitive fields when objects are logged. Simply annotate a property with `[SensitiveData]`, and its value will be redacted, preventing accidental data exposure.

### ✨ Key Features

-   **🔐 Secure by Default:** Protects sensitive data from ending up in plain text logs.
-   **📝 Attribute-Driven:** Clean and declarative way to mark sensitive properties. No complex code required in your business logic.
-   **🔌 Easy to Integrate:** Designed to be easily plugged into existing .NET applications and logging pipelines.
-   **🚀 Lightweight & Focused:** A simple and effective solution for a very specific problem.

### How It Works ⚙️

The mechanism is straightforward:

1.  **`[SensitiveData]` Attribute:** A custom attribute used to decorate properties on your models (like the `Person` class in this PoC) that hold sensitive information.
2.  **Obfuscation Service:** A service that uses reflection to inspect an object.
3.  **Redaction Logic:** When the service finds a property marked with `[SensitiveData]`, it replaces the original value with a placeholder (e.g., `***`) before the object is serialized for logging.

This ensures that the data is redacted before it even reaches the logging framework.

### 🚀 Getting Started

Here’s how you can use it. First, define your model and add the `[SensitiveData]` attribute to the properties you want to protect.

**Example: `Person.cs`**

```csharp
public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }

    [SensitiveData]
    public string Email { get; set; }

    [SensitiveData]
    public string DocumentNumber { get; set; }
}
```

When an instance of `Person` is processed by the `PayloadLoggerService`, the sensitive fields are automatically obfuscated in the output log.

**Before Obfuscation:**

```json
{
  "Id": 1,
  "Name": "John Doe",
  "Email": "john.doe@example.com",
  "DocumentNumber": "123.456.789-00"
}
```

**After Obfuscation (in the log):**

```json
{
  "Id": 1,
  "Name": "John Doe",
  "Email": "***",
  "DocumentNumber": "***"
}
```

### 🛠️ Tech Stack

-   .NET
-   C#
-   ASP.NET Core

---

## 🇧🇷 Versão em Português do Brasil

### Visão Geral 🎯

Este projeto é uma Prova de Conceito (PoC) que aborda um desafio comum e crítico no ciclo de vida de desenvolvimento de software: o log de dados sensíveis. Expor Informações de Identificação Pessoal (PII) ou outros dados confidenciais em logs é um risco de segurança significativo.

Esta solução demonstra uma abordagem elegante e baseada em atributos para ofuscar automaticamente campos sensíveis quando objetos são registrados no log. Simplesmente anote uma propriedade com `[SensitiveData]`, e seu valor será redigido, prevenindo a exposição acidental de dados.

### ✨ Principais Funcionalidades

-   **🔐 Seguro por Padrão:** Protege dados sensíveis de aparecerem em texto puro nos logs.
-   **📝 Orientado a Atributos:** Uma forma limpa e declarativa de marcar propriedades sensíveis. Nenhum código complexo é necessário na sua lógica de negócio.
-   **🔌 Fácil de Integrar:** Projetado para ser facilmente conectado a aplicações .NET e pipelines de log existentes.
-   **🚀 Leve e Focado:** Uma solução simples e eficaz para um problema muito específico.

### Como Funciona ⚙️

O mecanismo é direto:

1.  **Atributo `[SensitiveData]`:** Um atributo customizado usado para decorar propriedades em seus modelos (como a classe `Person` nesta PoC) que contêm informações sensíveis.
2.  **Serviço de Ofuscação:** Um serviço que utiliza reflection para inspecionar um objeto.
3.  **Lógica de Redação:** Quando o serviço encontra uma propriedade marcada com `[SensitiveData]`, ele substitui o valor original por um placeholder (ex: `***`) antes que o objeto seja serializado para o log.

Isso garante que os dados sejam redigidos antes mesmo de chegarem ao framework de log.

### 🚀 Como Começar

Veja como você pode usá-lo. Primeiro, defina seu modelo e adicione o atributo `[SensitiveData]` às propriedades que deseja proteger.

**Exemplo: `Person.cs`**

```csharp
public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }

    [SensitiveData]
    public string Email { get; set; }

    [SensitiveData]
    public string DocumentNumber { get; set; }
}
```

Quando uma instância de `Person` é processada pelo `PayloadLoggerService`, os campos sensíveis são automaticamente ofuscados no log de saída.

**Antes da Ofuscação:**

```json
{
  "Id": 1,
  "Name": "Fulano de Tal",
  "Email": "fulano.tal@exemplo.com.br",
  "DocumentNumber": "123.456.789-00"
}
```

**Depois da Ofuscação (no log):**

```json
{
  "Id": 1,
  "Name": "Fulano de Tal",
  "Email": "***",
  "DocumentNumber": "***"
}
```

### 🛠️ Tecnologias Utilizadas

-   .NET
-   C#
-   ASP.NET Core
