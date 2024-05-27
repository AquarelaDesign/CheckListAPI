# CheckListAPI

- Login
- Cadastro dos Usuários
- Cadastro dos Supervisores
- Cadastro dos Grupos dos Itens
- Cadastro dos Itens Padrão para o checklist
- Cadastro dos Proprietários
- Cadastro dos Veículos
- Cadastro dos Checklist
- Cadastro dos Itens do Veículo do checklist

## Tecnologias utilizadas

- Visual Studio 2022
- Dotnet Framework 8.0
- Dotnet EF Core Tools
- SQL Server Express 2022
- Microsoft SQL Server Management Studio 20.1
- Autenticação por Jwt
- Postman (validação e testes da API)

## Configuração do Ambiente e execução

- Download do Visual Studio 2022
  . Instalar e configurar
  . Instalar dotnet ef
- Download do SQL Server Express
  . Instalar e configurar
- Clonar o repositório no Git
- Executar pelo Powershell a migração das tabelas
  . acessar o diretório/pasta do projeto (Ex. C:\Projetos\Gestran\checklist\CheckListAPI\CheckListAPI)
  . executar o comando dotnet ef database update
- Executar e acessar a API no navegador na página do Swegger para definições ou importar o arquivo

## Passos a serem seguidos para o cadastro do checklist

A parte de autenticação foi implementada e testada, porém não incluida nos programas, apenas no checklist para testes (em comentário)

- Login
- Cadastro dos Usuários

1. Cadastrar os Supervisores
2. Cadastrar os Grupos dos Itens
3. Cadastrar os Itens Padrão para o checklist (somente necessário se for importado para o cadastro na geração do checklist pelo frontend)
4. Cadastrar o Proprietário
5. Cadastrar o Veículo
6. Cadastrar o Checklist
7. Importar os Itens do Veículo do checklist após salvar o cabeçalho do checklist

## Definições futuras para abertura do checklist no frontend (ainda não implementado)

- Na tela de abertura do checklist:
  . Informar o Título/Nome do checklist (Poderá ser gerado automaticamente pelo sistema para se manter um padrão)
  . Informar uma breve descrição do checklist
  . Selecionar o veículo

- Após a geração do cabeçalho e a importação do checklist (associado ao cabeçalho), o id da lista de itens deverá ser associada ao cabeçalho e deverá ser apresentada a lista de itens do checklist por grupos (Ex.: Mecânica, Lataria, Elétrica, Acessórios, Outros, etc...), para o veículo.

- Ao final
  . Selecionar o supervisor
  . Informar as observações gerais ou comentários
  . Atualizar o status do checklist

## Exemplos de Itens para cadastro

### Benefícios

- Cristalização do Para-brisas
- Reparo de Pneus
- Regulagem Foco do Farol
- Revisão de Luzes
- Rodízio de Pneus
- Rastreador
- Inspeção Veicular Computadorizada
- Analise de Gases

### Serviços/Diagnóstico

- Lubrificantes
- Alinhamento/Balanceamento
- Suspenção/Direção
- Freios
- Correias
- Embreagem
- Sistema de Arrefecimento
- Pneus
- Motor Falhando

### Mecânica

- Correia Dentada
- Velas de ignição
- Pastilhas de Freios
- Lonas de Freios
- Óleo do Motor
- Óleo da Embreagem
- Embreagem
- Caixa de Direção

### Lataria

- Porta Dianteira Esquerda
- Paralama Dianteiro Esquerdo
- Pneu Esquerdo
- Capo
- Para-brisa
- Parachoque Dianteiro
- Paralama Dianteiro Direito
- Pneu Dianteiro Direito
- Porta Dianteira Direita
- Porta Trazeira Direita
- Pneu Trazeiro Direito
- Lateral Trazeira Direita
- Tampa Trazeira / Porta Malas
- Parachoque Trazeiro
- Lateral Trazeira Esquerda
- Porta Trazeira Esquerda
- Pneu Trazeiro Esquerdo
- Teto
- Caixa de Ar Esquerda
- Caixa de Ar Direita

### Elétrica

- Faróis
- Lanternas

### Acessórios

- Estepe
- Triangulo
- Macaco
- Tapetes
