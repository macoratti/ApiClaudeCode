# API de Produtos - ASP.NET Core (.NET)

API RESTful desenvolvida com ASP.NET Core utilizando Minimal APIs, Entity Framework Core e SQLite para gerenciamento de produtos usando o Claude Code.

---

## 🚀 Tecnologias utilizadas

- .NET 8 / .NET 9
- ASP.NET Core Minimal APIs
- Entity Framework Core
- SQLite
- Swagger / OpenAPI
- Claude Code

---

## 📁 Estrutura do Projeto
```Text
ApiClaudeCode
│
├── CLAUDE.MD
├── Data
│ ├── AppDbContext.cs
│ └── Configurations/
│
├── Entities
│ ├── Produto.cs
│ └── ProdutoDto.cs
│
├── Endpoints
│ └── ProdutosEndpoints.cs
│
├── Program.cs
├── appsettings.json
└── produtos.db
---

## 📌 Funcionalidades

- ✅ Listar produtos
- ✅ Buscar produto por ID
- ✅ Criar produto
- ✅ Atualizar produto
- ✅ Remover produto
- ✅ Validação de regras de negócio

---

## 🔗 Endpoints

### 📍 Base URL

---
### 📥 GET - Listar todos

---
### 📥 GET - Buscar por ID

---
### 📤 POST - Criar produto
#### Exemplo de payload:

```json
{
  "nome": "Notebook",
  "preco": 3500,
  "estoque": 10
}

---
PUT /produtos/{id}
---
DELETE /produtos/{id}

## 🧠 Regras de negócio

A entidade **Produto** possui as seguintes validações:

- Nome é obrigatório  
- Preço deve ser maior que zero  
- Estoque não pode ser negativo  
---
## ⚙️ Configuração e execução

### 1. Clonar o repositório

```bash
git clone https://github.com/macoratti/ApiClaudeCode.git

