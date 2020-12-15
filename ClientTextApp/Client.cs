using System;
using System.Net.Sockets;
using Communication;

namespace ClientTextApp
{
    class Client
    {
        private string hostname;
        private int port;

        public Client(string h, int p)
        {
            hostname = h;
            port = p;
        }

        public void start()
        {
            bool status;
            TcpClient comm = new TcpClient(hostname, port);
            Console.WriteLine("Connection established");
            while (true)
            {
                Console.WriteLine("Create user & pass");
                string uName = Console.ReadLine();
                string uPass = Console.ReadLine();
                
                Net.sendMsg(comm.GetStream(), new UserInfo((int)MType.NEWACC,uName,uPass));

                status = ((Response) Net.rcvMsg(comm.GetStream())).Res;

                if (status)
                {
                    Console.WriteLine("User Created");
                }
                else
                {
                    Console.WriteLine("User already exists!");
                }

                do
                {
                    Console.WriteLine("Login");
                    uName = Console.ReadLine();
                    uPass = Console.ReadLine();

                    Net.sendMsg(comm.GetStream(), new UserInfo((int) MType.LOGIN, uName, uPass));

                    status = ((Response) Net.rcvMsg(comm.GetStream())).Res;

                    if (status)
                    {
                        Console.WriteLine("Logged In!");
                    }
                    else
                    {
                        Console.WriteLine("Incorrect username or password");
                    }
                } while (!status);
            }
        }

    }
}