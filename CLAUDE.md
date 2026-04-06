# 📌 Projeto: API de Produtos

## 🎯 Objetivo

Criar e manter uma Web API em ASP.NET Core para gerenciar produtos.

Produto possui:
- Id (int)
- Nome (string)
- Preco (decimal)
- Estoque (int)

---

## 🧱 Tecnologias

- .NET
- ASP.NET Core Web API
- Entity Framework Core
- SQLite
- Minimal APIs

---

## 🧠 Diretrizes

- Código deve ser simples e organizado
- Usar async/await
- Evitar complexidade desnecessária

---

## 🏗️ Organização

O projeto deve ser organizado em pastas:

- Entities
- Data
- Endpoints

---

## 📦 Domínio

As entidades devem:
- Ter validações básicas
- Representar regras de negócio

---

## 💾 Persistência

- Usar EF Core com SQLite
- Configurar DbContext corretamente
- Usar EF Core com Fluent API para mapear entidades
- Não usar Data Annotations
- Definir propriedades obrigatórias e tamanhos de campos via Fluent API

---

## Program Configuration

- Instalar o pacote Microsoft.AspNetCore.OpenApi caso não esteja presente
- Instalar o pacote Swashbucle.AspNetCore.SwaggerUI no projeto
- **Configurar em `Program.cs` (Development only):**
```csharp
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "<ApiName> API V1");
    });
```
- <ApiName> deve ser substituida com o nome atual da API do projeto

## LaunchSettings

- **Regra obrigatória:** o perfil ativo em `Properties/launchSettings.json` deve conter as seguintes configurações:
```json
"launchBrowser": true,
"launchUrl": "swagger"
```
## Mapeamento e Seed das Entidades

- O mapeamento das entidades deve ser feito usando Fluent API
- Não definir o mapeamento no método OnModelCreating
- Criar uma classe de configuração com sufixo `Configuration` na pasta `Configurations`
- A classe deve implementar `IEntityTypeConfiguration<Entidade>`

- O seed de dados deve ser definido usando `HasData(...)` dentro da classe de configuração
- Cada entidade deve possuir exatamente 3 registros no seed

- Os dados do seed devem:
  - Utilizar valores fixos e explícitos
  - Definir o campo Id manualmente
  - Não utilizar valores dinâmicos ou aleatórios

---

## 🔌 Endpoints

Criar endpoints:

GET /produtos  
GET /produtos/{id}  
POST /produtos  
PUT /produtos/{id}  
DELETE /produtos/{id}

---
## ⚙️ Regras

O assistente DEVE:

- Organizar os arquivos nas pastas corretas
- Não misturar lógica de domínio com endpoints
- Usar injeção de dependência

---
## 🚫 Evitar

- Código desorganizado
- Lógica de negócio nos endpoints