# Dia 5 — Segurança, cache e resiliência

**Entrega:** indicadores protegidos por identidade fictícia, cacheados de forma correta e resistentes a falhas temporárias.

## Ponte conceitual

Autenticação identifica quem chama; autorização decide o que essa identidade pode ler. Um JWT deve ser validado, não apenas decodificado. Cache precisa de chave que represente todos os filtros e o escopo do usuário; TTL limita a idade da resposta. Retry só faz sentido para falhas transitórias e operações seguras; timeout e circuit breaker limitam impacto de uma dependência instável.

### Antes de praticar

- [Autenticação JWT Bearer](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/configure-jwt-bearer-authentication?view=aspnetcore-10.0): validação de token e proteção de rotas.
- [Cache distribuído](https://learn.microsoft.com/en-us/aspnet/core/performance/caching/distributed?view=aspnetcore-10.0): uso de `IDistributedCache` e expiração.
- [Resiliência no .NET](https://learn.microsoft.com/en-us/dotnet/core/resilience/): timeout, retry e circuit breaker para dependências externas.

Exemplo independente: a chave de cache precisa identificar tanto o filtro quanto o chamador. Assim, uma resposta privada não é reutilizada por outra pessoa.

```csharp
var cacheKey = $"catalog:{category}:{userId}";
```

Para começar, instale Docker e execute `docker compose -f compose.infrastructure.yaml up -d` na raiz (veja a [configuração](../ambiente.md)). Use valores de desenvolvimento inventados para emissor/audiência/chave de teste e mantenha a chave fora do Git.

## Desafio

1. Proteja `GET /api/v1/indicators/demand` com JWT validado. Uma claim `districts` com distritos permitidos restringe o filtro solicitado; acesso fora do escopo retorna 403. Documente como emitir um token **somente de teste**.
2. Adicione cache em memória e Redis com TTLs configuráveis. A chave inclui filtro normalizado e escopo da identidade. Não compartilhe resultado de um usuário com outro.
3. Adicione timeout e uma política de resiliência para a chamada ao simulador. Propague cancelamento do cliente e diferencie falha externa de entrada inválida.
4. Escreva testes para 401, 403, isolamento de cache, hit/miss, expiração e timeout. Use tempo controlável ou TTL curto apenas nos testes.

## Critérios de aceitação

- Sem token: 401; token válido fora do escopo: 403; token válido autorizado: 200.
- Duas chamadas idênticas autorizadas aproveitam cache; mudar distrito ou identidade não reaproveita resposta indevidamente.
- Com simulador indisponível, a API falha em tempo limitado e registra a dependência afetada sem expor segredos.
- Desligar Redis não quebra a rota de saúde básica; readiness indica indisponibilidade quando Redis é obrigatório.

## Extensão avançada

Compare cache L1/L2, invalidação por tag e comportamento concorrente. Acrescente circuit breaker e meça sua abertura/recuperação. Avalie os riscos de cachear respostas autenticadas.
