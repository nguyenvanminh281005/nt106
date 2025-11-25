namespace BAI7
{
    partial class DishItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            lblDongGop = new Label();
            lblDiaChi = new Label();
            lblGia = new Label();
            lblTenMon = new Label();
            picHinh = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picHinh).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(lblDongGop);
            panel1.Controls.Add(lblDiaChi);
            panel1.Controls.Add(lblGia);
            panel1.Controls.Add(lblTenMon);
            panel1.Controls.Add(picHinh);
            panel1.Location = new Point(31, 26);
            panel1.Name = "panel1";
            panel1.Size = new Size(430, 190);
            panel1.TabIndex = 5;
            // 
            // lblDongGop
            // 
            lblDongGop.AutoSize = true;
            lblDongGop.Location = new Point(151, 150);
            lblDongGop.Name = "lblDongGop";
            lblDongGop.Size = new Size(80, 20);
            lblDongGop.TabIndex = 9;
            lblDongGop.Text = "Đóng góp:";
            // 
            // lblDiaChi
            // 
            lblDiaChi.AutoSize = true;
            lblDiaChi.Location = new Point(151, 108);
            lblDiaChi.Name = "lblDiaChi";
            lblDiaChi.Size = new Size(58, 20);
            lblDiaChi.TabIndex = 8;
            lblDiaChi.Text = "Địa chỉ:";
            // 
            // lblGia
            // 
            lblGia.AutoSize = true;
            lblGia.Location = new Point(151, 63);
            lblGia.Name = "lblGia";
            lblGia.Size = new Size(34, 20);
            lblGia.TabIndex = 7;
            lblGia.Text = "Giá:";
            // 
            // lblTenMon
            // 
            lblTenMon.AutoSize = true;
            lblTenMon.Location = new Point(151, 20);
            lblTenMon.Name = "lblTenMon";
            lblTenMon.Size = new Size(32, 20);
            lblTenMon.TabIndex = 6;
            lblTenMon.Text = "Tên";
            lblTenMon.Click += label1_Click;
            // 
            // picHinh
            // 
            picHinh.Location = new Point(15, 20);
            picHinh.Name = "picHinh";
            picHinh.Size = new Size(113, 150);
            picHinh.TabIndex = 5;
            picHinh.TabStop = false;
            // 
            // DishItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "DishItem";
            Size = new Size(498, 240);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picHinh).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblDongGop;
        private Label lblDiaChi;
        private Label lblGia;
        private Label lblTenMon;
        private PictureBox picHinh;
    }
}
