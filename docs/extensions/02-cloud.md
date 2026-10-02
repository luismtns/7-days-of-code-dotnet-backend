# Laboratório opcional: persistência e infraestrutura

Escolha uma ou mais tarefas, sempre com contas e dados próprios:

1. **PostgreSQL + EF Core:** adicione um recurso transacional separado para cadastrar estações fictícias. Defina migração, índice, concorrência e teste com Testcontainers. Mantenha a leitura analítica desacoplada do cadastro.
2. **Azure App Configuration e Key Vault:** mova configurações públicas e segredos para provedores apropriados. Mantenha fallback local e teste o comportamento quando a configuração remota estiver indisponível.
3. **Mensageria:** publique um evento fictício de atualização de estação em um broker local ou serviço cloud próprio. Defina idempotência, retries e dead-letter; teste o consumidor sem chamar cloud na CI pública.
4. **Armazenamento de objetos:** guarde um pequeno arquivo sintético de exportação, com expiração e permissão mínima. Não coloque dados pessoais nos exemplos.

Ao concluir, documente custo potencial, limpeza de recursos criados, segurança de credenciais e um teste automatizado representativo. Estes recursos não são necessários para completar os sete dias.
