# Especificações do Projeto

<span style="color:red">Pré-requisitos: <a href="1-Documentação de Contexto.md"> Documentação de Contexto</a></span>

Definição do problema e ideia de solução a partir da perspectiva do usuário. É composta pela definição do  diagrama de personas, histórias de usuários, requisitos funcionais e não funcionais além das restrições do projeto.

Apresente uma visão geral do que será abordado nesta parte do documento, enumerando as técnicas e/ou ferramentas utilizadas para realizar a especificações do projeto

## Personas
![personas](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t2-en-cantos_do_brasil/assets/144967071/8c4a610a-a54d-4156-b86d-8523a9f25599)
![aade](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t2-en-cantos_do_brasil/assets/144967071/9866800b-8085-47ad-bc6c-e802017312ab)

 ## Stakeholders

## Governo Brasileiro:

Envolvimento: Oferecendo incentivos fiscais, parcerias para promover destinos menos conhecidos, fornecendo dados e informações sobre a infraestrutura turística.

## Empresas de Turismo e Hospedagem:

Envolvimento: Parcerias para oferecer pacotes turísticos, disponibilização de informações sobre acomodações e serviços turísticos, marketing conjunto para atrair mais turistas.

 Os próprios usuários da  aplicação são stakeholders essenciais, pois são eles que usarão a plataforma para planejar suas viagens e explorar os destinos pelo Brasil. 

> **Links Úteis**:
> - [Rock Content](https://rockcontent.com/blog/personas/)
> - [Hotmart](https://blog.hotmart.com/pt-br/como-criar-persona-negocio/)
> - [O que é persona?](https://resultadosdigitais.com.br/blog/persona-o-que-e/)
> - [Persona x Público-alvo](https://flammo.com.br/blog/persona-e-publico-alvo-qual-a-diferenca/)
> - [Mapa de Empatia](https://resultadosdigitais.com.br/blog/mapa-da-empatia/)
> - [Mapa de Stalkeholders](https://www.racecomunicacao.com.br/blog/como-fazer-o-mapeamento-de-stakeholders/)
>
Lembre-se que você deve ser enumerar e descrever precisamente e personalizada todos os clientes ideais que sua solução almeja.

## Histórias de Usuários

| EU COMO...                        | QUEM                  | QUERO/PRECISO ...                                                                     | O QUE                                                                                        | PARA ...                                                                                             | PORQUE                                                                                             |
|-----------------------------------|-----------------------|----------------------------------------------------------------------------------------|----------------------------------------------------------------------------------------------|-----------------------------------------------------------------------------------------------------|----------------------------------------------------------------------------------------------------|
| Fátima (viajante aventureira)    | Viajante aventureira  | De informações detalhadas sobre pontos turísticos, trilhas e aventuras locais.         | Explorar os pontos turísticos mais incríveis da região afim de tornar a viagem inesquecível. | Porque deseja uma experiência de viagem memorável e emocionante.                                   |
| Aldair (chefe de família)        | Chefe de família      | Sugestões de hotéis confiáveis e familiares e dicas dos melhores restaurantes locais.   | Planejar com segurança nossas férias em família e poder proporcionar momentos memoráveis e uma experiência de viagem rica e agradável para a minha família. | Para garantir uma viagem tranquila e agradável para toda a família.                                |
| Rodrigo e Thais (Casal em lua de mel) | Casal em lua de mel | Informações sobre lugares românticos na cidade.                                          | Desfrutar de uma viagem e lua de mel inesquecíveis e ter recordações inesquecíveis durante a lua de mel. | Para tornar sua lua de mel especial e memorável.                                                  |
| Carlos (viajante experiente)     | Viajante experiente   | Recomendações precisas, detalhadas e abrangentes para a estadia, recomendações de bares e atrações exclusivas. | Tornar a estadia mais autêntica e enriquecedora.                                            | Para enriquecer sua experiência de viagem com atividades exclusivas e autênticas.                   |
| Rozimeire (turista internacional) | Turista internacional | Informações detalhadas sobre resorts, explorar a cidade sem falar o idioma local, dicas úteis. | Ter uma experiência enriquecedora e sem contratempos na viagem.                               | Para aproveitar ao máximo sua viagem internacional com segurança e facilidade.                    |

## Requisitos

As tabelas que se seguem apresentam os requisitos funcionais e não funcionais que detalham o escopo do projeto.

### Requisitos Funcionais

|ID    | Descrição                | Prioridade |
|-------|---------------------------------|----|
| RF-01 | Cadastro de Usuário: Permitir que os usuários se cadastrem na plataforma para acessar funcionalidades exclusivas. | Alta | 
| RF-02 | Tela de Login: A aplicação deve permitir que os usuários façam login e logout. | Alta |
| RF-03 | Barra de Pesquisa: O usuário deve ser capaz de pesquisar destinos por nome, região, atividades disponíveis, etc. | Alta |
| RF-04 | A aplicação deve fornecer informações detalhadas sobre os destinos. | Alta |
| RF-05 | A aplicação deve oferecer roteiros personalizados com base nas preferências dos usuários. | Média |
| RF-06 | O sistema deve direcionar o usuário para uma página de reserva e consulta de hospedagens, atividades turísticas, etc. | Média |
| RF-07 | A aplicação deve permitir que os usuários adicionem destinos em sua lista de favoritos. | Alta |

### Requisitos não Funcionais

|ID      | Descrição               |Prioridade |
|--------|-------------------------|----|
| RNF-01 | Segurança: Garantir a segurança dos dados dos usuários, implementando medidas de criptografia e controle de acesso. | Alta  | 
| RNF-02 | Desempenho: Garantir que a aplicação seja responsiva e tenha um tempo de carregamento rápido, mesmo em áreas com conexões de internet lentas. | Alta |
| RNF-03 | Confiabilidade: Garantir que a aplicação opere de maneira confiável e consistente, entregando resultados precisos e esperados sob condições normais de operação, promovendo assim a confiança dos usuários na plataforma. | Alta |
| RNF-04 | Robustez: Garantir que a aplicação seja capaz de lidar eficazmente com situações excepcionais, como erros de sistema, falhas de conexão, entradas de dados inválidas, etc. | Alta |
| RNF-05 | Compatibilidade: Certificar-se de que a aplicação seja compatível com diferentes dispositivos (computadores, smartphones, tablets) e navegadores web. | Alta |
| RNF-06 | Usabilidade: Projetar uma interface intuitiva e fácil de usar, com navegação clara e instruções claras para os usuários. | Alta |
| RNF-07 | Disponibilidade: Assegurar que a aplicação esteja disponível 24/7, minimizando o tempo de inatividade para manutenção e atualizações. | Alta |

## Restrições

O projeto está restrito pelos itens apresentados na tabela a seguir.

|ID| Restrição                                             |
|--|-------------------------------------------------------|
|01| O projeto deverá ser entregue até o final do semestre |
|02| Deve ser desenvolvido um módulo de backend        |
|03| Deve haver uma integração entre o módulo beckend e o front        |
|04| O projeto deve ser interativo com os usuários         |
|05| Deve ser priorizada a Qualidade na entrega à quantidade de recursos        |
|06| O projeto deve contar com o desenvolvimento por parte de cada componente do grupo        |
|07| Todos os componentes deverão dispor de ao menos 6 horas semanais para a evolução do projeto        |
|08| O projeto deverá seguir um orçamento nulo para a sua execução        |
|09| O projeto deverá apresentar os benefícios estipulados para o usuário que o acessar        |
|10| Deverão ser desenvolvidos testes da aplicação pelos componentes do grupo        |
|11| O projeto deve ser registrado em algum domínio e deverá ser acessível online        |
|12| O projeto deve apresentar o respectivo design ideal para diferentes dispositivos        |

## Diagrama de Casos de Uso

![diagrama](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t2-En-cantos_do_brasil/assets/144967071/5a664810-335b-461c-baba-5ec905ffe26d)

