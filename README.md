Projeto desenvolvido como parte do processo seletivo para vaga de estágio.

Essa aplicação simula um sistema de gerenciamento de Clientes, Produtos e Vendas, aplicando padrões de projeto como CQRS, Repository Pattern e Mediator Pattern.

Tecnologias Utilizadas
.NET 8.0 — Framework principal

C# — Linguagem de programação

Entity Framework Core (InMemory) — Banco de dados em memória para testes

MediatR — Implementação do padrão Mediator para comandos e consultas

FluentValidation — Validações de dados

Swagger UI — Documentação interativa da API

Visual Studio Code — Ambiente de desenvolvimento

Estrutura do Projeto
O projeto é dividido em camadas seguindo princípios de limpeza de arquitetura:

RO.DevTest.Application — Camada de regras de negócio (Handlers, Commands, Queries, Validators)

RO.DevTest.Domain — Entidades e objetos de domínio

RO.DevTest.Persistence — Acesso ao banco de dados InMemory

RO.DevTest.WebApi — Exposição de endpoints da API

RO.DevTest.Tests — Preparado para testes unitários

Como Rodar o Projeto
Clone este repositório:

git clone https://github.com/proerdbr/ro-devtest-api.git

Abra o projeto no Visual Studio Code ou Visual Studio.

Navegue até a pasta onde está o arquivo .sln (solução):

cd RO.DevTest.WebApi

Restaure as dependências:

dotnet restore

Rode a aplicação:

dotnet run

Acesse o navegador para ver o Swagger (documentação dos endpoints):

https://localhost:port/swagger

(A porta será exibida no terminal quando você rodar o projeto.)

Funcionalidades Implementadas
Cliente

Cadastro de Cliente (POST)

Listagem de Clientes (GET)

Atualização de Cliente (PUT)

Remoção de Cliente (DELETE)

Produto

Cadastro de Produto (POST)

Listagem de Produtos com paginação (GET)

Atualização de Produto (PUT)

Remoção de Produto (DELETE)

Venda

Registro de Venda (POST)

Listagem de Vendas (GET)

Listagem de Vendas filtradas por Período (GET /vendas/periodo)

Documentação via Swagger
Após rodar o projeto, você poderá testar todos os endpoints diretamente pelo navegador usando o Swagger.

Acesse:

https://localhost:port/swagger

Visualize todos os métodos HTTP disponíveis (POST, GET, PUT, DELETE)

Teste as requisições e respostas de forma interativa

Observações Importantes
A aplicação utiliza autenticação JWT para proteger as rotas.

Banco de dados é InMemory, ou seja, os dados são perdidos a cada reinicialização.

A estrutura do projeto facilita a troca para banco de dados reais como SQL Server ou PostgreSQL.

🛠️ Melhorias Futuras (Sugestões)
Implementação de testes unitários e testes de integração

Deploy do projeto utilizando Docker

Desenvolvimento de uma aplicação Frontend para consumir essa API

Adicionar logs estruturados

Autor
Desenvolvido por Davi Henrique Souza da Silva.

Status do Projeto
Projeto finalizado para entrega no processo seletivo.

Observação Final
Obrigado pela oportunidade! Estou ansioso para fazer parte da equipe.

