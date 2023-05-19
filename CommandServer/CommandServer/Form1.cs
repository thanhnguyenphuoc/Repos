using System;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO; //for Streams
using System.Threading; //to run commands concurrently
using System.Net; //for IPEndPoint
using Renci.SshNet;
using Renci.SshNet.Messages.Transport;
using System.Drawing.Imaging;

namespace CommandServer
{
    public partial class Form1 : Form
    {

        TcpListener tcpListener;
        Socket socketForClient;
        NetworkStream networkStream;
        StreamWriter streamWriter;
        StreamReader streamReader;
        StringBuilder strInput;
        Thread th_StartListen, th_RunServer;
        Bitmap memoryImage;
        private bool isConnected = false;
        //Commands in enumeration format:
        private enum command
        {
            HELP = 1,
            MESSAGE = 2,
            BEEP = 3,
            PLAYSOUND = 4,
            SHUTDOWNCLIENT = 5
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            th_StartListen = new Thread(new ThreadStart(StartListen));
            th_StartListen.Start();
            textBox2.Focus();
            txtThucThi.Focus();
        }

        private void StartListen()
        {
            tcpListener = new TcpListener(System.Net.IPAddress.Any, 6666);
            tcpListener.Start();
            toolStripStatusLabel1.Text = "Listening on port 6666 ...";
            for (; ; )
            {
                socketForClient = tcpListener.AcceptSocket();
                IPEndPoint ipend = (IPEndPoint)socketForClient.RemoteEndPoint;
                toolStripStatusLabel1.Text = "Connection from " + IPAddress.Parse(ipend.Address.ToString());
                th_RunServer = new Thread(new ThreadStart(RunServer));
                th_RunServer.Start();
            }
        }

        private void RunServer()
        {
            networkStream = new NetworkStream(socketForClient);
            streamReader = new StreamReader(networkStream);
            streamWriter = new StreamWriter(networkStream);
            strInput = new StringBuilder();

            while (true)
            {
                try
                {
                    strInput.Append(streamReader.ReadLine());
                    strInput.Append("\r\n");
                }
                catch (Exception)
                {
                    Cleanup();
                    break;
                }
                Application.DoEvents();
                DisplayMessage(strInput.ToString());
                strInput.Remove(0, strInput.Length);
            }
        }

        private void Cleanup()
        {
            try
            {
                streamReader.Close();
                streamWriter.Close();
                networkStream.Close();
                socketForClient.Close();
            }
            catch (Exception err) { }
            toolStripStatusLabel1.Text = "Connection Lost";
        }

        private delegate void DisplayDelegate(string message);

        private void DisplayMessage(string message)
        {
            if (textBox1.InvokeRequired)
            {
                Invoke(new DisplayDelegate(DisplayMessage), new object[] { message });
            }
            else
            {
                textBox1.AppendText(message);
            }
        }



        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    strInput.Append(textBox2.Text.ToString());
                    streamWriter.WriteLine(strInput);
                    streamWriter.Flush();
                    strInput.Remove(0, strInput.Length);
                    if (textBox2.Text == "exit") Cleanup();
                    if (textBox2.Text == "terminate") Cleanup();
                    if (textBox2.Text == "cls") textBox1.Text = "";
                    textBox2.Text = "";
                }
            }
            catch (Exception err) { }
        }

        //messagebox
        private void button1_Click(object sender, EventArgs e)
        {
            streamWriter.WriteLine("" + (int)command.MESSAGE);
            streamWriter.Flush();
        }

        //beep
        private void button2_Click(object sender, EventArgs e)
        {
            streamWriter.WriteLine("" + (int)command.BEEP);
            streamWriter.Flush();
        }

        //playsound
        private void button3_Click(object sender, EventArgs e)
        {
            streamWriter.WriteLine("" + (int)command.PLAYSOUND);
            streamWriter.Flush();
        }


        //shutdown client
        private void button4_Click(object sender, EventArgs e)
        {
            streamWriter.WriteLine("" + (int)command.SHUTDOWNCLIENT);
            streamWriter.Flush();
            toolStripStatusLabel1.Text = "Client has been shut down";
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cleanup();
            System.Environment.Exit(0);
        }

        private void btConnection_Click(object sender, EventArgs e)
        {


        }
        private void connectAndExecuteCommand()
        {
            string host = txtHostName.Text;
            string username = txtUserName.Text;
            string password = txtPassWord.Text;
            try
            {
                // Kiểm tra xem TextBox có rỗng không
                if (string.IsNullOrWhiteSpace(txtThucThi.Text))
                {
                    // Nếu TextBox rỗng, không thực hiện kết nối SSH
                    return;
                }
                // Tạo đối tượng kết nối SSH
                using (var client = new SshClient(host, username, password))
                {
                    client.Connect();


                    if (client.IsConnected)
                    {
                        if (client.IsConnected && !isConnected)
                        {
                            isConnected = true;

                            // Hiển thị thông báo kết nối thành công chỉ trong lần nhập đầu tiên
                            MessageBox.Show("Connected successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }

                        string commandText = txtThucThi.Text;
                        // Thực thi lệnh SSH
                        var command = client.CreateCommand(commandText);
                        var result = command.Execute();

                        result = result.Replace("\n", Environment.NewLine);

                        txtHienThi.Text = result;

                        txtThucThi.Clear();
                        client.Disconnect();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        private void textBoxThucThi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                connectAndExecuteCommand();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void buttonCaptureDesktop_Click(object sender, EventArgs e)
        {
            CaptureDesktop();
            Save();
            pictureBox1.ImageLocation = "desktop.jpg";
        }
        public void CaptureDesktop()
        {
            try
            {
                Rectangle rc = Screen.PrimaryScreen.Bounds;
                memoryImage = new Bitmap(rc.Width, rc.Height, PixelFormat.Format32bppArgb);
                using (Graphics memoryGraphics = Graphics.FromImage(memoryImage))
                {
                    memoryGraphics.CopyFromScreen(rc.X, rc.Y, 0, 0, rc.Size, CopyPixelOperation.SourceCopy);
                }
            }
            catch (Exception) { }
        }

        public void Save()
        {
            //String directory = Path.GetDirectoryName(filename);
            //String name = Path.GetFileNameWithoutExtension(filename);
            //if (!Directory.Exists(pathName))
            //Directory.CreateDirectory(pathName);

            String pathName = String.Format("{0}\\", Path.GetDirectoryName(Application.ExecutablePath));
            string filename = String.Format("{0}Desktop.JPG", pathName);
            try
            {
                memoryImage.Save(filename, ImageFormat.Jpeg);
            }
            catch (Exception) { }
        }
    }
}