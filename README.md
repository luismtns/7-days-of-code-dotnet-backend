# 7 Days of Code: Backend .NET

Construa o **MetroPulse**, uma API de indicadores de uma rede de mobilidade urbana inteiramente fictícia. Em sete entregas, você passa de C# básico a uma aplicação .NET 10 com HTTP, dados, arquitetura, segurança, cache, testes e operação. Cada dia termina com algo que você pode executar ou demonstrar.

O repositório é um ponto de partida, não um gabarito. Há código de infraestrutura e dados sintéticos para reduzir trabalho mecânico; a lógica dos desafios é sua. Uma IA pode atuar como professora e corrigir sua tentativa, seguindo [AGENTS.md](AGENTS.md).

## Comece aqui

1. Instale o [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0). Docker é necessário a partir do Dia 5; os Dias 1–4 não exigem conta externa.
2. Faça o [nivelamento](docs/nivelamento.md) antes do Dia 1. Salve respostas pessoais em `progress/`, que não é versionado.
3. Confira o ambiente com `dotnet restore MetroPulse.slnx`, `dotnet build MetroPulse.slnx` e `dotnet test MetroPulse.slnx --filter 'Category!=Challenge'`.
4. Siga os dias em ordem. Abra um agente na raiz do repositório e diga, por exemplo: “Estou no Dia 2, rota padrão. Tentei criar a rota e recebi este erro. Dê uma pista, sem resolver.”

| Dia | Entrega principal |
| --- | --- |
| [1](docs/days/01-csharp.md) | Resumo de viagens em C# |
| [2](docs/days/02-api.md) | API HTTP documentada |
| [3](docs/days/03-dados.md) | Integração com serviço de dados sintéticos |
| [4](docs/days/04-arquitetura.md) | Consulta em camadas e resposta de indicadores |
| [5](docs/days/05-robustez.md) | Autorização, cache e resiliência |
| [6](docs/days/06-qualidade.md) | Testes, observabilidade e Aspire |
| [7](docs/days/07-projeto-final.md) | Projeto final, container e CI |

O [mapa de conhecimentos](docs/mapa-de-conhecimentos.md) mostra fundamentos, assuntos avançados e extensões. A [configuração local](docs/ambiente.md) reúne comandos e solução de problemas.
As [leituras oficiais](docs/leituras.md) dão uma referência curta para cada etapa, sem substituir os exercícios.

## Como o repositório funciona

- `src/MetroPulse.Cli`: ponto de partida do Dia 1.
- `src/MetroPulse.Api`: host HTTP com uma rota de saúde e uma rota informativa.
- `src/MetroPulse.Application`: contratos e lógica a ser construída pelo aluno.
- `src/MetroPulse.Infrastructure`: espaço para adaptadores de dados e cache.
- `src/MetroPulse.WarehouseSimulator`: serviço local com dados sintéticos; é um auxiliar, não a resposta do Dia 3.
- `tests/MetroPulse.Tests`: testes de base e desafios opt-in. O CI inicial roda apenas a categoria `Foundation`.

Exercícios e critérios estão nos arquivos de cada dia. Use `dotnet test MetroPulse.slnx --filter 'Category=Challenge&Day=1'` para executar um desafio específico; ele deve falhar até você resolvê-lo. Os demais dias também pedem testes escritos por você, pois projetar testes faz parte do aprendizado.

## IA professora em várias ferramentas

`AGENTS.md` é a instrução comum. `.agents/` contém o protocolo de nivelamento, tutoria e correção. Codex e OpenCode leem `AGENTS.md` diretamente; `CLAUDE.md` importa o mesmo arquivo para compatibilidade com versões e configurações do Claude Code. As regras são instruções ao modelo, não uma barreira técnica: revise qualquer sugestão antes de aplicá-la.

## Dados e licença

Todo cenário e dado deste repositório é inventado. Não use credenciais, dados reais ou material de terceiros nos exercícios. O conteúdo e o código original estão sob [MIT](LICENSE).
