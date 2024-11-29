# Controle de Produtos

## Integrantes
- João Vitor Bagatoli
- Lucca dos Santos

## Arquitetura
**Client-Server**  
Este software utiliza a arquitetura cliente-servidor, onde o cliente envia solicitações para o servidor, que processa as requisições e retorna respostas.

## Tecnologias Utilizadas
- Linguagem: C#
- Frameworks: .NET Core
- Bibliotecas padrão: System.Net.Sockets, System.Text
- Ambiente de desenvolvimento: Visual Studio 2022 ou superior

## Descrição do Software
O **Controle de Produtos** é uma aplicação para gerenciar produtos de forma simples. Através do cliente, é possível:
1. Cadastrar produtos, informando nome, preço e quantidade.
2. Consultar uma lista de produtos cadastrados no servidor.

O servidor processa as solicitações do cliente e retorna as respostas conforme o protocolo definido.

## Protocolo e Estrutura das Mensagens

### Estrutura das Mensagens
- **Cadastrar Produto**  
  Mensagem enviada pelo cliente:
