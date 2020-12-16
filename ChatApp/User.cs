using System.Net.Sockets;

namespace ChatApp
{
    public class User
    {
        private string _name;
        private string _password;
        private TcpClient _comm;

        public User(string name, string password, TcpClient comm)
        {
            _name = name;
            _password = password;
            _comm = comm;
        }

        public string Name => _name;

        public TcpClient Comm => _comm;

        /**
         * Authenticates login and password and assigns tcp connection to account
         */
        public bool Authenticate(string uName, string uPass, TcpClient comm)
        {
            if (uName.Equals(_name) && uPass.Equals(_password))
            {
                _comm = comm;
                return true;
            }
            return false;
        }

        /**
         * Unassigns TCP connection when disconnecting
         */
        public void LogOut()
        {
            _comm = null;
        }
    }
}