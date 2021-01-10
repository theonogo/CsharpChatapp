using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;

namespace ChatApp
{
    public class UserList
    {
        private List<User> _users;

        public UserList()
        {
            
            if (File.Exists("users.bin"))
            {
                FileStream stream = null;
                try
                {
                    stream = File.Open("users.bin",FileMode.Open);
                    BinaryFormatter formatter = new BinaryFormatter();
                    _users = (List<User>) formatter.Deserialize(stream);
                    stream.Close();
                }
                catch (Exception e)
                {
                    _users = new List<User>();
                    Console.WriteLine("Users unable to be loaded.");
                    if(stream!= null)
                        stream.Close();
                }
            } else {
                _users = new List<User>();
            }
        }

        /**
         * Serializes and saves the list of users
         */
        public void SaveUsers()
        {
            FileStream stream = File.Create("users.bin");
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, _users);
            stream.Close();
        }

        /**
         * Creates a new User if a user with that name does not already exist
         */
        public bool CreateUser(string uName, string uPass, NetworkStream comm)
        {
            if (FindUser(uName)!= null) return false;

            _users.Add(new User(uName, uPass, null));
            SaveUsers();

            return true;
        }

        /**
         * Finds a user object from a given name
         * Returns null if user cannot be found
         */
        public User FindUser(string uName)
        {
            foreach (var u in _users)
            {
                if (u.Name == uName)
                {
                    return u;
                }
            }
            return null;
        }
        
        /**
         * Finds a user object from a given TCP connection
         * Returns null if user cannot be found
         */
        public User FindUser(NetworkStream comm)
        {
            foreach (var u in _users)
            {
                if (u.Comm == comm)
                {
                    return u;
                }
            }
            return null;
        }

        /**
         * Logs a user in by verifying credentials against all registered accounts
         * Also updates users TCP connection
         * returns false if given incorrect credentials
         */
        public bool Login(string uName, string uPass, NetworkStream comm)
        {
            foreach (User u in _users)
            {
                if (u.Authenticate(uName, uPass, comm)) return true;
            }

            return false;
        }

        /**
         * Verifies the connected TCP client is actually logged in
         */
        public bool CheckLogged(NetworkStream comm)
        {
            if (FindUser(comm) != null)
            {
                return true;
            }

            return false;
        }

        /**
         * logs a user out given their TCP connection
         */
        public void Logout(NetworkStream comm)
        {
            FindUser(comm).LogOut();
        }
    }
}