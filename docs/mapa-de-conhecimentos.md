# Mapa de conhecimentos

O curso prioriza padrões de um backend moderno de consultas em .NET 10. “Cobrir” significa praticar o conceito em um exercício ou extensão; sete dias não substituem experiência de produção.

| Tema | Fundamento | Prática principal | Avançado / extensão |
| --- | --- | --- | --- |
| C# | tipos, controle de fluxo, records, nulidade, coleções | LINQ, interfaces, exceções, `async`/`await` | imutabilidade, genéricos, `CancellationToken`, `IAsyncEnumerable` |
| .NET | SDK, CLI, solução, projetos, NuGet | configuração, DI, Options, logging | analisadores, configuração por ambiente, publicação |
| HTTP | métodos, status, JSON | Minimal APIs, validação, OpenAPI, erros | versionamento, autenticação JWT, autorização por escopo |
| Arquitetura | responsabilidade por camada | DTO, query/handler, portas/adaptadores, resultado | CQRS de leitura, decorators, formatação reutilizável |
| Dados | SQL, agregação, parâmetros | arquivo SQL, mapeamento, `HttpClient` para serviço externo | paginação, consistência, [Databricks opcional](extensions/01-databricks.md) |
| Estado | cache em memória | Redis, TTL, chaves por filtro/usuário | invalidação, falhas, múltiplas camadas |
| Resiliência | timeout e cancelamento | retry criterioso, circuit breaker | telemetria de dependências, limites |
| Qualidade | asserts e casos de borda | xUnit, NSubstitute, Shouldly, testes HTTP | Testcontainers, testes de arquitetura, cobertura |
| Operação | configuração e segredos locais | health checks, logs estruturados, Docker | Aspire, OpenTelemetry, CI, [Azure opcional](extensions/02-cloud.md) |

O ecossistema real também pode conter PostgreSQL/EF Core, mensageria e armazenamento de objetos. Essas tecnologias aparecem nas [extensões](extensions/README.md), pois não são pré-requisito para o caminho de consultas do projeto final.
