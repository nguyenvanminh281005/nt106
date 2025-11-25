using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BAI7
{
    public partial class AddDishForm : Form
    {
        private string selectedImagePath = "";
        private string currentUsername = "";

        public AddDishForm(string username = "")
        {
            InitializeComponent();
            currentUsername = username;
        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                openFileDialog.Title = "Chọn hình ảnh món ăn";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedImagePath = openFileDialog.FileName;
                    pictureBox1.Image = Image.FromFile(selectedImagePath);
                    lblImagePath.Text = Path.GetFileName(selectedImagePath);
                    lblImagePath.ForeColor = Color.Green;
                }
            }
        }

        private void panelImage_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                string extension = Path.GetExtension(files[0]).ToLower();
                
                if (extension == ".jpg" || extension == ".jpeg" || extension == ".png" || 
                    extension == ".gif" || extension == ".bmp")
                {
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
        }

        private void panelImage_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0)
            {
                string extension = Path.GetExtension(files[0]).ToLower();
                
                if (extension == ".jpg" || extension == ".jpeg" || extension == ".png" || 
                    extension == ".gif" || extension == ".bmp")
                {
                    selectedImagePath = files[0];
                    pictureBox1.Image = Image.FromFile(selectedImagePath);
                    lblImagePath.Text = Path.GetFileName(selectedImagePath);
                    lblImagePath.ForeColor = Color.Green;
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn file hình ảnh hợp lệ (.jpg, .jpeg, .png, .gif, .bmp)");
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Clear tất cả các field
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            selectedImagePath = "";
            pictureBox1.Image = null;
            lblImagePath.Text = "Kéo thả hoặc chọn file";
            lblImagePath.ForeColor = Color.Gray;
        }

        private async  void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên món ăn!");
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    MessageBox.Show("Vui lòng nhập giá!");
                    return;
                }

                MonAn mon = new MonAn()
                {
                    TenMonAn = textBox1.Text,
                    Gia = decimal.Parse(textBox2.Text),
                    DiaChi = textBox3.Text,
                    HinhAnh = "", // Sẽ được set bởi code API
                    MoTa = textBox5.Text,
                    NguoiDongGop = currentUsername
                };

                bool result = await ApiService.Instance.AddDish(mon, selectedImagePath);
                if (result)
                {
                    MessageBox.Show("Thêm thành công!");
                    this.DialogResult = DialogResult.OK; // Báo cho Main biết là OK
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Lỗi khi thêm món!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
