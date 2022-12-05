# Trabalho Interdisciplinar - Website FisioNorte
## Membros do grupo
```
Gabriel Afonso Casado Arrais 
Gabriel Bonil da Silva
Pedro Henrique Siqueira da Silva 
Vinicius Nishimoto Assakawa
```

# Passos para criação da aplicação
```
dotnet new web -o Server
dotnet add package Swashbuckle.AspNetCore --version 6.4.0 
```

# Primeira Instalação de Bibliotecas Utilizadas
## [Swagger](https://www.nuget.org/packages/Swashbuckle.AspNetCore)
Instale o pacote executando:
```console
dotnet add package Swashbuckle.AspNetCore --version 6.4.0
```

## [Entity Framework](https://www.nuget.org/packages/EntityFramework)
Para usar essa framework, primeiro instale a ferramenta
```console
dotnet tool install --global dotnet-ef 
```
Então, instale os pacotes necessários para o projeto
```
dotnet add package Microsoft.EntityFrameworkCore.Design  
dotnet add package Microsoft.EntityFrameworkCore.InMemory
```
### Criar `Migrations`
Para criar uma nova *`migration`* (alterações no banco de dados), execute no terminal:
```shell
dotnet ef migrations add "{NOME_DA_VERSAO_DA_MIGRACAO}"
```

### Atualizar o Banco de Dados
Para executar as últimas alterações feitas pelas *`migrations`* execute:
```shell
dotnet ef database update
```

### Visualizar Script
Para gerar o script da migração mais recente utilize o comando:
```shell
dotnet ef migrations script # Gerar no console
dotnet ef migrations script > script.sql # Gerar em um arquivo separado
```

## [SQL Server Entity Framework](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/)
Instale executando no shell:
```dotnet
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```

# Utilidades do `dotnet`
## Instalar Dependencias
Para instalar as dependencias use:
```console
dotnet restore
```

## Iniciar aplicação
Para iniciar a aplicação use:
```console
dotnet run 
```

## Reiniciar aplicação automaticamente
Para reiniciar a aplicação de maneira automatica toda vez que houver alterações no arquivo use:
```console
dotnet watch run
```

## Limpar compilação
Para limpar o cache e reiniciar completamente a aplicação use:
```console
dotnet clean
```

## Acessar Swagger UI
Acesse clicando em [`Swagger UI`](https://localhost:5105/swagger)
