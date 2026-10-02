# Dia 7 — Entrega de um serviço completo

**Entrega:** MetroPulse executável, documentado, testado e pronto para demonstração pública.

## Projeto realista

Uma equipe de mobilidade quer consultar demanda por distrito e indicadores agregados sem expor dados de usuários. O cliente precisa de uma API previsível; a equipe de operação precisa diagnosticar falhas e implantar o serviço. Toda informação neste exercício é sintética.

## Antes de praticar

- [Criar contêineres .NET](https://learn.microsoft.com/en-us/dotnet/core/docker/build-container): imagens multi-stage e execução de aplicações .NET em contêiner.
- [Configuração no .NET](https://learn.microsoft.com/en-us/dotnet/core/extensions/configuration): arquivos públicos, variáveis de ambiente e separadores `__`.
- [GitHub Actions para .NET](https://docs.github.com/en/actions/use-cases-and-examples/building-and-testing/building-and-testing-net): build e testes automatizados no CI.
- [OpenAPI em ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/openapi/overview?view=aspnetcore-10.0): documentação da interface que será demonstrada.

Exemplo independente de entrega: uma demonstração útil prova quatro comportamentos observáveis, como uma solicitação bem-sucedida, uma entrada rejeitada, uma solicitação sem permissão e uma falha externa tratada. Isso documenta o comportamento do serviço, não detalhes da sua implementação.

## Desafio

1. Feche as rotas, DTOs, validações e exemplos OpenAPI dos Dias 2–5. O endpoint de indicadores deve preservar o mesmo contrato em cache hit, cache miss e resposta vazia.
2. Crie um Dockerfile multi-stage para a API e uma composição local para API, simulador e Redis. Configure por variáveis de ambiente; nenhum segredo deve entrar na imagem.
3. Amplie o CI para build, testes unitários/HTTP e publicação de artefato de teste. Mantenha testes que exigem Docker em um job próprio ou execução manual documentada.
4. Escreva um README de portfólio com arquitetura, decisões, comandos, exemplos `curl`, limitações e próximos passos. Acrescente um diagrama simples da requisição até a fonte de dados.
5. Faça uma revisão final: segurança de cache, timeouts, testes que falham quando devem, dependências públicas, dados fictícios e ausência de credenciais.

## Critérios de aceitação

- Uma pessoa nova consegue clonar, restaurar, testar e executar o projeto seguindo o README.
- O projeto roda localmente sem conta cloud; a rota de demanda produz o total esperado para `Centro`.
- CI passa nos testes de base e nos desafios já resolvidos; testes de integração têm instrução clara.
- Container inicia como usuário sem privilégio e recebe configuração pelo ambiente.
- Demonstração inclui sucesso, entrada inválida, não autorizado e falha controlada da dependência.

## Depois dos sete dias

Escolha uma [extensão](../extensions/README.md) para aprofundar dados, cloud ou arquitetura. Revise as decisões com a IA professora, que deve avaliar sua implementação sem completá-la.
