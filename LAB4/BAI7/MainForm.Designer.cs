namespace BAI7
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            flowPanelAll = new FlowLayoutPanel();
            tabPage2 = new TabPage();
            flowPanelMe = new FlowLayoutPanel();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            panel1 = new Panel();
            progressBar1 = new ProgressBar();
            lnkLogout = new LinkLabel();
            lblWelcome = new Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(16, 9);
            label1.Name = "label1";
            label1.Size = new Size(311, 46);
            label1.TabIndex = 0;
            label1.Text = " HÔM NAY ĂN GÌ?";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(327, 60);
            button1.Name = "button1";
            button1.Size = new Size(126, 47);
            button1.TabIndex = 1;
            button1.Text = " Ăn gì giờ?";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(459, 60);
            button2.Name = "button2";
            button2.Size = new Size(114, 47);
            button2.TabIndex = 2;
            button2.Text = " Thêm món ăn";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(12, 107);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(565, 370);
            tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(flowPanelAll);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(557, 337);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "All";
            tabPage1.UseVisualStyleBackColor = true;
            tabPage1.Click += tabPage1_Click;
            // 
            // flowPanelAll
            // 
            flowPanelAll.Location = new Point(3, 3);
            flowPanelAll.Name = "flowPanelAll";
            flowPanelAll.Size = new Size(554, 349);
            flowPanelAll.TabIndex = 0;
            flowPanelAll.Paint += flowLayoutPanel1_Paint;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(flowPanelMe);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(557, 337);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Tôi đóng góp";
            tabPage2.UseVisualStyleBackColor = true;
            tabPage2.Click += tabPage2_Click;
            // 
            // flowPanelMe
            // 
            flowPanelMe.Location = new Point(1, 3);
            flowPanelMe.Name = "flowPanelMe";
            flowPanelMe.Size = new Size(554, 333);
            flowPanelMe.TabIndex = 1;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(537, -3);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(34, 28);
            comboBox1.TabIndex = 0;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(430, -3);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(34, 28);
            comboBox2.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(377, 1);
            label2.Name = "label2";
            label2.Size = new Size(47, 20);
            label2.TabIndex = 5;
            label2.Text = " page";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(460, 3);
            label3.Name = "label3";
            label3.Size = new Size(74, 20);
            label3.TabIndex = 6;
            label3.Text = " Page size";
            // 
            // panel1
            // 
            panel1.AccessibleDescription = "";
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(progressBar1);
            panel1.Controls.Add(lnkLogout);
            panel1.Controls.Add(lblWelcome);
            panel1.Controls.Add(comboBox2);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(comboBox1);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 499);
            panel1.Name = "panel1";
            panel1.Size = new Size(597, 25);
            panel1.TabIndex = 7;
            panel1.Paint += panel1_Paint;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(186, 0);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(125, 23);
            progressBar1.TabIndex = 9;
            progressBar1.Value = 100;
            // 
            // lnkLogout
            // 
            lnkLogout.AutoSize = true;
            lnkLogout.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lnkLogout.Location = new Point(116, 1);
            lnkLogout.Name = "lnkLogout";
            lnkLogout.Size = new Size(56, 20);
            lnkLogout.TabIndex = 8;
            lnkLogout.TabStop = true;
            lnkLogout.Text = "Logout";
            lnkLogout.LinkClicked += lnkLogout_LinkClicked;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new Point(3, 1);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(107, 20);
            lblWelcome.TabIndex = 7;
            lblWelcome.Text = "Welcome, User";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(597, 524);
            Controls.Add(panel1);
            Controls.Add(tabControl1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load_1;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Button button2;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private FlowLayoutPanel flowPanelAll;
        private FlowLayoutPanel flowPanelMe;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Label label2;
        private Label label3;
        private Panel panel1;
        private Label lblWelcome;
        private ProgressBar progressBar1;
        private LinkLabel lnkLogout;
    }
}