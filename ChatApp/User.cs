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

        public bool Authenticate(string uName, string uPass, TcpClient comm)
        {
            if (uName.Equals(_name) && uPass.Equals(_password))
            {
                _comm = comm;
                return true;
            }
            return false;
        }

        public bool checkName(string uName)
        {
            return uName.Equals(_name);
        }
    }
}