namespace CommandServer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();
            tabPage4 = new TabPage();
            textBoxThucThi = new TextBox();
            btConnection = new Button();
            textBoxPassword = new TextBox();
            label4 = new Label();
            textBoxUsername = new TextBox();
            label3 = new Label();
            label2 = new Label();
            texBoxHostname = new TextBox();
            label1 = new Label();
            textBoxHienThi = new TextBox();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            statusStrip1.SuspendLayout();
            tabPage4.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(803, 449);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(button4);
            tabPage1.Controls.Add(button3);
            tabPage1.Controls.Add(button2);
            tabPage1.Controls.Add(button1);
            tabPage1.Controls.Add(statusStrip1);
            tabPage1.Controls.Add(textBox2);
            tabPage1.Controls.Add(textBox1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(795, 421);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Basic";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(53, 251);
            button4.Name = "button4";
            button4.Size = new Size(106, 23);
            button4.TabIndex = 5;
            button4.Text = "Shutdown Client";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.Location = new Point(53, 177);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 4;
            button3.Text = "Play Sound";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(53, 100);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 3;
            button2.Text = "Beep";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(53, 32);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "Message";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(3, 396);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(789, 22);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(118, 17);
            toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(256, 330);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(536, 23);
            textBox2.TabIndex = 1;
            textBox2.KeyDown += textBox2_KeyDown;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.Black;
            textBox1.ForeColor = Color.Green;
            textBox1.Location = new Point(256, 6);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(536, 318);
            textBox1.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(795, 421);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Remote Desktop";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(795, 421);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Key Logger";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(textBoxThucThi);
            tabPage4.Controls.Add(btConnection);
            tabPage4.Controls.Add(textBoxPassword);
            tabPage4.Controls.Add(label4);
            tabPage4.Controls.Add(textBoxUsername);
            tabPage4.Controls.Add(label3);
            tabPage4.Controls.Add(label2);
            tabPage4.Controls.Add(texBoxHostname);
            tabPage4.Controls.Add(label1);
            tabPage4.Controls.Add(textBoxHienThi);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(795, 421);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "SSH conection";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // textBoxThucThi
            // 
            textBoxThucThi.Location = new Point(290, 317);
            textBoxThucThi.Name = "textBoxThucThi";
            textBoxThucThi.Size = new Size(494, 23);
            textBoxThucThi.TabIndex = 9;
            textBoxThucThi.KeyDown += textBoxThucThi_KeyDown;
            // 
            // btConnection
            // 
            btConnection.Location = new Point(47, 349);
            btConnection.Name = "btConnection";
            btConnection.Size = new Size(180, 52);
            btConnection.TabIndex = 8;
            btConnection.Text = "Connection";
            btConnection.UseVisualStyleBackColor = true;
            btConnection.Click += btConnection_Click;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(84, 164);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '*';
            textBoxPassword.Size = new Size(143, 23);
            textBoxPassword.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 167);
            label4.Name = "label4";
            label4.Size = new Size(63, 15);
            label4.TabIndex = 6;
            label4.Text = "Password :";
            // 
            // textBoxUsername
            // 
            textBoxUsername.Location = new Point(84, 121);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(143, 23);
            textBoxUsername.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(5, 92);
            label3.Name = "label3";
            label3.Size = new Size(68, 15);
            label3.TabIndex = 4;
            label3.Text = "Hostname :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(5, 129);
            label2.Name = "label2";
            label2.Size = new Size(66, 15);
            label2.TabIndex = 3;
            label2.Text = "Username :";
            // 
            // texBoxHostname
            // 
            texBoxHostname.Location = new Point(84, 89);
            texBoxHostname.Name = "texBoxHostname";
            texBoxHostname.Size = new Size(143, 23);
            texBoxHostname.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(49, 16);
            label1.Name = "label1";
            label1.Size = new Size(207, 37);
            label1.TabIndex = 1;
            label1.Text = "SSH Connection";
            // 
            // textBoxHienThi
            // 
            textBoxHienThi.BackColor = Color.Black;
            textBoxHienThi.ForeColor = Color.Green;
            textBoxHienThi.Location = new Point(290, 6);
            textBoxHienThi.Multiline = true;
            textBoxHienThi.Name = "textBoxHienThi";
            textBoxHienThi.Size = new Size(494, 287);
            textBoxHienThi.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Conmand Server";
            FormClosing += Form1_FormClosing;
            Shown += Form1_Shown;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private TextBox textBox2;
        private TextBox textBox1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TextBox textBoxThucThi;
        private Button btConnection;
        private TextBox textBoxPassword;
        private Label label4;
        private TextBox textBoxUsername;
        private Label label3;
        private Label label2;
        private TextBox texBoxHostname;
        private Label label1;
        private TextBox textBoxHienThi;
    }
}