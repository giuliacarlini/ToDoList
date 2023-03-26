<h1 align="center">
   Api ToDoList
</h1>

<h2 align="center">
Projeto próprio para estudos
</h2>

</br>
  <p align="center">Api que retorna listas utilizando ASP.NET CORE</p>
  
<p align="center">
  <a href="#white_check_mark-Features">Features</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href="#globe_with_meridians-Tecnologias-e-Conceitos-Implementados">Tecnologias</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href="#gear-Arquitetura">Arquitetura</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href="#wrench-Como-utilizar">Como Utilizar</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
</p>


## :white_check_mark: Features

* Web Api construída com ASP.Net Core API
* CRUD utilizando ORM Entity Framework Core
* Utilizado em repository patterns e interfaces para fazer gestão de desacoplamento


## :globe_with_meridians: Tecnologias e Conceitos Implementados

Esse projeto foi desenvolvido usando as seguintes tecnologias:

- ASP.NET Core 6 
- Entity Framework Core 7.0

Conceitos/Técnicas utilizadas:
- Data Transfer Object [DTO];
- Repository Pattern;
- Injeção de Dependências.

## :gear: Arquitetura

```🌐
ToDoList.API
├── 📂 Controllers      [Rotas para endpoints]
├── 📂 Models           [Modelos do banco de dados]
├── 📂 Services         [Regras de negócio]
├── 📂 Database         [Estruturas referentes ao banco de dados]
│   ├── 📂 DTOs             [Inputs Models e View Models (Data Transfer Objects)]
│   ├── 📂 EntityFramework  [Arquivos referente ao ORM Entity Framework]
│   │     ├── 📂 Context         [Configurações de contexto do Entity]
│   │     ├── 📂 Migrations      [Migrations para atualização do Banco]
│   ├── 📂 Repositories     [Repository pattern]

🧪Tests [Collections do Postman]
```

## :wrench: Como Utilizar

Clone essa aplicação utilizando o [Git](https://git-scm.com) e siga os próximos passos:


<h4>Clone esse repositório</h4>
<p>git clone https://github.com/giuliacarlini/ToDoList.git</p>

<h4>Abra o projeto no Visual Studio</h4>

<h4>Faça a restauração das dependências</h4>

<p>Utilize o comando 'dotnet restore' para fazer a restauração dos pacotes nuggets</p>

<h4>Criação do banco de dados</h4>

<p>Abra o terminal na pasta raiz do projeto, e rode um comando para que o entity framework crie o BD</p>

<p>dotnet ef database update</p>

<h4>Rode a aplicação no Docker</h4>




