namespace BAI7
{
    partial class AddDishForm
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
            textBox1 = new TextBox();
            button1 = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            panelImage = new Panel();
            pictureBox1 = new PictureBox();
            btnSelectImage = new Button();
            lblImagePath = new Label();
            textBox5 = new TextBox();
            button2 = new Button();
            panelImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(176, 38);
            label1.Name = "label1";
            label1.Size = new Size(121, 20);
            label1.TabIndex = 0;
            label1.Text = " THÊM MÓN ĂN ";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(145, 106);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(238, 27);
            textBox1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(176, 520);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 5;
            button1.Text = " Clear";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(38, 109);
            label2.Name = "label2";
            label2.Size = new Size(93, 20);
            label2.TabIndex = 3;
            label2.Text = " Tên món ăn:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(38, 164);
            label3.Name = "label3";
            label3.Size = new Size(38, 20);
            label3.TabIndex = 4;
            label3.Text = " Giá:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(38, 230);
            label4.Name = "label4";
            label4.Size = new Size(58, 20);
            label4.TabIndex = 5;
            label4.Text = "Địa chỉ:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(38, 270);
            label5.Name = "label5";
            label5.Size = new Size(75, 20);
            label5.TabIndex = 6;
            label5.Text = " Hình ảnh:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(38, 396);
            label6.Name = "label6";
            label6.Size = new Size(55, 20);
            label6.TabIndex = 7;
            label6.Text = " Mô tả:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(145, 164);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(238, 27);
            textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(145, 227);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(238, 27);
            textBox3.TabIndex = 2;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // panelImage
            // 
            panelImage.AllowDrop = true;
            panelImage.BorderStyle = BorderStyle.FixedSingle;
            panelImage.Controls.Add(pictureBox1);
            panelImage.Controls.Add(btnSelectImage);
            panelImage.Controls.Add(lblImagePath);
            panelImage.Location = new Point(145, 270);
            panelImage.Name = "panelImage";
            panelImage.Size = new Size(238, 120);
            panelImage.TabIndex = 3;
            panelImage.DragDrop += panelImage_DragDrop;
            panelImage.DragEnter += panelImage_DragEnter;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(80, 80);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // btnSelectImage
            // 
            btnSelectImage.Location = new Point(89, 30);
            btnSelectImage.Name = "btnSelectImage";
            btnSelectImage.Size = new Size(140, 29);
            btnSelectImage.TabIndex = 0;
            btnSelectImage.Text = "Chọn hình ảnh";
            btnSelectImage.UseVisualStyleBackColor = true;
            btnSelectImage.Click += btnSelectImage_Click;
            // 
            // lblImagePath
            // 
            lblImagePath.AutoSize = true;
            lblImagePath.Location = new Point(3, 90);
            lblImagePath.Name = "lblImagePath";
            lblImagePath.Size = new Size(180, 20);
            lblImagePath.TabIndex = 1;
            lblImagePath.Text = "Kéo thả hoặc chọn file";
            lblImagePath.ForeColor = Color.Gray;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(145, 396);
            textBox5.Multiline = true;
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(238, 103);
            textBox5.TabIndex = 4;
            textBox5.TextChanged += textBox5_TextChanged;
            // 
            // button2
            // 
            button2.Location = new Point(289, 520);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 6;
            button2.Text = "Thêm";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // AddDishForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(430, 570);
            Controls.Add(button2);
            Controls.Add(textBox5);
            Controls.Add(panelImage);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "AddDishForm";
            Text = "AddDishForm";
            panelImage.ResumeLayout(false);
            panelImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Button button1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox textBox2;
        private TextBox textBox3;
        private Panel panelImage;
        private PictureBox pictureBox1;
        private Button btnSelectImage;
        private Label lblImagePath;
        private TextBox textBox5;
        private Button button2;
    }
}