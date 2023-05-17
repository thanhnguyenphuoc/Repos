using System;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO; //for Streams
using System.Threading; //to run commands concurrently
using System.Net; //for IPEndPoint
using Renci.SshNet;

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
            textBoxThucThi.Focus();
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
        private void RunCommand()
        {
            var host = texBoxHostname.Text;
            var username = textBoxUsername.Text;
            var password = textBoxPassword.Text;

            using (var client = new SshClient(host, username, password))
            {
                client.Connect();
                // If the command2 depend on an environment modified by command1,
                // execute them like this.
                // If not, use separate CreateCommand calls.
                var cmd = client.CreateCommand("command1; command2");

                var result = cmd.BeginExecute();

                using (var reader = new StreamReader(
                                      cmd.OutputStream, Encoding.UTF8, true, 1024, true))
                {
                    while (!result.IsCompleted || !reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        if (line != null)
                        {
                            textBoxHienThi.Invoke(
                                (MethodInvoker)(() =>
                                    textBoxHienThi.AppendText(line + Environment.NewLine)));
                        }
                    }
                }

                cmd.EndExecute(result);
            }
        }

        private void textBoxThucThi_KeyDown(object sender, KeyEventArgs e)
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
    }
}