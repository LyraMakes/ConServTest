
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ConServTest.Client;

internal static class Program
{
    public static void Main(string[] args)
    {
        // Connect to server on localhost:54230 and send message
        var client = new TcpClient("localhost", 54230);
        var stream = client.GetStream();
        var message = "Hello World!";
        var data = Encoding.ASCII.GetBytes(message);
        stream.Write(data, 0, data.Length);
        Console.WriteLine("Sent: {0}", message);
    }
}