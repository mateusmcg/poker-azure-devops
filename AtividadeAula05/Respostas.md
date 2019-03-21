# Repostas Exercício 1
## Integração Contínua:

- Na integração contínua, o desenvolvedor realiza a integração do código criado ou 
modificado ao projeto principal na mesma frequência que as funcionalidade são criadas, com a integração sendo feita uma ou mais vezes durante o dia. 
  Um dos principais objetivos da integração contínua, é a certificação que as alterações ou funcionalidades criadas não estão gerando defeitos no projeto existente. Essa integração pode ser feita através de processos manuais ou automatizados, podendo utilizar ferramentas para auxiliar nessa integração contínua. 
  Para que a integração contínua seja feita corretamente, a equipe tem que trabalhar em conjunto, e utilizando um controle de versão. Esse controle de versão é essencial para fluxo do trabalho da equipe de desenvolvimento, fazendo com que as informações sejam compartilhadas, evitando o retrabalho. 
  Existem várias ferramentas que realizam esse controle de versão, permitindo que os desenvolvedores trabalhem em conjunto, acessando, visualizando, modificando e enviando novos códigos para o servidor responsável pelo versionamento do sistema. 
  Existem metodologias que têm uma visão da entrega completa do código, somente depois que o desenvolvedor terminar e testar todo o projeto ou módulo, ele será entregue para ser colocado em produção. Essa metodologia pode causar grande perda da qualidade do produto, gerando retrabalho e insatisfação com o produto. 
  A integração contínua resolve esse problema, com as pequenas entregas, automatização de teste, facilitando a localização e correção de erros, automatização de builds, evitando erros em processos de builds, por serem automáticos e não ter influência de processos manuais. Pois em processos manuais, cada pessoa pode fazer o build de forma diferente, possibilitando falhas nas entregas e a não detecção de erros.
  **Benefícios de integração contínua:**
  - Contribui com a produtividade dos desenvolvedores, liberando eles das tarefas manuais e incentivando em ações que contribui para a melhoria de código e identificação de erros.
  - Com testes mais frequentes, contribui para descobrir bugs e evitar futuros problemas com o produto.
  - Distribuição mais frequente de atualizações do produto para os clientes.

## Entrega Contínua:

- São entregas feitas em pequenas partes, garantindo uma qualidade e rapidez na entrega do produto. Ao invés da equipe de             desenvolvimento fazer uma só entrega do produto finalizado, dando a possibilidade de entregar um produto com baixa qualidade, a equipe    pode fazer pequenas entregas, onde será mais fácil a manutenção, identificação de melhorias, garantindo uma qualidade na entrega dessas  pequenas partes do produto. 
	Umas das principais características da entrega contínua, são o uso de automação de testes, infraestrutura e deploy, viabilizando mais  velocidade nos versionamentos. Algumas das vantagens da entrega contínua são a minimização de riscos nos lançamentos, mais velocidade,   mais qualidade, menores custos, equipe mais satisfeita:
  - **Minimização de riscos nos lançamentos: ** 
  Entrega contínua permite deploys constantes e rápidos, com deploys menores, correm menos riscos de erros e podem ser feitos a qualquer   momento, dependendo da demanda, e muitos nem são percebidos pelos usuários.
  - **Mais velocidade:** 
  Entrega contínua elimina as fases de integração, testes e correção,  que podem gerar atrasos na entrega do produto. A equipe trabalha   em conjunto, dentro do conceito DevOps, onde os processos de homologação de ambientes, testes e deploy são automatizados, ganhando       tempo e reduzindo o retrabalho.   
  - **Mais qualidade:** 
  Com os testes automatizados, os erros são encontrados mais rapidamentes e os desenvolvedores conseguem aprofundar mais no               desenvolvimento, garantindo a qualidade final do produto. Outros tipos de teste podem ser mais explorados, garantindo uma cobertura     maior de código, performance, usabilidade, segurança e dentre outras qualidades. 
  - **Menores custos:**
  Com a eliminação de trabalhos repetitivos de testes, infra e deploy, o trabalho da equipe fica mais eficiente, reduzindo os custos.
  - **Equipe mais satisfeita:** 
  Ao liberar os desenvolvedores de realizarem ciclos de testes repetitivos, proporciona mais satisfação e tempo para que a equipe         possa   pensar em novas ideias e melhorias no produto. 
  Mas para que a entrega contínua seja feita corretamente, é necessário uma maior participação de toda a equipe e que estejam preparados para lidar com grande fluxo de entregas e responsabilidades. Outro pilar da entrega contínua, é a participação dos responsáveis pelo produto, atuando nos processos de validação do produto. 

## Implantação Contínua:

- 

# Repostas Exercício 2

a) A startup ABC trabalha com soluções PHP, MYSQL e quer usar uma infraestrutura baseada em Docker e Kubernetes. 
CI / CD para contêineres - É possível obter clusters de contêineres replicáveis e gerenciáveis. 
Em alguns casos, talvez você não consiga atribuir a função necessária à entidade de serviço AKS gerada automaticamente, concedendo-lhe acesso ao ACR. Por exemplo, devido ao modelo de segurança da sua organização, talvez você não tenha permissões suficientes em seu locatário do Azure Active Directory para atribuir uma função à entidade de serviço gerada pelo AKS. Atribuir uma função a uma entidade de serviço exige que sua conta do Azure AD tenha permissão de gravação para seu locatário do Azure AD. Se você não tiver permissão, poderá criar uma nova entidade de serviço e conceder acesso ao registro do contêiner usando um segredo de recepção de imagem do Kubernetes. 

b) A empresa XYZ trabalha com Java e já possui o Jenkins como solução de CI para automação de seus builds. Visão geral da CI/CD de Infraestrutura Imutável usando Jenkins e Terraform na Arquitetura virtual do Azure. O servidor Jenkins delega trabalho para um ou mais agentes para permitir que uma única instalação Jenkins hospede um número grande de projetos ou para fornecer ambientes diferentes, necessários para compilações ou testes. 

c) A empresa XPTO não tem profissional que conheça de infraestrutura com profundidade e que implantar um pipeline CD do DevOps com o menor custo possível. 
CI / CD para aplicativos da Web do Azure - O Azure Web Apps é uma maneira rápida e simples. Neste exemplo, o pipeline de CI/CD implanta um aplicativo Web do .NET de duas camadas para o Serviço de Aplicativo do Azure. 
