# Desenvolvido por Igor Souza

Essa é uma API desenvolvida com o ASP.NET Core 6 Web API, junto com o EF.

## 🚀 Começando

Essas instruções permitirão que você obtenha uma cópia do projeto em operação na sua máquina local para fins de desenvolvimento e teste.

### 📋 Pré-requisitos

```
- Instancia do SQL Server 2022 para poder colocar na conection string do projeto.
- Ter a Lib do dotnet 6 instalada no computador e o ef também.

```

### 🔧 Instalação

```
- Na pasta do projeto, substitua a conection string do arquivo "appsettings.json" e coloque a sua conection string referente ao seu DB de testes
- Com o cmd aberto dentro da pasta do projeto execute o comando: "dotnet ef database update" sem as aspas para executar as migrations da API.
- Para rodar o projeto, no cmd execute o comando: "dotnet run". Coloquei uma porta fixa: "http://localhost:5543"

```

