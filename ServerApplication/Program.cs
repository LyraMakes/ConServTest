using System.Net;
using System.Net.Sockets;
using System.Text;

using ConServCore;

using Newtonsoft.Json;

namespace ConServTest.Server;

internal static class Program
{
    public static void Main(string[] args)
    {
        // Create a listener on the specified port.
        TcpListener listener = new TcpListener(IPAddress.Loopback, 54230);
        listener.Start();

        Console.WriteLine("Listening for connections...");
        
        // Accept connections until the server is stopped.
        while (true)
        {
            // Wait for a connection.
            TcpClient client = listener.AcceptTcpClient();
            Console.WriteLine("Client connected.");

            // Get a stream object for reading and writing.
            NetworkStream stream = client.GetStream();

            // Read the request from the client.
            byte[] buffer = new byte[client.ReceiveBufferSize];
            int bytesRead = stream.Read(buffer, 0, client.ReceiveBufferSize);
            string request = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            Console.WriteLine("Request: " + request);

            // Write the response back to the client.
            string response = "Hello World!";
            byte[] responseBytes = Encoding.ASCII.GetBytes(response);
            stream.Write(responseBytes, 0, responseBytes.Length);
            Console.WriteLine("Response: " + response);

            // Close the connection.
            client.Close();
        }      
    }

    private static string CleanMessage(byte[] bytes)
    {
        return Encoding.Unicode.GetString(bytes)
            .Where(c => c != '\0')
            .Aggregate<char, string>("", (current, c) => current + c);
    }
        
}