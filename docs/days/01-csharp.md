# Dia 1 — C# aplicado a viagens

**Entrega:** um programa de terminal que recebe viagens sintéticas e imprime total de passageiros e total por estação. Tempo sugerido: 2–4 horas; rota Fundamentos: até 5 horas.

## Ponte conceitual

Em C#, `record` modela dados com igualdade por valor; `IEnumerable<T>` representa uma sequência; nulidade é explícita quando `Nullable` está ativo. Compare `map/filter/reduce` do JavaScript com `Select/Where/Aggregate` ou `Sum` do LINQ, observando que uma sequência LINQ pode ser avaliada apenas quando enumerada. Revise `int`, `string`, `DateTimeOffset`, métodos, exceções e `using`.

Aquecimento da rota Fundamentos: crie uma lista de três `Trip`, percorra-a com `foreach` e imprima `StationId` e `PassengerCount`. Depois explique o resultado para uma lista vazia e para uma contagem negativa.

## Desafio

1. Implemente `TripStatistics.TotalPassengers` em `MetroPulse.Application`. A entrada é uma sequência de `Trip`; o resultado é a soma de passageiros. Decida e documente como tratar `null` e contagens negativas.
2. Crie uma operação separada que agrupe viagens por `StationId` e retorne os totais em ordem de identificador. A assinatura é escolha sua; explique por que a escolheu.
3. Faça `MetroPulse.Cli` usar uma pequena amostra inventada, chamar as operações e imprimir um resumo legível. Não codifique os totais finais diretamente.

## Critérios de aceitação

- Sequência vazia resulta em total 0; a amostra do teste de desafio resulta em 7.
- O agrupamento inclui cada estação uma vez e conserva a soma total.
- Entrada inválida tem comportamento intencional e testado, sem falha silenciosa.
- `dotnet run --project src/MetroPulse.Cli` mostra resultados calculados; `dotnet test MetroPulse.slnx --filter 'Category=Challenge&Day=1'` passa.

## Extensão avançada

Aceite `CancellationToken` em uma versão assíncrona que lê viagens de `IAsyncEnumerable<Trip>`. Teste cancelamento e explique quando essa complexidade traz benefício. Experimente `checked` para detectar overflow na soma.

Ao pedir correção à IA, mostre seu código, a saída do CLI e o comando de teste. Peça uma pista por vez.
