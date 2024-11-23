using System.Net;
using System.Net.Sockets;
using System.Text;

public class Server
{
    public static void Main()
    {
        var server = new TcpListener(IPAddress.Any, 9000);
        server.Start();

        Console.WriteLine("Server started. Waiting for connections...");

        while (true)
        {
            var client = server.AcceptTcpClient();
            var stream = client.GetStream();

            // Recebe a mensagem do cliente
            var buffer = new byte[1024];
            var bytesRead = stream.Read(buffer, 0, buffer.Length);
            var request = Encoding.UTF8.GetString(buffer, 0, bytesRead);

            Console.WriteLine($"Received: {request}");

            // Processa a mensagem
            var response = ProcessMessage(request);

            // Envia a resposta ao cliente
            var responseBytes = Encoding.UTF8.GetBytes(response);
            stream.Write(responseBytes, 0, responseBytes.Length);

            // Fecha a conexão
            client.Close();
        }
    }

    private static string ProcessMessage(string message)
    {
        var parts = message.Split('|');
        var command = parts[0];

        if (command == "CADASTRAR")
        {
            // Exemplo: CADASTRAR|20|Notebook|3500.50|10
            var productName = parts[2];
            var price = decimal.Parse(parts[3]);
            var quantity = int.Parse(parts[4]);

            // Simula o cadastro
            Console.WriteLine($"Cadastrando produto: {productName}, Preço: {price}, Quantidade: {quantity}");
            return "OK|Produto cadastrado com sucesso";
        }
        else if (command == "CONSULTAR")
        {
            // Simula uma consulta de produtos
            return "OK|Lista de produtos: Notebook, Teclado";
        }

        return "ERROR|Comando inválido";
    }
}

