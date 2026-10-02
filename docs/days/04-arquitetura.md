# Dia 4 — Consultas em camadas

**Entrega:** um endpoint de indicadores que usa query, handler, adaptador e formatação reutilizável.

## Ponte conceitual

Organize dependências em uma direção: API conhece aplicação e infraestrutura; infraestrutura implementa contratos da aplicação; aplicação não conhece detalhes HTTP nem cliente externo. CQRS aqui significa separar o modelo de leitura e sua orquestração, sem exigir uma biblioteca de mediator ou um modelo de escrita. DTOs protegem o contrato público.

Revise `interface`, `record`, genéricos e DI. Trace uma requisição existente da entrada HTTP até o resultado; desenhe esse caminho em `progress/`.

## Desafio

1. Defina na aplicação uma query de demanda com filtro e um handler que dependa de uma porta de leitura. Mova a lógica de soma/agregação para a aplicação.
2. Mantenha o adaptador HTTP do Dia 3 na infraestrutura e registre-o na API. O endpoint deve apenas validar/bindar, chamar o handler e converter o resultado para HTTP.
3. Crie dois formatadores reutilizáveis: uma série por estação e um cartão com total e período fictício. Ambos usam o mesmo conjunto de linhas recebido, sem repetir consulta externa.
4. Adicione um endpoint `GET /api/v1/indicators/demand` que entregue ambos os formatos num único JSON. Documente o shape escolhido e os casos sem dados.

## Critérios de aceitação

- A aplicação compila sem referência à API ou à infraestrutura; a infraestrutura referencia somente a aplicação.
- Uma requisição produz uma chamada ao adaptador e dois formatos coerentes com as mesmas linhas.
- Resposta sem dados mantém um shape estável e não inventa valores.
- Testes unitários do handler usam uma porta falsa; testes dos formatadores cobrem ordem e valor dos itens.

## Extensão avançada

Adicione uma composição de filtros reutilizáveis (distritos disponíveis e período), com cache por usuário quando houver identidade. Crie teste de arquitetura que falhe se aplicação passar a depender de infraestrutura. Compare um `Result<T>` explícito com exceções para erros esperados.
