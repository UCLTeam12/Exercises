using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Socket_Programming;

static class Program
{
    private static byte[] _buffer = new byte[1024];
    private static List<Socket> _clientSockets = new List<Socket>();
    private static Socket _serverSocket = new Socket
        (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

    static void Main(string[] args)
    {
        SetupSever();
        Console.ReadLine();
    }

    private static void SetupSever()
    {
        Console.WriteLine("Server starting up");
        _serverSocket.Bind(new IPEndPoint(IPAddress.Any, 100));
        _serverSocket.Listen(1);
        _serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
    }

    private static void AcceptCallback(IAsyncResult asyncResult)
    {
        Socket socket = _serverSocket.EndAccept(asyncResult);
        _clientSockets.Add(socket);
        Console.WriteLine("Client Connect");
        socket.BeginReceive
            (_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceivedCallback),socket);
        _serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
    }

    private static void ReceivedCallback(IAsyncResult asyncResult)
    {
        var socket = (Socket)asyncResult.AsyncState;
        var received = socket.EndReceive(asyncResult);
        var dataBuffer = new byte [received];
        Array.Copy(_buffer, dataBuffer, received);

        string text = Encoding.ASCII.GetString(dataBuffer);
        Console.WriteLine("Text received: " + text);

        string response = string.Empty;
        
        if (text.ToLower() != "get time")
        {
            response = "Bad request";
        }
        else
        {
            response = DateTime.UtcNow.ToLongTimeString();
        }
        byte[] data = Encoding.ASCII.GetBytes(text);
        socket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallback), socket);

    }



    private static void SendCallback(IAsyncResult asyncResult)
    {
        var socket = (Socket)asyncResult.AsyncState;
        socket.EndSend(asyncResult);
    }
}

