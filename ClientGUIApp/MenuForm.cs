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
        private NetworkStream comm = ClientValues.Comm.GetStream();
        public MenuForm()
        {
            InitializeComponent();
            
            Thread th = new Thread(Receiver);
            th.Start();
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
            throw new System.NotImplementedException();
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
            } while (!cancel);

        }

        private void SendDirectMessage(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}