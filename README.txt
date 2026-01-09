# Guia de Arquitetura e Desenvolvimento - SagiCore

Este documento descreve a estrutura arquitetural do projeto, as motivações por trás das decisões técnicas e um guia passo-a-passo para a criação de novas funcionalidades.

---

## 1. Visão Geral da Arquitetura

O projeto segue os princípios da **Clean Architecture**, separando as responsabilidades em camadas distintas para garantir desacoplamento e testabilidade.

### Estrutura das Camadas

*   **src/Backend/SagiCore.API (Camada de Apresentação)**
    *   **Responsabilidade:** Lidar com requisições HTTP, validação de entrada (formato), orquestração de dependências e retorno de respostas padronizadas. Não contém regras de negócio complexas.
*   **src/Backend/SagiCore.Application (Camada de Aplicação)**
    *   **Responsabilidade:** Orquestra o fluxo de dados. Recebe uma requisição, aplica regras de negócio, chama repositórios e devolve uma resposta. É isolada de detalhes externos (como banco de dados ou UI).
*   **src/Backend/SagiCore.Domain (Camada de Domínio)**
    *   **Responsabilidade:** Define as Entidades (como `Produto`), Regras de Negócio Core e as Interfaces (Contratos) que a infraestrutura deve implementar. Esta camada não depende de NINGUÉM.
*   **src/Backend/SagiCore.Infrastructure (Camada de Infraestrutura)**
    *   **Responsabilidade:** Implementar as interfaces do Domínio. Aqui reside o Entity Framework, acesso a disco, envio de e-mails, etc.
*   **src/Shared (Compartilhado)**
    *   **Responsabilidade:** Contém DTOs (Requests/Responses), Exceções personalizadas e recursos que trafegam entre as camadas sem violar a arquitetura.

---

## 2. Pq da estrutura

1.  **Independência de Frameworks:** O "coração" (Domínio) não sabe que existe Web API ou Postgres. Isso permite trocar o banco de dados ou a interface web com impacto mínimo nas regras de negócio.
2.  **Testabilidade:** A injeção de dependência e o uso de interfaces (ex: `IProdutoWriteRepository`) permitem criar Mocks facilmente. Podemos testar o `RegistrarProdutoUseCase` sem precisar de um banco de dados real rodando (excelente para a pasta `tests` que ficará ao lado da `src`).
3.  **SRP:** Cada `UseCase` faz apenas uma coisa (ex: RegistrarProduto). Isso evita aquelas classes "Service" gigantescas.
4.  **Segurança e Consistência:** O uso do padrão **UnitOfWork** (`_unitOfWork.Commit()`) garante que todas as operações no banco sejam salvas em uma única transação ou nenhuma seja.

---

## 3. Implementado

### Injeção de Dependência
Criei métodos de extensão para organizar a injeção de dependência por camada, mantendo o `Program.cs` limpo.
*   **Application**: `DependencyInjectionExtension.AddApplication()` registra os UseCases (ex: `RegistrarProdutoUseCase`).
*   **Infrastructure**: `DependencyInjectionExtension.AddInfrastructure()` registra o `DbContext` e os Repositórios.

### Banco de Dados & Entity Framework
*   **ORM**: Entity Framework Core.
*   **Provedor**: PostgreSQL (`UseNpgsql`).
*   **Contexto**: `SagiCoreDbContext` configurado para aplicar configurações de mapeamento via `ApplyConfigurationsFromAssembly`.
*   **Repositórios**: Implementação segregada em `Read` e `Write` para otimização, além do padrão **UnitOfWork** para transações atômicas.

### Tratamento de Exceções
*   **Filtros**: Um `ExceptionFilter` global intercepta exceções não tratadas e exceções de domínio (`SagiCoreException`), retornando respostas JSON padronizadas com os erros.

### Próximos:
**Migrations (Banco de Dados)**
**Autenticação JWT (JSON Web Token)**

---

## 4. Como criar um novo Endpoint

*Passo a passo para adicionar uma nova funcionalidade (ex: Atualizar Produto).*

### Passo 1: Defina os Contratos (Shared)
Vá em `SagiCore.Communication`. Crie as classes que definem o que entra e o que sai da API.
*   Crie `RequestAtualizarProdutoJson.cs` (Entrada).
*   Crie `ResponseProdutoAtualizadoJson.cs` (Saída, se houver).

### Passo 2: Defina a Interface do Repositório (Domain)
Se precisar de uma nova operação no banco, defina o contrato primeiro.
*   Vá em `Domain/Repositories/IProdutoWriteRepository.cs`.
*   Adicione: `Task Update(Produto produto);`

### Passo 3: Implemente a Infraestrutura (Infrastructure)
Agora ensine o sistema a realizar a operação no banco.
*   Vá em `Infrastructure/DataAccess/Repositories/ProdutoRepository.cs`.
*   Implemente o método `Update` usando o `_dbcontext`.

### Passo 4: Crie o Caso de Uso (Application) **(O passo mais importante)**
*   Vá em `Application/UseCases/Produto`. Crie a pasta `Atualizar`.
*   Crie a interface `IAtualizarProdutoUseCase.cs`.
*   Crie a classe `AtualizarProdutoUseCase.cs` implementando a interface.
    *   Injete `IProdutoWriteRepository` e `IUnitOfWork`.
    *   Lógica: Validar Request -> Buscar Produto (Repo) -> Atualizar campos -> Repo.Update() -> UnitOfWork.Commit().

### Passo 5: Registre a Dependência (Application)
Para que o sistema "conheça" sua nova classe.
*   Vá em `Itau.Application/DependencyInjectionExtension.cs` (ou similar).
*   Adicione: `services.AddScoped<IAtualizarProdutoUseCase, AtualizarProdutoUseCase>();`

### Passo 6: Crie o Endpoint (API)
*   Vá em `API/Controllers/ProdutosController.cs`.
*   Crie o método HTTP (PUT/PATCH).
*   Injete o `IAtualizarProdutoUseCase` no método ou construtor.
*   Chame o `.Executar()` e retorne o Status Code adequado.

### Passo 7: Testes
*   Na pasta de testes, crie um teste unitário para o seu UseCase, garantindo que a lógica funciona independente do banco de dados.

---