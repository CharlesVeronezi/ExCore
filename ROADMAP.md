# 🗺️ Roadmap - SagiCore

Este documento descreve o plano de desenvolvimento do projeto SagiCore, a migração do sistema legado xHarbour para . NET seguindo Clean Architecture e DDD.

---

## 📊 Status Geral

| Fase                                      | Status          | Progresso |
| ----------------------------------------- | --------------- | --------- |
| Estrutura inicial do projeto              | 🔄 Em Andamento | 70%       |
| Configuração Clean Architecture           | ✅ Concluído    | 100%      |
| Testes Unitários                          | ⏳ Pendente     | 0%        |
| Configuração das migrações                | ✅ Concluído    | 100%      |
| Primeira rota                             | ✅ Concluído    | 100%      |
| Rota real pedido de venda                 | 🔄 Em Andamento | 20%       |
| Config banco e injeção de dependencia     | ✅ Concluído    | 100%      |
| Criar estrutura de pastas por módulo      | 🔄 Em Andamento | 80%       |
| Atualizar namespaces e imports            | ⏳ Pendente     | 0%        |
| Docker Compose                            | ✅ Concluído    | 100%      |
| Adicionar Mapeamento (AutoMapper/Mapster) | ⏳ Pendente     | 0%        |
| Implementar Log                           | ⏳ Pendente     | 0%        |
| Implementar Autenticação                  | ⏳ Pendente     | 0%        |
| Implementar Multi-tenant                  | ⏳ Pendente     | 0%        |

**Legenda:** ✅ Concluído | 🔄 Em Andamento | ⏳ Pendente | ❌ Bloqueado

---

## 🎯 Estrutura Alvo

```
src/
├── Backend/
│   ├── SagiCore.API/
│   │   ├── Controllers/
│   │   │   ├── Cadastros/
│   │   │   │   ├── ProdutosController.cs
│   │   │   │   ├── ClientesController.cs
│   │   │   │   └── FornecedoresController.cs
│   │   │   ├── Operacional/
│   │   │   │   ├── PedidosController.cs
│   │   │   │   └── OrdensServicoController.cs
│   │   │   ├── Financeiro/
│   │   │   │   ├── ContasReceberController.cs
│   │   │   │   └── ContasPagarController.cs
│   │   │   └── Fiscal/
│   │   │       └── NotasFiscaisController.cs
│   │   └── Filters/
│   │
│   ├── SagiCore.Application/
│   │   └── UseCases/
│   │       ├── Cadastros/
│   │       │   ├── Produto/
│   │       │   │   ├── Registrar/
│   │       │   │   ├── Atualizar/
│   │       │   │   ├── Listar/
│   │       │   │   └── Buscar/
│   │       │   ├── Cliente/
│   │       │   └── Fornecedor/
│   │       ├── Operacional/
│   │       │   ├── PedidoVenda/
│   │       │   │   ├── Criar/
│   │       │   │   ├── Aprovar/
│   │       │   │   ├── Cancelar/
│   │       │   │   └── Listar/
│   │       │   └── OrdemServico/
│   │       ├── Financeiro/
│   │       │   ├── ContaReceber/
│   │       │   └── ContaPagar/
│   │       └── Fiscal/
│   │           └── NotaFiscal/
│   │
│   ├── SagiCore.Domain/
│   │   ├── Cadastros/
│   │   │   ├── Entities/
│   │   │   └── Repositories/
│   │   ├── Operacional/
│   │   │   ├── Entities/
│   │   │   └── Repositories/
│   │   ├── Financeiro/
│   │   │   ├── Entities/
│   │   │   └── Repositories/
│   │   ├── Fiscal/
│   │   │   ├── Entities/
│   │   │   └── Repositories/
│   │   └── Shared/
│   │
│   └── SagiCore.Infrastructure/
│       ├── DataAccess/
│       │   ├── Repositories/
│       │   │   ├── Cadastros/
│       │   │   ├── Operacional/
│       │   │   ├── Financeiro/
│       │   │   └── Fiscal/
│       │   └── Configurations/
│       └── Migrations/
│
├── Shared/
│   ├── SagiCore.Communication/
│   │   ├── Requests/
│   │   │   ├── Cadastros/
│   │   │   ├── Operacional/
│   │   │   └── Financeiro/
│   │   └── Responses/
│   │       ├── Cadastros/
│   │       ├── Operacional/
│   │       └── Financeiro/
│   └── SagiCore.Exceptions/
│
└── Tests/
    ├── SagiCore.Application.Tests/
    │   ├── Cadastros/
    │   ├── Operacional/
    │   └── Financeiro/
    └── SagiCore.Domain.Tests/
```

---
