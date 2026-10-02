# Ambiente local

Requisitos: .NET SDK 10; editor com suporte a C#; Git. Docker Desktop ou Docker Engine é necessário para Redis e os laboratórios com contêineres. Nenhuma conta de nuvem é exigida.

```bash
dotnet --version
dotnet restore MetroPulse.slnx
dotnet build MetroPulse.slnx
dotnet test MetroPulse.slnx --filter 'Category!=Challenge'
dotnet run --project src/MetroPulse.Api
```

Em outro terminal, `curl http://localhost:5080/health/live` deve responder 200. O simulador de dados usa `dotnet run --project src/MetroPulse.WarehouseSimulator` e `http://localhost:5081`.

Para os Dias 5–7, inicie Redis com `docker compose -f compose.infrastructure.yaml up -d`. O serviço fica acessível apenas em `127.0.0.1:6379`. Ao terminar a sessão, use `docker compose -f compose.infrastructure.yaml down`.

Configuração segue o padrão .NET: `appsettings.json` guarda valores públicos; variáveis de ambiente usam `__` para separar seções; `dotnet user-secrets` guarda credenciais de laboratórios opcionais. Nunca coloque segredos em Git. O arquivo `appsettings.Development.json` também é ignorado.

Para comparar com Node.js: `dotnet restore` é a instalação de dependências NuGet; `dotnet build` compila e analisa; `dotnet run --project` executa um projeto; `.slnx` agrupa projetos; `CancellationToken` propaga cancelamento de uma operação assíncrona.

Se o restore falhar, confirme a versão do SDK e conectividade com `nuget.org`. Se a porta estiver ocupada, use `ASPNETCORE_URLS=http://localhost:5090 dotnet run --project src/MetroPulse.Api`. Se o Docker não estiver disponível, faça os Dias 1–4 e configure-o antes do Dia 5. Testes com contêineres só devem ser executados quando o daemon estiver ativo.

Em ambiente sem acesso à rede, o NuGet pode falhar ao consultar avisos de vulnerabilidade mesmo quando os pacotes já estão em cache. Apenas para uma verificação local temporária, use `dotnet restore MetroPulse.slnx -p:NuGetAudit=false`; o CI público mantém a auditoria padrão.
