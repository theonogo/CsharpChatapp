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

        public bool CreateUser(string uName, string uPass, TcpClient comm)
        {
            if (FindUser(uName)!= null) return false;

            _users.Add(new User(uName, uPass, comm));

            return true;
        }

        public User FindUser(string uName)
        {
            foreach (var u in _users)
            {
                if (u.checkName(uName))
                {
                    return u;
                }
            }

            return null;
        }

        public bool Login(string uName, string uPass, TcpClient comm)
        {
            foreach (User u in _users)
            {
                if (u.Authenticate(uName, uPass, comm)) return true;
            }

            return false;
        }
    }
}