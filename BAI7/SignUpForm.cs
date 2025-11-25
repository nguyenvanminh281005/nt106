using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace BAI7
{
    public partial class SignUpForm : Form
    {
        ApiService api = new ApiService();
        public SignUpForm()
        {
            InitializeComponent();
            comboBox1.Items.Add("vi");
            comboBox1.Items.Add("en");
            comboBox1.SelectedIndex = 0;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            // Validation dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin bắt buộc!");
                return;
            }

            // Kiểm tra email format đơn giản
            if (!textBox3.Text.Contains("@"))
            {
                MessageBox.Show("Email không hợp lệ!");
                return;
            }

            // Xử lý giới tính - 0 = Female, 1 = Male
            int selectedSex = -1;
            if (radioButton1.Checked)
            {
                selectedSex = 0; // Female
            }
            else if (radioButton2.Checked)
            {
                selectedSex = 1; // Male
            }
            else
            {
                MessageBox.Show("Vui lòng chọn giới tính!");
                return;
            }

            UserRegister newUser = new UserRegister()
            {
                username = textBox1.Text.Trim(),
                password = textBox2.Text,
                email = textBox3.Text.Trim(),
                first_name = textBox4.Text.Trim(),
                last_name = textBox5.Text.Trim(),
                phone = textBox6.Text.Trim(),
                sex = selectedSex,
                birthday = dateTimePicker1.Value.ToString("yyyy-MM-dd"),
                language = comboBox1.SelectedItem?.ToString() ?? "vi"
            };

            btnRegister.Enabled = false;

            try
            {
                bool result = await api.Register(newUser);
                btnRegister.Enabled = true;

                MessageBox.Show("Đăng ký thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                btnRegister.Enabled = true;
                MessageBox.Show($"Đăng ký thất bại!\n\nChi tiết lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
   
}
