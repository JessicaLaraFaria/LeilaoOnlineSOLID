# Projeto para o curso de SOLID com CSharp
<h2>Descrição</h2>
O Projeto é uma Aplicação web ASP.NET Core usando EntityFramework e MySQL.
<p>Neste projeto foi uma refatoração do código seguindo os princípios <strong>SOLID</strong> para melhoraria de sua qualidade.</p>


Dentre as mundanças feitas no código estão:

- As classes e métodos foram alteradas para seguir o conceito de responsabilidade única(princípio S).

- Criação de classe DAO(nome de um padrão, classes responsáveis pelas operações que fazem acesso aos dados (Data Acess Object)) para extração das operações de banco de dados que estavam presentes nas classes Controller.

- Criação de uma interface ILeilaoDao que contém a abstração das operações de acesso aos dados da classe LeilaoDaoComEfCore para diminuir o acoplamento com as classes Controller. Criação da pasta EfCore para organização do projeto.

- Como foi criada uma interface para abstrair a lógica de BD, é necessário a configuração na classe Startup (.Net 5) para indicar que todas classes que utilizar a injeção de dependência da interface em seu construtor o sistema irá resolver com a implementação do LeilaoDaoComEfCore. Código add:
<strong>services.AddTransient<ILeilaoDao, LeilaoDaoComEfCore>();</strong>

- Criação da pasta Services onde foram criadas interfaces IAdminservice e IProdutoService, com os casos de uso da parte pública do produto, e a parte administrativa. Foi adicionadas também duas implementação default das interfaces, dentro de uma pasta handlers, onde tinha duas implementações padrões, em que houve o uso do leilaodao, tanto para parte administrativa quanto para produto. Essas mudanças afetaram a classe controller que passaram a depender delas.

- Utilização do padrão Decorator no Handler ArquivamentoAdminService que herda de IAdminService.

- Observando a coesão das interfaces de abstração Dao, criamos uma para leitura e outra para escrita seguindo o padrão chamado CQRS(Command, Query, Responsibility, Segregation). A ICategoriaDao utiliza apenas leitura das categorias, então ela implementa apenas a IQuery(interface de leitura). Já a ILeilaoDao utiliza métodos de leitura e escrita , então ela implementa tanto a interface ICommand(com métodos de escrita) como IQuery(com métodos de leitura)(princípios L e I ).

