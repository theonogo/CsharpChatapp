using System;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using Communication;
using Message = Communication.Message;

namespace ClientGUIApp
{
    public partial class MenuForm : Form
    {
        private string currTopic;
        
        private NetworkStream comm = ClientValues.Comm.GetStream();
        public MenuForm()
        {
            InitializeComponent();
            currTopic = null;
            
            Thread th = new Thread(Receiver);
            th.Start();
            
            RefreshClick(null, null);
        }

        private void RefreshClick(object sender, EventArgs e)
        {
            Net.sendMsg(comm, new TopicInfo((int) MTypes.VIEWTOP, null));
        }

        private void AddTopic(object sender, EventArgs e)
        {
            String tName = NewTopicBox.Text;
            if (tName != "")
            {
                Net.sendMsg(comm, new TopicInfo((int) MTypes.NEWTOP, tName));
                Net.sendMsg(comm, new TopicInfo((int) MTypes.VIEWTOP, null));
                NewTopicBox.Text= "";
                Thread.Sleep(100);
                RefreshClick(null,null);
            }
        }

        private void SendMessage(object sender, EventArgs e)
        {
            string message = MessageBox.Text;
            if (message != "" && currTopic != null)
            {
                Net.sendMsg(comm, new ChatMessage((int) MTypes.CHATMESSAGE,ClientValues.UName,message));
                MessageBox.Clear();
            }
        }

        public void Receiver()
        {
            bool cancel=false;

            do
            {
                Message msg = Net.rcvMsg(comm);

                if (msg is TopicInfo)
                {
                    // View Topics Response
                    ListTopics.Items.Clear();
                    ListTopics.Items.AddRange(((TopicInfo) msg).TList.ToArray());
                }
                else if (msg is ChatMessage)
                {
                    ChatMessage message = (ChatMessage) msg;
                    if (message is DirectMessage)
                    {
                        DMsBox.AppendText(message + Environment.NewLine);
                    }
                    else
                    {
                        if (message.MType == (int) MTypes.CHATLEAVE)
                        {
                            cancel = true;
                        }
                        else if (message.MType == (int) MTypes.CHATWELCOME)
                        {
                            MessagesBox.AppendText(message.Sender + " joined the Topic!" + Environment.NewLine);
                        }
                        else
                        {
                            MessagesBox.AppendText(message + Environment.NewLine);
                        }
                    }
                }
            } while (!cancel);

        }

        private void SendDirectMessage(object sender, EventArgs e)
        {
            string message = DMBox.Text;
            string recipient = RecipientBox.Text;
            if (message != "" && recipient != "")
            {
                Net.sendMsg(comm, new DirectMessage((int) MTypes.CHATMESSAGE,ClientValues.UName,message,recipient));
            }
        }

        private void SelectTopic(object sender, EventArgs e)
        {
            if (currTopic != null)
            {
                Net.sendMsg(comm, new TopicInfo((int) MTypes.LEAVETOP,null));
                MessagesBox.Clear();
            }

            currTopic = (string) ListTopics.Items[ListTopics.SelectedIndex];
            Net.sendMsg(comm, new TopicInfo((int) MTypes.JOINTOP, currTopic));
        }

        private new void Closing(object sender, FormClosedEventArgs e)
        {
            //Logs out the user by disassociating the tcp connection with the account
            if (currTopic != null)
            {
                Net.sendMsg(comm, new TopicInfo((int) MTypes.LEAVETOP, null));
            }
            Net.sendMsg(comm, new UserInfo((int) MTypes.LOGOUT,null,null));
            ClientValues.UName = null;
            currTopic = null;
        }
    }
}