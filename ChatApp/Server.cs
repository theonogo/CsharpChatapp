using System;
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
                while (true)
                {
                    // read expression
                    Message msg = Net.rcvMsg(comm.GetStream());
    
                    Console.WriteLine("expression received");
                    // send result
    
                    if (msg is UserInfo)
                    {
                        UserInfo usr = (UserInfo) msg;
                        switch (usr.MType)
                        {
                            case (int) MTypes.LOGIN:
                                Net.sendMsg(comm.GetStream(), new Response((int)MTypes.LOGIN,_userList.Login(usr.Name, usr.Pass, comm)));
                                break;
                            
                            case (int) MTypes.NEWACC:
                                Net.sendMsg(comm.GetStream(), new Response((int)MTypes.LOGIN,_userList.CreateUser(usr.Name, usr.Pass, null)));
                                break;
                        }
                    } else if (_userList.CheckLogged(comm)) 
                    {
                        if (msg is TopicInfo)
                        {
                            TopicInfo tp = (TopicInfo) msg;

                            switch (tp.MType)
                            {
                                case (int)MTypes.NEWTOP :
                                    Net.sendMsg(comm.GetStream(), new Response((int)MTypes.NEWTOP, _topics.NewTopic(tp.TName)));
                                    break;
                                
                                case (int)MTypes.JOINTOP :
                                    User joining = _userList.FindUser(comm);
                                    Net.sendMsg(comm.GetStream(), new Response((int)MTypes.NEWTOP, _topics.JoinTopic(tp.TName,joining.Name)));
                                    break;
                            }
                        }
                    }
                }
            }
        }
    }
    
    
}