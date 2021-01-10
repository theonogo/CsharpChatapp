using System;
using System.Net.Sockets;

namespace ChatApp
{
    [Serializable]
    public class User
    {
        private string _name;
        private string _password;
        [NonSerialized] private NetworkStream _comm;

        public User(string name, string password, NetworkStream comm)
        {
            _name = name;
            _password = password;
            _comm = comm;
        }

        public string Name => _name;

        public NetworkStream Comm => _comm;

        /**
         * Authenticates login and password and assigns tcp connection to account
         */
        public bool Authenticate(string uName, string uPass, NetworkStream comm)
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