# Projeto de API RESTful para Gerenciamento de Clientes

## Descrição

Este projeto é uma API RESTful desenvolvida em .NET 8 para o gerenciamento de clientes. A API permite realizar operações CRUD (Create, Read, Update, Delete) em clientes de dois tipos: Pessoa Física (PF) e Pessoa Jurídica (PJ). A autenticação básica é implementada para garantir o acesso seguro à API. O banco de dados utilizado é o PostgreSQL.

## Requisitos

- .NET 8
- PostgreSQL
- Ferramentas para teste de API (como Postman ou cURL)

## Instalação e configuração

1. **Clone o repositório**
   ```bash
   git clone https://github.com/StrJosedavi/ManagementClient.git

2. **Realize a migração da base de dados**
   ```bash
   dotnet ef database update
   
3. **Realize a configuração do appSettings**

   3.1 - Defina as configurações de string de conexão
   ```json
   "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=5432;Database=name-database;User Id=postgres;Password=password;"
   },
   ```
   
   3.2 - Defina as configurações do Jwt de autenticação
      ```json
      "JwtSettings": {
          "SecretKey": "secret-key-value",
          "TokenExpiration": 6
      }
      ```

## Estrutura de Dados

### Tabela Person
![Tabela Person](https://github.com/StrJosedavi/ManagementClient/assets/57737898/54a2eac9-4b61-4d25-b0ba-320fa0f5506d)

#### Tabela UserAdmin
![Tabela UserAdmin](https://github.com/StrJosedavi/ManagementClient/assets/57737898/11ff839f-c18f-481f-8a13-4453254235da)

## Arquitetura utilizada

Modelo Model-View-Controller

![image](https://github.com/StrJosedavi/ManagementClient/assets/57737898/48a7b832-431c-4fb8-ae49-4b7d2bf355b0)

obs:. A view foi escrita em uma outra linguagem, em um repositório separado, esse projeto contemplará somente Model e Controller 
### - Padrões Utilizados 

UnitOfWork e Repository Pattern

![image](https://github.com/StrJosedavi/ManagementClient/assets/57737898/fa2eefdb-9fb7-4ae4-8441-45b05c7f5149)

### Referências

https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli
https://learn.microsoft.com/pt-br/ef/core/get-started/overview/install
https://docs.automapper.org/en/stable/Configuration.html
https://learn.microsoft.com/pt-br/dotnet/core/extensions/dependency-injection
https://www.macoratti.net/11/10/net_pr1.htm
https://www.macoratti.net/16/01/net_uow1.htm
