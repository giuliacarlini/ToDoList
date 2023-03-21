<h1 align="center">
   Api ToDoList
</h1>

</br>
  <p align="center">Api que retorna listas utilizando ASP.NET CORE</p>
  
<p align="center">
  <a href="#white_check_mark-Features">Features</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href="#globe_with_meridians-Tecnologias-e-Conceitos-Implementados">Tecnologias</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href="#wrench-Como-utilizar">Como Utilizar</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href="#gear-Arquitetura">Arquitetura</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
</p>


## :white_check_mark: Features

* Web Api construida com Asp.net core API
* Crud utilizando ORM Entity Framework Core
* Utilizado em repository patterns e interfaces para fazer gestão de desacoplamento


## :globe_with_meridians: Tecnologias e Conceitos Implementados

Esse projeto foi desenvolvido usando as seguintes tecnologias:

- ASP.NET Core 6 
- Entity Framework Core 7.0

Conceitos/Técnicas utilizadas:
- Data Transfer Object [DTO]
- Repository Pattern
- Injeção de dependências

## :gear: Arquitetura

```🌐
src
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

```bash
# 1. Clone esse repositório
$ git clone https://github.com/giuliacarlini/ToDoList.git

# 2. Abra o projeto no Visual Studio

# 3. Faça a restauração das dependências
Utilize o comando 'dotnet restore' para fazer a restauração dos pacotes nuggets

# 4. Rode a aplicação
Utilizando o IIS ou Docker

