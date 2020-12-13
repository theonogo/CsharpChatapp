using System.Collections.Generic;

namespace ChatApp
{
    public class Topic
    {
        private string _name;
        private List<string> _connectedUsers;

        public Topic(string name)
        {
            _name = name;
            _connectedUsers = new List<string>();
        }

        public string Name => _name;

        public bool ConnectUser(string user)
        {
            if (_connectedUsers.Contains(user)) return false;

            _connectedUsers.Add(user);
            return true;
        }

        public bool DisconnectUser(string user)
        {
            return _connectedUsers.Remove(user);
        }

        public override string ToString()
        {
            string outStr=_name;
            outStr += "\n===Connected Users===";
            foreach (string u in _connectedUsers)
            {
                outStr += "\n   " + u;
            }
            outStr += "\n===================== \n";

            return outStr;
        }

        public string ListUsers()
        {
            string outStr="";
            foreach (string u in _connectedUsers)
            {
                outStr += u;
            }

            return outStr;
        }
    }
}