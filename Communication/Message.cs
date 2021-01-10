using System;
using System.Reflection.Metadata.Ecma335;

namespace Communication
{
    /**
     * Parent abstract class that simply defines the type of message
     */
    [Serializable]
    public abstract class Message
    {
        //informs the type of request/response. Each message child can serve multiple purposes thanks to this var
        private int _mType;

        protected Message(int mType)
        {
            _mType = mType;
        }

        public int MType => _mType;
    }
    
    /**
     * Sending of username and password for login or sign up purposes
     */
    [Serializable]
    public class UserInfo : Message
    {
        private string _name;
        private string _pass;

        public UserInfo(int mType, string name, string pass) : base(mType)
        {
            _name = name;
            _pass = pass;
        }

        public string Name => _name;

        public string Pass => _pass;
        
    }
        
    /**
     * Basic boolean response to a request
     */
    [Serializable]
    public class Response : Message
    {
        private bool _res;

        public Response(int mType, bool res) : base(mType)
        {
            this._res = res;
        }

        public bool Res => _res;
    }
    
    /*
     * Message dealing with Creating, Joining, Leaving, and viewing a topic
     */
    [Serializable]
    public class TopicInfo : Message
    {
        private string _tName;

        public TopicInfo(int mType, string tName) : base(mType)
        {
            _tName = tName;
        }

        public string TName => _tName;
    }

    /*
     * Chat messages with sender name and message content
     */
    [Serializable]
    public class ChatMessage : Message
    {
        private string _sender;
        private string _message;

        public ChatMessage(int mType, string sender, string message) : base(mType)
        {
            _sender = sender;
            _message = message;
        }

        public string Sender => _sender;

        public string Message => _message;

        public override string ToString()
        {
            return _sender + ": " + _message;
        }
    }
    
    /*
 * Chat messages with sender name and message content
 */
    [Serializable]
    public class DirectMessage : ChatMessage
    {
        private string _recipient;

        public DirectMessage(int mType, string sender, string message, string recipient) : base(mType, sender, message)
        {
            _recipient = recipient;
        }

        public string Recipient => _recipient;

        public override string ToString()
        {
            
            return " DM " + base.ToString();
        }
    }
}