# Nivelamento: antes do Dia 1

Reserve 30–45 minutos. O objetivo é escolher a quantidade de ponte conceitual, não eliminar dias. Todos entregam o mesmo projeto final. Copie suas respostas para `progress/meu-perfil.md` (diretório ignorado pelo Git) ou mantenha-as apenas em conversa.

Para cada área, atribua **0** se é nova; **1** se reconhece os conceitos; **2** se já resolveu problemas com eles; **3** se consegue explicar decisões e testar casos difíceis. Anote um exemplo real de trabalho ou estudo que sustente a nota.

| Área | Pergunta diagnóstica | Minha nota / evidência |
| --- | --- | --- |
| C# e tipos | Como `record`, nulidade e `IEnumerable<T>` afetam um programa? | |
| .NET e ferramentas | Consegue criar, compilar, depurar e testar uma solução com `dotnet`? | |
| HTTP e APIs | Sabe escolher verbos/status, validar entradas e explicar idempotência? | |
| SQL e dados | Consegue escrever agregações e parâmetros sem concatenar entrada do usuário? | |
| Assincronia e testes | Sabe usar `async`/`await`, cancelamento e teste unitário com dublê? | |
| Contêineres e operação | Consegue explicar variáveis de ambiente, Docker, logs e health checks? | |

Experiência com Node.js/TypeScript: **nenhuma / básica / prática / avançada**. Registre quais tópicos domina: event loop e `Promise`, Express/Fastify, injeção de dependências, testes, SQL, Docker. Use isso para fazer analogias, sem aumentar automaticamente sua nota em C#.

## Microdesafios para calibrar

Sem pedir solução à IA, escreva em até cinco linhas de raciocínio para cada pergunta: (1) como tratar um campo possivelmente nulo antes de somá-lo; (2) que resposta HTTP usar para uma entrada inválida; (3) por que `SELECT ... WHERE id = :id` com parâmetro é mais seguro que interpolação; (4) como testar uma falha de serviço externo sem chamar a rede. Se uma resposta não estiver clara, marque essa área como 0 ou 1.

## Escolha da rota

Some as seis notas (0–18): **0–6: Fundamentos**, **7–12: Padrão**, **13–18: Acelerada somente se C# ≥ 2**; com C# abaixo de 2, use a rota Padrão. Você pode escolher uma rota mais lenta. Nenhuma rota pula os critérios de aceitação dos dias.

- **Fundamentos:** leia as seções “Ponte” e faça os exercícios de aquecimento antes do desafio de cada dia; planeje 3–5 horas por dia.
- **Padrão:** leia a ponte apenas nas áreas com nota 0 ou 1; planeje 2–4 horas por dia.
- **Acelerada:** comece pelos desafios, consulte a teoria quando uma hipótese falhar e escolha ao menos uma extensão por dia; planeje 2–4 horas por dia.

Ao terminar cada dia, registre o que entregou, teste executado e uma dúvida pendente em `progress/`. Se duas sessões seguidas travarem no mesmo fundamento, volte à ponte daquela área. Peça à IA que corrija sua tentativa, não que produza a resposta.
