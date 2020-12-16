using System.Collections.Generic;
using System.Net.Sockets;

namespace ChatApp
{
    public class TopicList
    {
        public List<Topic> _topics;

        public TopicList()
        {
            _topics= new List<Topic>();
        }

        public Topic FindTopic(string name)
        {
            foreach (Topic t in _topics)
            {
                if (t.Name.Equals(name)) return t;
            }
            
            return null;
        }

        public bool NewTopic(string name)
        {
            if (FindTopic(name) != null)
            {
                return false;
            }
            
            _topics.Add(new Topic(name));
            return true;
        }

        public bool JoinTopic(string name, string newUser)
        {
            Topic t = FindTopic(name);
            if (t == null)
            {
                return false;
            }

            return t.ConnectUser(newUser);
        }

        public void LeaveTopic(string user)
        {
            foreach (Topic t in _topics)
            {
                t.DisconnectUser(user);
            }
        }

        public List<string> GetBroadcast(string user)
        {
            foreach (Topic t in _topics)
            {
                if (t.ConnectedUsers.Contains(user))
                {
                    return t.ConnectedUsers;
                }
            }

            return null;
        }

        public override string ToString()
        {
            string outStr = _topics.Count + " Topics: \n";
            foreach (Topic t in _topics)
            {
                outStr += t;
            }
            return outStr;
        }
    }
}