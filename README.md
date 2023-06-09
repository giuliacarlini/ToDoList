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

**Clone esse repositório**

```
git clone https://github.com/giuliacarlini/ToDoList.git
```

**Abra o projeto no Visual Studio**

**Faça a restauração das dependências**

Utilize o comando **'dotnet restore'** para fazer a restauração dos pacotes nuggets

**Criação do banco de dados**

Abra o terminal na pasta raiz do projeto(./ToDoList/ToDoList.API/), e rode um comando para que o Entity Framework crie o BD
```
dotnet ef database update
```
O BD será criado vazio conforme configuração no app.json.

**Rode a aplicação no Docker**

Já existe uma imagem do container no Docker Hub (https://hub.docker.com/repository/docker/giuliacarlini/todolistapi/)


Caso opte por utiliza-la, é necessario efetuar os seguintes passos:


Instalar o Docker localmente (Windows)


https://desktop.docker.com/win/main/amd64/Docker%20Desktop%20Installer.exe


Efetuar o pull da imagem docker
```
docker pull giuliacarlini/todolistapi
```

Criar um container local
```
docker run --name todolistapi -p 8000:80 giuliacarlini/todolistapi
```


