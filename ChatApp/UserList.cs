using System.Collections.Generic;
using System.Net.Sockets;

namespace ChatApp
{
    public class UserList
    {
        private List<User> _users;

        public UserList()
        {
            _users = new List<User>();
        }

        /**
         * Creates a new User if a user with that name does not already exist
         */
        public bool CreateUser(string uName, string uPass, TcpClient comm)
        {
            if (FindUser(uName)!= null) return false;

            _users.Add(new User(uName, uPass, comm));

            return true;
        }

        /**
         * Finds a user object from a given name
         * Returns null if user cannot be found
         */
        public User FindUser(string uName)
        {
            foreach (var u in _users)
            {
                if (u.Name == uName)
                {
                    return u;
                }
            }
            return null;
        }
        
        /**
         * Finds a user object from a given TCP connection
         * Returns null if user cannot be found
         */
        public User FindUser(TcpClient comm)
        {
            foreach (var u in _users)
            {
                if (u.Comm == comm)
                {
                    return u;
                }
            }
            return null;
        }

        /**
         * Logs a user in by verifying credentials against all registered accounts
         * Also updates users TCP connection
         * returns false if given incorrect credentials
         */
        public bool Login(string uName, string uPass, TcpClient comm)
        {
            foreach (User u in _users)
            {
                if (u.Authenticate(uName, uPass, comm)) return true;
            }

            return false;
        }

        /**
         * Verifies the connected TCP client is actually logged in
         */
        public bool CheckLogged(TcpClient comm)
        {
            if (FindUser(comm) != null)
            {
                return true;
            }

            return false;
        }

        /**
         * logs a user out given their TCP connection
         */
        public void Logout(TcpClient comm)
        {
            FindUser(comm).LogOut();
        }
    }
}