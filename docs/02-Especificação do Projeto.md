# Especificações do Projeto

<span style="color:red">Pré-requisitos: <a href="1-Documentação de Contexto.md"> Documentação de Contexto</a></span>

Definição do problema e ideia de solução a partir da perspectiva do usuário. É composta pela definição do  diagrama de personas, histórias de usuários, requisitos funcionais e não funcionais além das restrições do projeto.

Apresente uma visão geral do que será abordado nesta parte do documento, enumerando as técnicas e/ou ferramentas utilizadas para realizar a especificações do projeto

## Personas
![personas](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t2-en-cantos_do_brasil/assets/144967071/8c4a610a-a54d-4156-b86d-8523a9f25599)
![aade](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t2-en-cantos_do_brasil/assets/144967071/9866800b-8085-47ad-bc6c-e802017312ab)


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

Com base na análise das personas forma identificadas as seguintes histórias de usuários:

|EU COMO... `PERSONA`| QUERO/PRECISO ... `FUNCIONALIDADE` |PARA ... `MOTIVO/VALOR`                 |
|--------------------|------------------------------------|----------------------------------------|
|Usuário do sistema  | Registrar minhas tarefas           | Não esquecer de fazê-las               |
|Administrador       | Alterar permissões                 | Permitir que possam administrar contas |

Apresente aqui as histórias de usuário que são relevantes para o projeto de sua solução. As Histórias de Usuário consistem em uma ferramenta poderosa para a compreensão e elicitação dos requisitos funcionais e não funcionais da sua aplicação. Se possível, agrupe as histórias de usuário por contexto, para facilitar consultas recorrentes à essa parte do documento.

> **Links Úteis**:
> - [Histórias de usuários com exemplos e template](https://www.atlassian.com/br/agile/project-management/user-stories)
> - [Como escrever boas histórias de usuário (User Stories)](https://medium.com/vertice/como-escrever-boas-users-stories-hist%C3%B3rias-de-usu%C3%A1rios-b29c75043fac)
> - [User Stories: requisitos que humanos entendem](https://www.luiztools.com.br/post/user-stories-descricao-de-requisitos-que-humanos-entendem/)
> - [Histórias de Usuários: mais exemplos](https://www.reqview.com/doc/user-stories-example.html)
> - [9 Common User Story Mistakes](https://airfocus.com/blog/user-story-mistakes/)

## Requisitos

As tabelas que se seguem apresentam os requisitos funcionais e não funcionais que detalham o escopo do projeto.

### Requisitos Funcionais

|ID    | Descrição                | Prioridade |
|-------|---------------------------------|----|
| RF-01 | Cadastro de Usuário: Permitir que os usuários se cadastrem na plataforma para acessar funcionalidades exclusivas. | Alta | 
| RF-02 | Tela Inicial: Uma introdução à plataforma, apresentando de forma sucinta sua proposta e funcionalidades principais, servindo como um guia para novos usuários. | Alta |
| RF-03 | Pesquisa de Destinos: Implementar um sistema de pesquisa que permita aos usuários buscar destinos por nome, região, atividades disponíveis, etc. | Alta |
| RF-04 | Informações sobre Destinos: Fornecer informações detalhadas sobre os destinos, incluindo atrações turísticas, atividades disponíveis, melhores épocas para visitar, custo de vida, entre outros. | Alta |
| RF-05 | Roteiros Personalizados: Oferecer a opção de criar roteiros personalizados com base nas preferências dos usuários, como interesse em ecoturismo, cultura local, aventura, etc. | Média |
| RF-06 | Avaliações e Comentários: Permitir que os usuários deixem avaliações e comentários sobre os destinos visitados, hotéis, restaurantes, agências de turismo, etc. | Média |
| RF-07 | Agendamento de Atividades: Integrar um sistema de reserva para atividades turísticas, como passeios guiados, trilhas, mergulhos, etc. | Média |
| RF-08 | Mapas e Navegação: Integrar mapas interativos para ajudar os usuários a se localizarem nos destinos e planejarem seus deslocamentos. | Média |
| RF-09 | Notificações: Enviar notificações para os usuários sobre novas atrações, eventos locais, promoções de viagem, etc. | Baixa |

**Prioridade: Alta / Média / Baixa. 

### Requisitos não Funcionais


|ID      | Descrição               |Prioridade |
|--------|-------------------------|----|
| RNF-01 | Segurança: Garantir a segurança dos dados dos usuários, implementando medidas de criptografia e controle de acesso. | Alta  | 
| RNF-02 | Desempenho: Garantir que a aplicação seja responsiva e tenha um tempo de carregamento rápido, mesmo em áreas com conexões de internet lentas. | Alta |
| RNF-03 | Confiabilidade: Garantir que a aplicação opere de maneira confiável e consistente, entregando resultados precisos e esperados sob condições normais de operação, promovendo assim a confiança dos usuários na plataforma. | Alta |
| RNF-04 | Robustez: Garantir que a aplicação seja capaz de lidar eficazmente com situações excepcionais, como erros de sistema, falhas de conexão, entradas de dados inválidas e outras condições adversas, mantendo a estabilidade e a funcionalidade adequada. | Alta |
| RNF-05 | Escalabilidade: Projetar a aplicação de forma a suportar um grande número de usuários e uma crescente base de dados de destinos e atividades. | Média |
| RNF-06 | Compatibilidade: Certificar-se de que a aplicação seja compatível com diferentes dispositivos (computadores, smartphones, tablets) e navegadores web. | Alta |
| RNF-07 | Usabilidade: Projetar uma interface intuitiva e fácil de usar, com navegação clara e instruções claras para os usuários. | Alta |
| RNF-08 | Disponibilidade: Assegurar que a aplicação esteja disponível 24/7, minimizando o tempo de inatividade para manutenção e atualizações. | Alta |
| RNF-09 | Backup e Recuperação: Implementar um sistema de backup regular para garantir a recuperação de dados em caso de falhas no sistema ou perda de dados. | Média |
| RNF-10 | Localização: Oferecer suporte para diferentes idiomas e adaptar as informações de acordo com a localização geográfica do usuário. | Baixa |

**Prioridade: Alta / Média / Baixa. 


## Restrições

O projeto está restrito pelos itens apresentados na tabela a seguir.

|ID| Restrição                                             |
|--|-------------------------------------------------------|
|01| O projeto deverá ser entregue até o final do semestre |
|02| Não pode ser desenvolvido um módulo de backend        |


Enumere as restrições à sua solução. Lembre-se de que as restrições geralmente limitam a solução candidata.

> **Links Úteis**:
> - [O que são Requisitos Funcionais e Requisitos Não Funcionais?](https://codificar.com.br/requisitos-funcionais-nao-funcionais/)
> - [O que são requisitos funcionais e requisitos não funcionais?](https://analisederequisitos.com.br/requisitos-funcionais-e-requisitos-nao-funcionais-o-que-sao/)

## Diagrama de Casos de Uso

O diagrama de casos de uso é o próximo passo após a elicitação de requisitos, que utiliza um modelo gráfico e uma tabela com as descrições sucintas dos casos de uso e dos atores. Ele contempla a fronteira do sistema e o detalhamento dos requisitos funcionais com a indicação dos atores, casos de uso e seus relacionamentos. 

As referências abaixo irão auxiliá-lo na geração do artefato “Diagrama de Casos de Uso”.

> **Links Úteis**:
> - [Criando Casos de Uso](https://www.ibm.com/docs/pt-br/elm/6.0?topic=requirements-creating-use-cases)
> - [Como Criar Diagrama de Caso de Uso: Tutorial Passo a Passo](https://gitmind.com/pt/fazer-diagrama-de-caso-uso.html/)
> - [Lucidchart](https://www.lucidchart.com/)
> - [Astah](https://astah.net/)
> - [Diagrams](https://app.diagrams.net/)
