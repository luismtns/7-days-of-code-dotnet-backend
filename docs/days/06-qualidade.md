# Dia 6 — Testes e observabilidade

**Entrega:** suíte útil e ambiente local observável, sem depender de serviços de produção.

## Ponte conceitual

Teste unitário isola uma regra; teste HTTP verifica binding e respostas; teste de integração verifica componentes reais; teste de arquitetura impede referências indevidas. Um teste não deve simplesmente reproduzir o código que testa. Logs estruturados, métricas e traces respondem perguntas diferentes sobre uma falha.

### Antes de praticar

- [Testes unitários com xUnit](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-csharp-with-xunit): estrutura de testes e asserções.
- [Testes de integração em ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-10.0): `WebApplicationFactory` e cliente HTTP de teste.
- [Health checks](https://learn.microsoft.com/en-us/aspnet/core/host-and-deploy/health-checks?view=aspnetcore-10.0), [logging](https://learn.microsoft.com/en-us/dotnet/core/extensions/logging) e [OpenTelemetry](https://learn.microsoft.com/en-us/dotnet/core/diagnostics/observability-with-otel): sinais complementares de operação.
- [Visão geral do Aspire](https://learn.microsoft.com/en-us/dotnet/aspire/get-started/aspire-overview): orquestração local de recursos.

Exemplo independente: um teste nomeia o comportamento esperado e verifica o resultado observável, sem depender de rede ou banco de dados.

```csharp
[Fact]
public void Add_ReturnsTheCombinedValue()
{
    (2 + 3).ShouldBe(5);
}
```

O projeto já mostra xUnit, Shouldly e `WebApplicationFactory`. Use NSubstitute para uma porta da aplicação, não para simular toda a aplicação.

## Desafio

1. Organize testes em cenários unitários, HTTP e integração. Cubra a linha feliz e ao menos três falhas relevantes dos dias anteriores.
2. Adicione um teste de arquitetura para a direção das dependências e um teste HTTP para o contrato de erro. Use Testcontainers para Redis **somente** nos testes que realmente precisam dele; pule ou documente a execução quando Docker não estiver disponível.
3. Adicione logs estruturados, correlation ID e health checks de liveness/readiness. Registre uma métrica de cache hit e um trace da chamada externa, sem campos sensíveis.
4. Monte um AppHost Aspire local que inicie API, simulador e Redis. Documente o comando e o que deve aparecer no painel.

## Critérios de aceitação

- `dotnet test MetroPulse.slnx --filter 'Category!=Challenge'` passa; os testes novos demonstram falha quando uma regra essencial é quebrada.
- Testes unitários não exigem Docker ou rede; os de integração declaram suas dependências.
- Uma chamada pode ser acompanhada por correlation ID de ponta a ponta; logs não incluem token ou dados pessoais.
- `/health/live` mostra processo ativo; readiness reflete dependências necessárias.

## Extensão avançada

Meça cobertura com `coverlet.collector`, acrescente teste de cancelamento com tempo virtual e compare OpenTelemetry com logs estruturados. Teste um cenário de recuperação do Redis.
