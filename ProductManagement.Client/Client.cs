using System.Net.Sockets;
using System.Text;

public class Client
{
    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("1. Cadastrar Produto");
            Console.WriteLine("2. Consultar Produtos");
            Console.WriteLine("3. Sair");
            Console.Write("Escolha uma opção: ");
            var choice = Console.ReadLine();

            if (choice == "3")
                break;

            // Prepara a mensagem conforme o protocolo
            string message;
            if (choice == "1")
            {
                Console.Write("Nome do produto: ");
                var name = Console.ReadLine();

                Console.Write("Preço do produto: ");
                var price = Console.ReadLine();

                Console.Write("Quantidade: ");
                var quantity = Console.ReadLine();

                message = $"CADASTRAR|{name.Length}|{name}|{price}|{quantity}";
            }
            else if (choice == "2")
            {
                message = "CONSULTAR|0|";
            }
            else
            {
                Console.WriteLine("Opção inválida.");
                continue;
            }

            // Envia a mensagem ao servidor
            var client = new TcpClient("127.0.0.1", 9000);
            var stream = client.GetStream();

            var messageBytes = Encoding.UTF8.GetBytes(message);
            stream.Write(messageBytes, 0, messageBytes.Length);

            // Recebe a resposta
            var buffer = new byte[1024];
            var bytesRead = stream.Read(buffer, 0, buffer.Length);
            var response = Encoding.UTF8.GetString(buffer, 0, bytesRead);

            Console.WriteLine($"Resposta do servidor: {response}");

            // Fecha o cliente
            client.Close();
        }
    }
}

