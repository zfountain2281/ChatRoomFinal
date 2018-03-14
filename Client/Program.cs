using System;
using System.Collections.Generic;

using System.Linq;

using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Client
{
    class Program : System.Windows.Forms.Form
    {
        private Label usersInChatRoomLabel;
        private ListBox listChatRoomMessages;
        private ListBox listUsersInChatRoom;
        private TextBox ipAddressOfServer;
        private GroupBox groupBoxServerInfo;
        private Button startConnectionButton;
        private TextBox textMessageToSend;
        private Button buttonSend;
        private GroupBox groupBoxUserName;
        private Label labelUserName;
        private TextBox textBoxUserName;
        private Label labelServerPort;
        private Label labelServerIP;
        private TextBox textServerPort;

        Program()
        {
            InitializeComponent();
        }
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.Run(new Program());
            Client client = new Client(9999);
            client.Run();
            Console.ReadLine();
        }

        private void InitializeComponent()
        {
            this.usersInChatRoomLabel = new System.Windows.Forms.Label();
            this.listChatRoomMessages = new System.Windows.Forms.ListBox();
            this.listUsersInChatRoom = new System.Windows.Forms.ListBox();
            this.ipAddressOfServer = new System.Windows.Forms.TextBox();
            this.textServerPort = new System.Windows.Forms.TextBox();
            this.groupBoxServerInfo = new System.Windows.Forms.GroupBox();
            this.startConnectionButton = new System.Windows.Forms.Button();
            this.textMessageToSend = new System.Windows.Forms.TextBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.groupBoxUserName = new System.Windows.Forms.GroupBox();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.labelUserName = new System.Windows.Forms.Label();
            this.labelServerIP = new System.Windows.Forms.Label();
            this.labelServerPort = new System.Windows.Forms.Label();
            this.groupBoxServerInfo.SuspendLayout();
            this.groupBoxUserName.SuspendLayout();
            this.SuspendLayout();
            // 
            // usersInChatRoomLabel
            // 
            this.usersInChatRoomLabel.AutoSize = true;
            this.usersInChatRoomLabel.Location = new System.Drawing.Point(1209, 256);
            this.usersInChatRoomLabel.Name = "usersInChatRoomLabel";
            this.usersInChatRoomLabel.Size = new System.Drawing.Size(190, 25);
            this.usersInChatRoomLabel.TabIndex = 1;
            this.usersInChatRoomLabel.Text = "Users In Chatroom";
            // 
            // listChatRoomMessages
            // 
            this.listChatRoomMessages.FormattingEnabled = true;
            this.listChatRoomMessages.ItemHeight = 25;
            this.listChatRoomMessages.Location = new System.Drawing.Point(89, 323);
            this.listChatRoomMessages.Name = "listChatRoomMessages";
            this.listChatRoomMessages.Size = new System.Drawing.Size(942, 454);
            this.listChatRoomMessages.TabIndex = 2;
            // 
            // listUsersInChatRoom
            // 
            this.listUsersInChatRoom.FormattingEnabled = true;
            this.listUsersInChatRoom.ItemHeight = 25;
            this.listUsersInChatRoom.Location = new System.Drawing.Point(1191, 302);
            this.listUsersInChatRoom.Name = "listUsersInChatRoom";
            this.listUsersInChatRoom.Size = new System.Drawing.Size(208, 479);
            this.listUsersInChatRoom.TabIndex = 3;
            // 
            // ipAddressOfServer
            // 
            this.ipAddressOfServer.Location = new System.Drawing.Point(217, 72);
            this.ipAddressOfServer.Name = "ipAddressOfServer";
            this.ipAddressOfServer.Size = new System.Drawing.Size(247, 31);
            this.ipAddressOfServer.TabIndex = 4;
            // 
            // textServerPort
            // 
            this.textServerPort.Location = new System.Drawing.Point(310, 120);
            this.textServerPort.Name = "textServerPort";
            this.textServerPort.Size = new System.Drawing.Size(154, 31);
            this.textServerPort.TabIndex = 5;
            // 
            // groupBoxServerInfo
            // 
            this.groupBoxServerInfo.Controls.Add(this.labelServerPort);
            this.groupBoxServerInfo.Controls.Add(this.labelServerIP);
            this.groupBoxServerInfo.Controls.Add(this.ipAddressOfServer);
            this.groupBoxServerInfo.Controls.Add(this.textServerPort);
            this.groupBoxServerInfo.Location = new System.Drawing.Point(89, 12);
            this.groupBoxServerInfo.Name = "groupBoxServerInfo";
            this.groupBoxServerInfo.Size = new System.Drawing.Size(464, 168);
            this.groupBoxServerInfo.TabIndex = 6;
            this.groupBoxServerInfo.TabStop = false;
            this.groupBoxServerInfo.Text = "Connect To Server";
            // 
            // startConnectionButton
            // 
            this.startConnectionButton.Location = new System.Drawing.Point(1161, 74);
            this.startConnectionButton.Name = "startConnectionButton";
            this.startConnectionButton.Size = new System.Drawing.Size(212, 70);
            this.startConnectionButton.TabIndex = 7;
            this.startConnectionButton.Text = "Enter Chat Room";
            this.startConnectionButton.UseVisualStyleBackColor = true;
            this.startConnectionButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // textMessageToSend
            // 
            this.textMessageToSend.Location = new System.Drawing.Point(87, 846);
            this.textMessageToSend.Name = "textMessageToSend";
            this.textMessageToSend.Size = new System.Drawing.Size(970, 31);
            this.textMessageToSend.TabIndex = 8;
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(1095, 822);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(268, 78);
            this.buttonSend.TabIndex = 9;
            this.buttonSend.Text = "Send Message";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // groupBoxUserName
            // 
            this.groupBoxUserName.Controls.Add(this.labelUserName);
            this.groupBoxUserName.Controls.Add(this.textBoxUserName);
            this.groupBoxUserName.Location = new System.Drawing.Point(663, 26);
            this.groupBoxUserName.Name = "groupBoxUserName";
            this.groupBoxUserName.Size = new System.Drawing.Size(464, 154);
            this.groupBoxUserName.TabIndex = 10;
            this.groupBoxUserName.TabStop = false;
            this.groupBoxUserName.Text = "Your Info";
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(211, 74);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(247, 31);
            this.textBoxUserName.TabIndex = 0;
            this.textBoxUserName.TextChanged += new System.EventHandler(this.textBoxUserName_TextChanged);
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Location = new System.Drawing.Point(-5, 74);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(190, 25);
            this.labelUserName.TabIndex = 1;
            this.labelUserName.Text = "Desired Username";
            // 
            // labelServerIP
            // 
            this.labelServerIP.AutoSize = true;
            this.labelServerIP.Location = new System.Drawing.Point(22, 62);
            this.labelServerIP.Name = "labelServerIP";
            this.labelServerIP.Size = new System.Drawing.Size(185, 25);
            this.labelServerIP.TabIndex = 6;
            this.labelServerIP.Text = "Server IP Address";
            // 
            // labelServerPort
            // 
            this.labelServerPort.AutoSize = true;
            this.labelServerPort.Location = new System.Drawing.Point(30, 126);
            this.labelServerPort.Name = "labelServerPort";
            this.labelServerPort.Size = new System.Drawing.Size(201, 25);
            this.labelServerPort.TabIndex = 7;
            this.labelServerPort.Text = "Server Port Number";
            // 
            // Program
            // 
            this.ClientSize = new System.Drawing.Size(1438, 933);
            this.Controls.Add(this.groupBoxUserName);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.textMessageToSend);
            this.Controls.Add(this.startConnectionButton);
            this.Controls.Add(this.groupBoxServerInfo);
            this.Controls.Add(this.listUsersInChatRoom);
            this.Controls.Add(this.listChatRoomMessages);
            this.Controls.Add(this.usersInChatRoomLabel);
            this.Name = "Program";
            this.Load += new System.EventHandler(this.Program_Load);
            this.groupBoxServerInfo.ResumeLayout(false);
            this.groupBoxServerInfo.PerformLayout();
            this.groupBoxUserName.ResumeLayout(false);
            this.groupBoxUserName.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Program_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBoxUserName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
