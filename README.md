# Journey API

## Descrição
A Journey API é uma aplicação desenvolvida durante o NLW da Rocketseat, utilizando C# e .NET. Este projeto visa fornecer uma solução robusta para o gerenciamento de viagens, permitindo aos usuários registrar, atualizar, visualizar e deletar informações sobre suas viagens e atividades relacionadas.

## Tecnologias Utilizadas
- C#
- .NET 8
- Entity Framework Core
- SQLite

## Funcionalidades
- **Cadastro de Viagens**: Permite aos usuários registrar novas viagens, incluindo nome, data de início e data de término.
- **Listagem de Viagens**: Os usuários podem visualizar todas as viagens cadastradas.
- **Cadastro de Atividades**: Dentro de uma viagem, é possível cadastrar atividades específicas, como visitas a pontos turísticos, refeições em restaurantes, etc.
- **Gerenciamento de Atividades**: As atividades podem ser atualizadas ou excluídas conforme necessário.

## Como Executar
Para executar a Journey API em seu ambiente local, siga os passos abaixo:

1. Clone o repositório para sua máquina local.
2. Abra o terminal e navegue até a pasta do projeto.
3. Execute o comando `dotnet restore` para restaurar as dependências do projeto.
4. Execute o comando `dotnet run` para iniciar a aplicação.
5. A aplicação estará disponível em `http://localhost:{host}`.

## Endpoints da API
- `POST /api/trips`: Cadastra uma nova viagem.
- `GET /api/trips`: Lista todas as viagens cadastradas.
- `POST /api/activities`: Cadastra uma nova atividade em uma viagem específica.
- `GET /api/activities/{tripId}`: Lista todas as atividades de uma viagem específica.

## Contribuições
Contribuições são sempre bem-vindas! Se você tem alguma sugestão para melhorar a aplicação, sinta-se à vontade para criar um pull request.
