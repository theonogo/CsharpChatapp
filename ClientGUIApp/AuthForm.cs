﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Communication;

namespace ClientGUIApp
{
    public partial class AuthForm : Form
    {
        public AuthForm()
        {
            InitializeComponent();
        }
        
        /*
         * Logs a user in as long as the info has been entered
         */
        private void LogClick(object sender, EventArgs e)
        {
            string uName = UserBox.Text;
            string uPass = PassBox.Text;

            if (uName != "" && uPass != "")
            {
                Net.sendMsg(ClientValues.Comm.GetStream(), new UserInfo((int) MTypes.LOGIN, uName, uPass));

                if (((Response) Net.rcvMsg(ClientValues.Comm.GetStream())).Res)
                {
                    InfoLabel.Text = "Logged In!";
                    UserBox.Text = "";
                    PassBox.Text = "";
                    ClientValues.UName = uName;
                    
                    //opens the menu form and hide the AuthForm until the menu form is closed.
                    Hide();
                    (new MenuForm()).ShowDialog();
                    Show();
                } else
                {
                    InfoLabel.Text = "Incorrect username or password";
                }
            }
            else
            {
                InfoLabel.Text = "You must enter a username and password";
            }
        }

        /*
         * Signs a user up as long as the info has been entered
         */
        private void SignClick(object sender, EventArgs e)
        {
            string uName = UserBox.Text;
            string uPass = PassBox.Text;

            if (uName != "" && uPass != "")
            {
                Net.sendMsg(ClientValues.Comm.GetStream(), new UserInfo((int) MTypes.NEWACC, uName, uPass));

                if (((Response) Net.rcvMsg(ClientValues.Comm.GetStream())).Res)
                {
                    InfoLabel.Text = "User Created";
                } else
                {
                    InfoLabel.Text = "User already exists!";
                }
            } 
            else
            {
                InfoLabel.Text = "You must enter a username and password";
            }
        }

        /*
         * Safely closes the connection to the server when the window is closed.
         */
        private new void Closing(object sender, FormClosedEventArgs e)
        {
            Net.sendMsg(ClientValues.Comm.GetStream(),new Response((int) MTypes.CLOSE, false));
        }
    }
}