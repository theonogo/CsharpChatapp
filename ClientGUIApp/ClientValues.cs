using System.Net.Sockets;

//Saves TCP connection and username values across forms
namespace ClientGUIApp
{
    public static class ClientValues
    {
        private static string _hostname;
        private static int _port;
        
        private static TcpClient _comm;

        private static string _uName;

        public static string Hostname
        {
            get => _hostname;
            set => _hostname = value;
        }

        public static int Port
        {
            get => _port;
            set => _port = value;
        }

        public static TcpClient Comm
        {
            get => _comm;
            set => _comm = value;
        }

        public static string UName
        {
            get => _uName;
            set => _uName = value;
        }
    }
}