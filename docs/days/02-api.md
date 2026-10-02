# Dia 2 — API HTTP com ASP.NET Core

**Entrega:** uma API de estações com documentação OpenAPI e tratamento claro de entradas inválidas.

## Ponte conceitual

Uma Minimal API associa método e rota a um delegate. `Results.Ok`, `Results.BadRequest` e `Results.NotFound` representam respostas HTTP; DTOs definem o JSON público. `WebApplicationBuilder` concentra configuração e injeção de dependências. Se conhece Express/Fastify, compare middleware e roteamento, mas observe o binding tipado e o ciclo de vida de serviços no .NET.

Aquecimento: execute a API, faça `curl -i http://localhost:5080/health/live` e explique status, cabeçalhos e corpo. Identifique onde `ASPNETCORE_URLS` e `appsettings.json` entram na configuração.

## Desafio

1. Crie `GET /api/v1/stations` e `GET /api/v1/stations/{id}` sobre quatro estações fictícias. Escolha DTOs públicos; não exponha estruturas internas diretamente.
2. Adicione filtro opcional `district` à listagem e valide valores em branco. Defina resposta 400 para filtro inválido e 404 para identificador inexistente.
3. Registre o serviço de leitura por DI, evitando dados fixos dentro do endpoint. Adicione OpenAPI e uma forma simples de inspecionar o contrato gerado; documente o comando usado.
4. Escreva ao menos um teste HTTP para o caso de 404 e outro para filtro inválido.

## Critérios de aceitação

- `GET /api/v1/stations` retorna JSON e 200; o teste de desafio do Dia 2 passa.
- O filtro altera a coleção sem mudar seus registros originais.
- Uma estação inexistente retorna 404; filtro em branco retorna 400 com mensagem útil.
- O documento OpenAPI descreve as rotas e os códigos de resposta. A API continua respondendo em `/health/live`.

## Extensão avançada

Use Options com validação no startup para uma configuração pública, adicione middleware de erro consistente e compare `ProblemDetails` com respostas ad hoc. Explique lifetimes `Singleton`, `Scoped` e `Transient` usando o serviço criado.
