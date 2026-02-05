# SagiCore (ExCore)

Sistema construído com arquitetura **Monólito Modular**, organizado em **Vertical Slices** e fundamentado nos princípios do **Domain-Driven Design (DDD)**.

## Arquitetura

### Monólito Modular

O sistema é dividido em módulos de negócio independentes (ex: `Auth`, `Cadastros`, `Operacional`). Cada módulo possui sua própria lógica, dados e regras, mantendo alto nível de isolamento.

**Vantagem:** Facilita a manutenção e permite que módulos específicos sejam extraídos para microsserviços no futuro sem necessidade de reescrever o sistema inteiro.

### Vertical Slices

Ao invés da arquitetura em camadas tradicional, o código é agrupado por **funcionalidade**. Cada caso de uso (ex: `RegisterProduto`) contém seu Handler, Request, Validator e Mapper em um único contexto.

## Domain-Driven Design (DDD)

O projeto segue as divisões de camadas do DDD:

- **Domain (Núcleo):** Entidades, Value Objects e interfaces dos Repositórios. Camada pura, sem dependências de frameworks externos
- **Application:** Orquestra os fluxos de negócio através de Use Cases, coordenando domínio e infraestrutura
- **Infrastructure:** Implementações técnicas (EF Core, criptografia, provedores de token)
- **Shared Kernel:** Abstrações e utilitários compartilhados entre módulos (notificações, multi-tenancy)

## Segurança e Autenticação

### JWT (JSON Web Tokens)

Autenticação baseada em JWT para comunicação stateless e segura.

**Geração do Token:**
- No login, o sistema gera um token contendo Claims do usuário, incluindo o `IdEmpresa` (crucial para roteamento de banco de dados)
- O `TokenProvider` assina o token com chave secreta, garantindo integridade

**Validação e Roteamento:**
1. Middleware do ASP.NET Core valida assinatura e expiração do token
2. `UserContext` extrai o `IdEmpresa` das Claims
3. `TenantService` usa este ID para determinar qual banco de dados executar a operação

## Performance e Caching

Sistema utiliza **Caching em Memória (`IMemoryCache`)** para otimizar o tempo de resposta em ambiente multi-tenant.

### Otimização de Conexões

- **Banco Central:** `AUTENTICA` armazena as strings de conexão de cada cliente
- **Problema:** Consultar `AUTENTICA` em toda requisição geraria gargalo de performance
- **Solução:** `TenantService` busca string de conexão no cache. Se não encontrar, consulta `AUTENTICA`, armazena no cache e utiliza
- **Resultado:** Redução drástica na latência e carga sobre o banco de autenticação

## Gestão de Dados e Migrações

Gerenciamento centralizado no projeto **SagiCore.DbMigrator**.

### FluentMigrator

Utiliza **FluentMigrator** ao invés das migrações padrão do EF Core, permitindo:
- Migrações mais flexíveis em C# ou SQL puro
- Independência do mapeamento de classes do ORM

### Migração Multi-tenancy

O Console App do Migrator:
1. Lê todos os bancos de dados ativos
2. Itera sobre cada conexão
3. Aplica versões pendentes sequencialmente
4. Garante que todos os clientes estejam na mesma versão do esquema

## Comunicação e Tratamento de Erros

- **Padrão de Respostas:** Todas as respostas da API seguem formato padronizado (ex: `ResponseErrorJson`)
- **Tratamento Global:** Utiliza `ExceptionFilters` que capturam erros de validação (FluentValidation) e erros de domínio, transformando-os em respostas HTTP apropriadas (400, 401, etc.)

---

## Trilha

- [🗺️ Roadmap do Projeto](ROADMAP.md)

---

## Tutorial

- [Tutorial novo Endpoint](ENDPOINT.md)

---