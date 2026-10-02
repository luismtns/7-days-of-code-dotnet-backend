# Dia 3 — Dados, SQL e integração HTTP

**Entrega:** a API consulta um serviço local de dados sintéticos por `HttpClient` e agrega demanda por distrito.

## Ponte conceitual

O simulador em `MetroPulse.WarehouseSimulator` representa uma dependência externa e responde a `POST /queries` com `{ "name": "station-demand", "district": null }`. Ele contém apenas dados inventados. SQL usa parâmetros para separar valores de instruções. `HttpClientFactory` gerencia clientes e conexões; `CancellationToken` deve atravessar a chamada.

### Antes de praticar

- [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory): clientes nomeados ou tipados e gerenciamento de conexões.
- [Cancelamento](https://learn.microsoft.com/en-us/dotnet/standard/threading/cancellation-in-managed-threads): como uma solicitação interrompe trabalho em andamento.
- [Parâmetros e injeção de SQL](https://learn.microsoft.com/en-us/sql/relational-databases/security/sql-injection?view=sql-server-ver17): valores não devem ser concatenados à instrução.

Exemplo independente: o texto SQL define a estrutura da consulta; o valor é fornecido separadamente por um parâmetro. Para chamadas HTTP, passe o mesmo token recebido para que o cancelamento possa atravessar as camadas.

```csharp
const string sql = "SELECT title FROM books WHERE category = @category";
var response = await client.GetAsync("status", cancellationToken);
```

Execute `dotnet run --project src/MetroPulse.WarehouseSimulator` e envie uma requisição com `curl`. Observe a resposta para um distrito conhecido, um sem dados e um nome de consulta desconhecido.

## Desafio

1. Escreva uma consulta SQL parametrizada que calcule o total de viagens por distrito a partir de uma tabela hipotética `station_trips(station_id, district, trip_count)`. Guarde-a como recurso `.sql` no projeto de infraestrutura e descreva como ela seria carregada. Não concatene o valor do filtro.
2. Crie no projeto de infraestrutura um adaptador HTTP para o simulador. Configure URL base via Options e `HttpClientFactory`; não use URL fixa no adaptador.
3. Faça uma rota de demanda na API chamar o adaptador e devolver um DTO de resumo. Propague cancelamento; trate dependência indisponível como erro de serviço e ausência de linhas como coleção vazia.
4. Escreva testes com um `HttpMessageHandler` falso para sucesso, resposta não válida e timeout. Faça ao menos um teste que verifique o filtro enviado.

## Critérios de aceitação

- Com simulador ativo, o filtro `Centro` retorna as estações `ST-102` e `ST-104`, totalizando 350 viagens.
- Filtro sem correspondência retorna coleção vazia e total 0; nome de consulta inválido não vira sucesso silencioso.
- A URL é configurável, o cancelamento chega à chamada HTTP e nenhum segredo aparece em arquivo versionado.
- O SQL entregue é válido para a tabela descrita e usa parâmetro nomeado.

## Extensão avançada

Faça o simulador executar a consulta em SQLite em memória com dados sintéticos. Compare parâmetros SQL com a serialização do filtro HTTP. Para um provedor externo real, estude a [extensão Databricks](../extensions/01-databricks.md).
