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
**CADASTRAR|0|<Nome do Produto>|<Preço>|<Quantidade>**
Exemplo: `CADASTRAR|0|Notebook|3500.50|10`

- **Consultar Produtos**  
Mensagem enviada pelo cliente:
**CONSULTAR|0|**

### Respostas do Servidor

- **Sucesso no cadastro**
`OK|Produto cadastrado com sucesso`

- **Lista de produtos cadastrados**
`OK|<ID>:<Nome> - <Preço> (<Quantidade> unidades)`

- **Nenhum produto cadastrado**
`OK|Nenhum produto cadastrado`

- **Comando inválido**
`ERROR|Comando inválido`

## Como Reproduzir o Software

### Requisitos
1. Instale o .NET SDK 6.0 ou superior. [Link para download](https://dotnet.microsoft.com/download)
2. Use um editor de sua escolha, como:
 - [Visual Studio 2022](https://visualstudio.microsoft.com/)
 - [Visual Studio Code](https://code.visualstudio.com/)

### Passos
1. **Configuração do Servidor:**
 - Abra o arquivo `Server.cs` no editor.
 - Compile o arquivo utilizando o comando:
   ```
   dotnet build
   ```
 - Execute o servidor com o comando:
   ```
   dotnet run
   ```
 O servidor estará em execução e ouvindo conexões na porta `9000`.

2. **Configuração do Cliente:**
 - Abra o arquivo `Client.cs` no editor.
 - Compile e execute o cliente usando os mesmos comandos acima:
   ```
   dotnet build
   dotnet run
   ```

3. **Interação:**
 - Escolha as opções no menu do cliente para cadastrar ou consultar produtos.
 - O cliente enviará mensagens ao servidor, que responderá conforme o protocolo descrito acima.

### Observações
- Certifique-se de executar o servidor antes do cliente.
- Ambos os arquivos devem ser executados na mesma máquina para que a comunicação local funcione.
