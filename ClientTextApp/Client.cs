﻿using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using Communication;

namespace ClientTextApp
{
    class Client
    {
        private string hostname;
        private int port;
        
        private TcpClient comm;

        public Client(string h, int p)
        {
            hostname = h;
            port = p;
        }

        public void start()
        {
            bool exit=false;
            string choice, uName, uPass;
            comm = new TcpClient(hostname, port);
            Console.WriteLine("Connection established");
            
            do
            {
                //We start the program by asking the user to create an account and/or log in
                Console.WriteLine("Select an option:");
                Console.WriteLine(" 1. Create Account");
                Console.WriteLine(" 2. Log In");
                Console.WriteLine(" 3. Exit");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("New Username:");
                        uName = Console.ReadLine();
                        Console.WriteLine("Password:");
                        uPass = Console.ReadLine();
                        
                        Net.sendMsg(comm.GetStream(), new UserInfo((int) MTypes.NEWACC, uName, uPass));

                        if (((Response) Net.rcvMsg(comm.GetStream())).Res)
                        {
                            Console.WriteLine("User Created");
                        } else
                        {
                            Console.WriteLine("User already exists!");
                        }
                        break;
                    
                    case "2":
                        Console.WriteLine("Username:");
                        uName = Console.ReadLine();
                        Console.WriteLine("Password:");
                        uPass = Console.ReadLine();
                        
                        Net.sendMsg(comm.GetStream(), new UserInfo((int) MTypes.LOGIN, uName, uPass));

                        if (((Response) Net.rcvMsg(comm.GetStream())).Res)
                        {
                            Console.WriteLine("Logged In!");
                            //once loggged in, move to the topic menu
                            TopicMenu(uName);
                        } else
                        {
                            Console.WriteLine("Incorrect username or password");
                        }
                        break;
                    
                    case "3":
                        exit = true;
                        //Sends request to properly close connection on server side
                        Net.sendMsg(comm.GetStream(),new Response((int) MTypes.CLOSE, false));
                        break;
                    
                    default:
                        Console.WriteLine("Invalid Entry");
                        break;
                }
            } while (!exit);
        }

        public void TopicMenu(string uName)
        {
            bool exit=false;
            string choice;

            do
            {
                Console.WriteLine("Select an option:");
                Console.WriteLine(" 1. View Topics");
                Console.WriteLine(" 2. Create Topic");
                Console.WriteLine(" 3. Join Topic");
                Console.WriteLine(" 4. Log out");
                
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Net.sendMsg(comm.GetStream(), new TopicInfo((int) MTypes.VIEWTOP, null));
                        
                        Console.WriteLine(((TopicInfo) Net.rcvMsg(comm.GetStream())).TName);
                        break;

                    case "2":
                        Console.WriteLine("New Topic Name:");
                        string newTopic = Console.ReadLine();
                        
                        Net.sendMsg(comm.GetStream(), new TopicInfo((int) MTypes.NEWTOP, newTopic));

                        if (((Response) Net.rcvMsg(comm.GetStream())).Res)
                        {
                            Console.WriteLine("Topic Created");
                        }
                        else
                        {
                            Console.WriteLine("Topic Already Exists!");
                        }

                        break;

                    case "3":
                        Console.WriteLine("Enter Topic Name:");
                        string tName = Console.ReadLine();
                        
                        Net.sendMsg(comm.GetStream(), new TopicInfo((int) MTypes.JOINTOP, tName));

                        if (((Response) Net.rcvMsg(comm.GetStream())).Res)
                        {
                            Console.WriteLine("Topic Joined");
                            //Move inside the chatroom if the topic had been joined
                            ChatRoom(uName);
                        }
                        else
                        {
                            Console.WriteLine("Topic Doesn't Exists!");
                        }

                        break;

                    case "4":
                        //Logs out the user by disassociating the tcp connection with the account
                        Net.sendMsg(comm.GetStream(), new UserInfo((int) MTypes.LOGOUT,null,null));
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid Entry");
                        break;
                }
            } while (!exit);
        }

        public void ChatRoom(string uName)
        {
            //Starts a new thread to simultaneously listen and display received messages
            Thread th = new Thread(MessageReceiver);
            th.Start();
            
            Console.WriteLine("Write Messages or 'quit' to leave topic");
            string input;
            //Automatically sends a message to tell all connected users that a new user has joined the topic
            Net.sendMsg(comm.GetStream(), new ChatMessage((int) MTypes.CHATWELCOME,uName,null));

            do
            {
                input = Console.ReadLine();
                if (input != "quit")
                {
                    Net.sendMsg(comm.GetStream(), new ChatMessage((int) MTypes.CHATMESSAGE,uName,input));
                }
            } while (input != "quit");
            //Sends a messagge to disconnect user from topic
            Net.sendMsg(comm.GetStream(), new TopicInfo((int) MTypes.LEAVETOP,null));
        }

        public void MessageReceiver()
        {
            bool cancel = false;
            
            //Continuously receives and displays messages
            do
            {
                ChatMessage message = (ChatMessage) Net.rcvMsg(comm.GetStream());
                
                //This allows the thread to stop listening and close when the server tells it the user left the topic
                if (message.MType == (int) MTypes.CHATLEAVE)
                {
                    cancel = true;

                }
                else
                {
                    if (message.MType == (int) MTypes.CHATWELCOME)
                    {
                        Console.WriteLine(message.Sender + " joined the Topic!");
                    }
                    else
                    {
                        Console.WriteLine(message.ToString());
                    }
                }
            } while (!cancel);
        }
    }
}