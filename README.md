Passos para executar o projeto:

Requisitos:
- Docker
- Cliente SQL (Recomendo DBeaver por ser generalista e conseguir conectar com quase todos os tipos de banco de dados).

Etapas:
- Após garantir que o Docker está instalado e funcionando corretamente, abrir o console (cmd, Terminal, etc) no diretório e executar o comando `docker-compose up -d`. Este comando irá subir a instância do banco de dados MySQL e as duas aplicações (API e Web) em um container.
- Assim que concluir a execução, executar o comando `docker container ps`. Após executar esse comando, deverá ter 3 containers em execução.
- Com os containers em execução, abrir o cliente SQL e configurar o mesmo para ter acesso a base de dados com as informações a seguir:
- Server Host: localhost, Port: 3306, User: root, Password: password;
- Com a conexão estabelecida, criar uma base dados chamada 'products' e executar os 3 scripts que estão dentro da pasta `scripts` na ordem indicada por seu nome.
- Com essas etapas concluidas, deverá ser possível acessar as aplicações pelos endereços:

  API
- http://localhost:5253/swagger/index.html

  WEB
- http://localhost:5007/
