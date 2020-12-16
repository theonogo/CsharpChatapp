using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Threading;
using Communication;

namespace ChatApp
{
    public class Server
    {
        private static int _port;
        private static TopicList _topics;
        private static UserList _userList;

        public Server(int port)
        {
            _port = port;
            _topics = new TopicList();
            _userList = new UserList();
        }

        public void start()
        {
            TcpListener l = new TcpListener(new IPAddress(new byte[] { 127, 0, 0, 1 }), _port);
            l.Start();

            while (true)
            {
                TcpClient comm = l.AcceptTcpClient();
                Console.WriteLine("Connection established @" + comm);
                new Thread(new Receiver(comm).ProcessRequest).Start();
            }
        }
        
        class Receiver
        {
            private TcpClient comm;
    
            public Receiver(TcpClient s)
            {
                comm = s;
            }
    
            public void ProcessRequest()
            {
                Console.WriteLine("Computing operation");
                bool open = true;
                while (open)
                {
                    // read expression
                    Message msg = Net.rcvMsg(comm.GetStream());
    
                    Console.WriteLine("expression received");
                    // send result
    
                    if (msg is UserInfo)
                    {
                        LogManager((UserInfo) msg,comm);
                    } else if (_userList.CheckLogged(comm)) 
                    {
                        if (msg is TopicInfo)
                        {
                            TopicManager((TopicInfo) msg,comm);
                        } else if (msg is ChatMessage)
                        {
                            ChatManager((ChatMessage) msg);
                        }
                    } else if (msg.MType == (int) MTypes.CLOSE)
                    {
                        open = false;
                        comm.GetStream().Close();
                        comm.Close();
                    }
                }
            }

            public void LogManager(UserInfo usr, TcpClient comm)
            {
                switch (usr.MType)
                {
                    case (int) MTypes.LOGIN:
                        Net.sendMsg(comm.GetStream(), new Response((int)MTypes.LOGIN,_userList.Login(usr.Name, usr.Pass, comm)));
                        break;
                            
                    case (int) MTypes.NEWACC:
                        Net.sendMsg(comm.GetStream(), new Response((int)MTypes.LOGIN,_userList.CreateUser(usr.Name, usr.Pass, null)));
                        break;
                    case (int) MTypes.LOGOUT:
                        _userList.Logout(comm);
                        break;
                }
            }

            public void TopicManager(TopicInfo tp, TcpClient comm)
            {
                switch (tp.MType)
                {
                    case (int)MTypes.NEWTOP :
                        Net.sendMsg(comm.GetStream(), new Response((int)MTypes.NEWTOP, _topics.NewTopic(tp.TName)));
                        break;
                                
                    case (int)MTypes.JOINTOP :
                        Net.sendMsg(comm.GetStream(), new Response((int)MTypes.NEWTOP, _topics.JoinTopic(tp.TName,_userList.FindUser(comm).Name)));
                        break;
                                
                    case (int)MTypes.VIEWTOP :
                        Net.sendMsg(comm.GetStream(), new TopicInfo((int) MTypes.VIEWTOP,_topics.ToString()));
                        break;
                                
                    case (int) MTypes.LEAVETOP :
                        _topics.LeaveTopic(_userList.FindUser(comm).Name);
                        Net.sendMsg(comm.GetStream(), new ChatMessage((int) MTypes.CHATLEAVE, null, null));
                        break;
                }
            }

            public void ChatManager(ChatMessage cmsg)
            {
                List<string> broadcastList;
                User recipient;

                broadcastList= _topics.GetBroadcast(cmsg.Sender);

                foreach (string uName in broadcastList)
                {
                    recipient = _userList.FindUser(uName);
                    if (recipient.Comm != null)
                    {
                        Net.sendMsg(recipient.Comm.GetStream(),cmsg);
                    }
                }

            }
        }
    }
    
    
}