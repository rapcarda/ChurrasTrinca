# TrincaChurrasco

Repositório responsável pelo desenvolvimento de aplica de avaliação empresa Trinca.
Projeto consiste em agendamento de churrascos.

## Recursos utilizados
- .Net 5
- EntityFramework 5.0.7
- FluentValidation 10.3.0
- MediatR 9.0.0
- SqlServer 2019

## Endpoints liberados
-GET - /api/v1/Churrasco/resumo/{type}
  - type = (0-Todos, 1-Próximos, 2-Passados)
  - Retorna dados resumidos dos churrascos de acordo com parâmetro type
-GET - /api/v1/Churrasco/analitico
  - Retorna dados resumidos e lista de participantes do churrasco especificado
-POST - /api/v1/Churrasco
  - Cria um novo churrasco
-POST - /api/v1/Participante/adicionar-participante
  - Vincula um participante em um churrasco já existente
-DELETE - /api/v1/Participante/remover-participante/{id}
  - Exclui um participante de um churrasco

## Detalhes
Venho estudando recentemente o padrão CQRS, portanto utilizei este projeto para, além da avaliação de vocês, para tentar consolidar meu conhecimento.
Criei 3 projetos
- API
- Domain
- Infra

Onde:
- API
  - É o projeto Web API e contém:
    - Application: Tentei utilizar esta pasta lógica como se fosse a camada "Application" do padrão CQRS, contendo então os Commands e Queries
    - Configuration: Contém classes de configurações do projeto, como injeção de dependências, swagger, etc.
    - Controllers: contém as controllers criadas no projeto (Churrasco e Participante)
    - Enums: Enumeradores
    - Mediatr: classes de configurações do mediatR
    - ViewModels: ViewModels utilizadas pelas controlllers
- Domain
  - É o projeto que representa a camada Domain do padrão CQRS
    - Core: utilizei esta pasta lógica para centralizar objetos centrais, como interface de Repository etc.
    - Dtos: contém classes de DTO utilizadas pelas Queries
    - Interfaces: Interfaces de repositories específicos
    - Models: classes de domínio
- Infra
  - É o projeto que representa a camada infrastructure do padrão CQRS
    - Data: contém implementações de repositórios e classe de contexto do entity framework
    - Mappings: classes de mapeamento dos dominios
    - Migrations: classes de migrations geradas pelo entity framework