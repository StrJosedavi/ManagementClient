# Projeto de API RESTful para Gerenciamento de Clientes

## Descrição

Este projeto é uma API RESTful desenvolvida em .NET 8 para o gerenciamento de clientes. A API permite realizar operações CRUD (Create, Read, Update, Delete) em clientes de dois tipos: Pessoa Física (PF) e Pessoa Jurídica (PJ). A autenticação básica é implementada para garantir o acesso seguro à API. O banco de dados utilizado é o PostgreSQL.

## Requisitos

- .NET 8
- PostgreSQL
- Ferramentas para teste de API (como Postman ou cURL)

## Instalação

1. **Clone o repositório**
   ```bash
   git clone https://github.com/StrJosedavi/ManagementClient.git

2. **Realize a migração da base de dados**
   ```base
   dotnet ef database update

## Estrutura de Dados

![Tabela Person](https://github.com/StrJosedavi/ManagementClient/assets/57737898/54a2eac9-4b61-4d25-b0ba-320fa0f5506d)

### Referências

https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli
https://learn.microsoft.com/pt-br/ef/core/get-started/overview/install
https://docs.automapper.org/en/stable/Configuration.html
https://learn.microsoft.com/pt-br/dotnet/core/extensions/dependency-injection
https://www.macoratti.net/11/10/net_pr1.htm
https://www.macoratti.net/16/01/net_uow1.htm
