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
                Console.WriteLine("Connection established");
                //For each connection, a thread is started to receive and process requests
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
                bool open = true;
                while (open)
                {
                    // Receive expression
                    Message msg = Net.rcvMsg(comm.GetStream());

                    //Finds user sub-type to decide which Manager should deal with the message
                    if (msg is UserInfo)
                    {
                        LogManager((UserInfo) msg);
                    }
                    //Verifies user is actually logged in to deal with topics and messages
                    else if (_userList.CheckLogged(comm.GetStream())) 
                    {
                        if (msg is TopicInfo)
                        {
                            TopicManager((TopicInfo) msg);
                        } else if (msg is DirectMessage)
                        {
                            DmManager((DirectMessage)msg);
                        } else if (msg is ChatMessage)
                        {
                            ChatManager((ChatMessage) msg);
                        }
                    } 
                    //Safely closes TCP connection on Client exit
                    else if (msg.MType == (int) MTypes.CLOSE)
                    {
                        open = false;
                        comm.GetStream().Close();
                        comm.Close();
                        Console.WriteLine("Connection Closed");
                    }
                }
            }

            /**
             * Deals with login, sign up, and log out
             */
            public void LogManager(UserInfo usr)
            {
                switch (usr.MType)
                {
                    case (int) MTypes.LOGIN:
                        //Send message to confirm or deny login
                        Net.sendMsg(comm.GetStream(), new Response((int)MTypes.LOGIN,_userList.Login(usr.Name, usr.Pass, comm.GetStream())));
                        break;
                            
                    case (int) MTypes.NEWACC:
                        //Send message to confirm or deny sign up
                        Net.sendMsg(comm.GetStream(), new Response((int)MTypes.LOGIN,_userList.CreateUser(usr.Name, usr.Pass, null)));
                        break;
                    case (int) MTypes.LOGOUT:
                        _userList.Logout(comm.GetStream());
                        //Sends a leave message to user as confirmation so the listening thread can end
                        Net.sendMsg(comm.GetStream(), new ChatMessage((int) MTypes.CHATLEAVE, null, null));
                        break;
                }
            }

            /**
             * Deals with Topic creation, view, connection, and deconnection
             */
            public void TopicManager(TopicInfo tp)
            {
                switch (tp.MType)
                {
                    case (int)MTypes.NEWTOP :
                        //Send message to confirm or deny topic creation
                        Net.sendMsg(comm.GetStream(), new Response((int)MTypes.NEWTOP, _topics.NewTopic(tp.TName)));
                        break;
                                
                    case (int)MTypes.JOINTOP :
                        //Send message to confirm or deny topic connection
                        Net.sendMsg(comm.GetStream(), new Response((int)MTypes.JOINTOP, _topics.JoinTopic(tp.TName,_userList.FindUser(comm.GetStream()).Name)));
                        break;
                                
                    case (int)MTypes.VIEWTOP :
                        //Sends list of topics and all connected accounts
                        Net.sendMsg(comm.GetStream(), new TopicInfo((int) MTypes.VIEWTOP,_topics.ToString(), _topics.ToList()));
                        break;
                                
                    case (int) MTypes.LEAVETOP :
                        _topics.LeaveTopic(_userList.FindUser(comm.GetStream()).Name);
                        break;
                }
            }

            /**
             * Manages the broadcast of messages to all users in a topic
             * This includes the sender of the message so they can have confirmation their message has sent
             */
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
                        Net.sendMsg(recipient.Comm,cmsg);
                    }
                }
            }

            public void DmManager(DirectMessage dm)
            {
                User recipient = _userList.FindUser(dm.Recipient);

                if (recipient != null)
                {
                    if (recipient.Comm != null)
                    {
                        Net.sendMsg(recipient.Comm,dm);
                        Net.sendMsg(comm.GetStream(),dm);
                    }
                }
            }
        }
    }
    
    
}