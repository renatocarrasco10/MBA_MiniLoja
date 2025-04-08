Gestão de Mini Loja Virtual com Cadastro de Produtos e Categorias - Aplicação de Mini Loja com MVC e API RESTful

1. Apresentação
Bem-vindo ao repositório do projeto Gestão simplificada de produtos e categorias em um formato tipo e-commerce marketplace. Este projeto é uma entrega do MBA DevXpert Full Stack .NET e é referente ao módulo Introdução ao Desenvolvimento ASP.NET Core. O objetivo principal desenvolver uma aplicação de Loja Virtual que permite aos usuários criar, editar, visualizar e excluir Produtos e Categorias, tanto através de uma interface web utilizando MVC quanto através de uma API RESTful. Os Produtos serão visíveis a todos, mas só serão editados ou excluídos pelo usuário que o criou, todos usuários logados podem editar e excluir uma categoria, porém a categoria só será excluída se não houver produtos associados a ela.

Autor
Renato Carrasco

2. Proposta do Projeto
O projeto consiste em:
Aplicação MVC: Interface web para interação no cadastro de produtos e categorias de uma loja virtual.
API RESTful: Exposição dos recursos de cadastro de produtos e categorias para integração com outras aplicações ou desenvolvimento de front-ends alternativos.
Autenticação e Autorização: Implementação de controle de acesso, permitindo apenas usuários autenticados a realizar o CRUD de produtos e categorias.
Acesso a Dados: Implementação de acesso ao banco de dados através de ORM.

3. Tecnologias Utilizadas
Linguagem de Programação: C#
Frameworks:
ASP.NET Core MVC
ASP.NET Core Web API
Entity Framework Core
Banco de Dados: SQL Server e SQL Lite
Autenticação e Autorização:
ASP.NET Core Identity
JWT (JSON Web Token) para autenticação na API
Front-end:
Razor Pages/Views
HTML/CSS para estilização básica
Documentação da API: Swagger

4. Estrutura do Projeto
A estrutura do projeto é organizada da seguinte forma:
src/
Loja.UI/ - Projeto MVC
Loja.Api/ - API RESTful
Loja.Data/ - Modelos de Dados e Configuração do EF Core
Loja.sln – Arquivo da solução do projeto
README.md - Arquivo de Documentação do Projeto
FEEDBACK.md - Arquivo para Consolidação dos Feedbacks
.gitignore - Arquivo de Ignoração do Git

5. Funcionalidades Implementadas
CRUD para produtos e categorias: Permite criar, editar, visualizar e excluir produtos e categorias.
Autenticação e Autorização: somente usuários logados terão acesso ao CRUD.
API RESTful: Exposição de endpoints para operações CRUD via API.
Documentação da API: Documentação automática dos endpoints da API utilizando Swagger.

6. Como Executar o Projeto
Pré-requisitos
.NET SDK 9.0
SQL Server
Visual Studio 2022 ou superior (ou qualquer IDE de sua preferência)
Git
Passos para Execução
Clone o Repositório:

git clone https://github.com/renatocarrasco10/MBA_MiniLoja.git 

Configuração do Banco de Dados:

No arquivo appsettings.json, configure a string de conexão do SQL Server.
Rode o projeto apontado para Loja.UI para que a configuração do Seed crie o banco SQL Lite e popule com os dados básicos

Executar a Aplicação MVC:
cd src/Loja.UI/
dotnet run
Acesse a aplicação em: http://localhost:7149

Executar a API:
cd src/Loja.Api/
dotnet run
Acesse a documentação da API em: https://localhost:7177/swagger

7. Instruções de Configuração
JWT para API: As chaves de configuração do JWT estão no appsettings.json.
Migrações do Banco de Dados: As migrações são gerenciadas pelo Entity Framework Core. Não é necessário aplicar devido a configuração do Seed de dados.

8. Documentação da API
A documentação da API está disponível através do Swagger. Após iniciar a API, acesse a documentação em:

https://localhost:7177/swagger

9. Avaliação
Este projeto é parte de um curso acadêmico e não aceita contribuições externas.
Para feedbacks ou dúvidas utilize o recurso de Issues
O arquivo FEEDBACK.md é um resumo das avaliações do instrutor e deverá ser modificado apenas por ele.