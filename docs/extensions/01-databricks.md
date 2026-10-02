# Laboratório opcional: Databricks SQL por HTTP

Use somente um workspace e dados que você controla. O laboratório não traz endpoint, tabela, token ou amostra de terceiros.

1. Leia a documentação pública da Statement Execution API e desenhe o ciclo de envio, espera, polling e resultado. Liste limites de tempo e tamanho que precisa tratar.
2. Crie uma tabela sintética de demanda em seu próprio catálogo. Adapte a porta de leitura do MetroPulse para usar a API REST oficial com SQL parametrizado; mantenha o simulador para testes locais.
3. Guarde credenciais em `dotnet user-secrets` ou variáveis de ambiente locais. Não registre token, SQL com segredos ou linhas reais em logs.
4. Teste mapeamento de linhas, resultado vazio, consulta lenta, erro de autenticação e cancelamento usando um servidor HTTP falso. Um teste end-to-end com seu workspace é opcional e deve ser isolado da CI pública.

Critério de conclusão: alternar entre simulador e sua implementação por configuração, sem mudar contrato HTTP público. Consulte a [documentação oficial da API](https://learn.microsoft.com/en-us/azure/databricks/dev-tools/sql-execution-tutorial) para o formato atual antes de programar.
