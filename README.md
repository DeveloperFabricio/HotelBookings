## HotelBookings API 🌐

## ⚙️ Status: Aguardando Melhorias, Front End. usando Blazor.

#### Este projeto é uma API web que implementa um sistema de gerenciamento de um Hotel.
#### A API permite que a Hotel tenha controle total de: Quartos, Reservas, Clientes, Pagamentos, Serviço Adicional.
#### Já os Clientes: Quartos, Reservas, Avaliação do Hotel, Serviço Adicional.

### Regras do Negócio.

#### Hotel: recebe reservas de quartos dos clientes, somente os que estão disponiveis naquela data, podem ser inclusos serviços adicionais, quando o cliente reserva o quarto recebe um e-mail de reserva, mas a reserva só é confirmado após a aprovação do pagamento.

#### Clientes: reservam o quarto que quiserem, desde que estejam disponiveis, escolhem serviços adicionais se preferirem, os quartos são disponibilizados de acordo com o número de hóspedes, e só é confirmada a reserva após a confirmação do pagamento, e o cliente pode adicionar a data da viagem ao Google Calendário e faz a avaliação do Hotel.


### Funcionalidades 🖥️  ☑ (Concluído) ⌛ Aguardando Melhorias


- ☑ CRUD Hotel
- ☑ CRUD Cliente
- ☑ CRUD Quarto
- ☑ CRUD Reserva
- ☑ CRUD Serviço Adicional
- ☑ CRUD Informações de Pagamento
- ☑ Confirmação de Reserva (Email/SMS + Google Agenda).
- ☑ Background Service rodando e notificando no dia anterior.
- ☑ Autenticação e Autorização.
- ☑ Avaliação do Hotel pelos Clientes.
  

### Tecnologias utilizadas 💡


- ASP.NET Core 8: framework web para desenvolvimento de aplicações .NET
- Entity Framework Core: persistência e consulta de dados.
- SQL Server: banco de dados relacional.
- Mensageria com RabbitMQ.
- API Gmail
- API Google Calendar
- ⌛ Front End. usando Blazor.  

### Padrões, conceitos e arquitetura utilizada 📂


- ☑ Fluent Validation
- ☑ Padrão Repository
- ☑ Middleware (Lidar com exceções)
- ☑ InputModel, ViewModel
- ☑ DTO’s 
- ☑ IEntityTipeConfiguration 
- ☑ Sql Server 
- ☑ Unit Of Work
- ☑ HostedService
- ☑ Domain Event
- ☑ CQRS
- ☑ Teste Unitários
- ☑ Arquitetura Limpa
- ☑ Microsserviços
- ☑ RabbitMQ


 
## Instalação

### Requisitos

Antes de começar, verifique se você tem os seguintes requisitos instalados:

- [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0): A versão do .NET Framework necessária para executar a API.
- [SQL Server](https://www.microsoft.com/en-us/sql-server): O banco de dados utilizado para armazenar os dados.

### Clone

Clone o repositório do GitHub:

```bash
git clone https://github.com/[seu-usuário]/HotelBookings.API.git
```

### Navegue até a pasta do projeto:

```bash
cd HotelBookings.API
```

### Abra o projeto na sua IDE de preferência (a IDE utilizada para desenvolvimento foi o Visual Studio)

### Restaure os pacotes:

```bash
dotnet restore
```

### Configure o banco de dados:

1. Abra o arquivo `appsettings.json`.
2. Altere as configurações do banco de dados para corresponder ao seu ambiente.

### Execute a API:

Para executar a API, use o seguinte comando:

```bash
dotnet run
```

### Lembre-se de substituir [seu-usuário] pelo seu nome de usuário do GitHub.
### Lembre-se de fazer as devidas alterações para o uso correto das API's do Gmail e Google Calendar.

Este projeto foi criado para fins didáticos e não abrange todas as regras e conceitos necessários de uma aplicação real em produção.*
