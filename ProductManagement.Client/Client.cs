using System.Net.Sockets;
using System.Text;

public class Client
{
    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("---Controle de Produtos---");
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
                Console.Write("\nNome do produto: ");
                var name = Console.ReadLine();

                Console.Write("Preço do produto: ");
                if (!decimal.TryParse(Console.ReadLine(), out var price))
                {
                    Console.WriteLine("Preço inválido. Tente novamente.");
                    continue;
                }

                Console.Write("Quantidade: ");
                if (!int.TryParse(Console.ReadLine(), out var quantity))
                {
                    Console.WriteLine("Quantidade inválida. Tente novamente.");
                    continue;
                }

                message = $"CADASTRAR|0|{name}|{price}|{quantity}";
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

            var response = SendMessageToServer(message);
            Console.WriteLine($"Resposta do servidor: {response}\n");
        }
    }

    private static string SendMessageToServer(string message)
    {
        try
        {
            using (var client = new TcpClient("127.0.0.1", 9000))
            using (var stream = client.GetStream())
            {
                // Envia a mensagem ao servidor
                var messageBytes = Encoding.UTF8.GetBytes(message);
                stream.Write(messageBytes, 0, messageBytes.Length);

                // Recebe a resposta do servidor
                var buffer = new byte[1024];
                var bytesRead = stream.Read(buffer, 0, buffer.Length);
                return Encoding.UTF8.GetString(buffer, 0, bytesRead);
            }
        }
        catch (Exception ex)
        {
            return $"Erro ao conectar ao servidor: {ex.Message}";
        }
    }
}