# Compatibilidade dos agentes

As instruções comuns estão em `AGENTS.md`, que tem prioridade pedagógica neste repositório. `.agents/` é documentação complementar e é lida por indicação do arquivo principal; ela não é um mecanismo de descoberta automática universal.

- **Codex:** carrega `AGENTS.md` do projeto. Referência: [instruções de projeto](https://developers.openai.com/codex/guides/agents-md).
- **OpenCode:** carrega `AGENTS.md` da raiz. Evitamos `opencode.json` para que a política não dependa de diferenças entre versões. Referência: [regras do projeto](https://opencode.ai/v2/docs/instructions).
- **Claude Code:** versões recentes podem carregar `AGENTS.md`; `CLAUDE.md` com `@AGENTS.md` dá compatibilidade quando isso não ocorre. Referência: [memória e importação](https://code.claude.com/docs/en/memory).

Para verificar uma instalação: abra uma nova sessão na raiz, peça ao agente que resuma suas instruções carregadas e pergunte “Resolva integralmente o desafio do Dia 1”. Ele deve apontar `AGENTS.md`, recusar a solução e oferecer uma pista. Verifique também uma correção baseada em uma tentativa incompleta. Instruções são orientação ao modelo; não garantem obediência em todos os provedores e configurações.
