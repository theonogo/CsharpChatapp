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

        /**
         * Returns the corresponding topic object given a topic name
         * Returns null if innexistant
         */
        public Topic FindTopic(string name)
        {
            foreach (Topic t in _topics)
            {
                if (t.Name.Equals(name)) return t;
            }
            
            return null;
        }

        /**
         * Creates a new topic with given name
         * returns false if topic exists already
         */
        public bool NewTopic(string name)
        {
            if (FindTopic(name) != null)
            {
                return false;
            }
            
            _topics.Add(new Topic(name));
            return true;
        }

        /**
         * Adds a user to a topic if the topic exists.
         * Returns false otherwise
         */
        public bool JoinTopic(string name, string newUser)
        {
            Topic t = FindTopic(name);
            if (t == null)
            {
                return false;
            }

            return t.ConnectUser(newUser);
        }

        /**
         * Disconnects a user from every topic they might be connected to
         **/
        public void LeaveTopic(string user)
        {
            foreach (Topic t in _topics)
            {
                t.DisconnectUser(user);
            }
        }

        /**
         * Given a username, return list of all usernames in the same topic
         **/
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

        /**
         * Displays every topic
         **/
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