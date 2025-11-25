using System;
using System.Windows.Forms;
using BAI7;

namespace BAI7
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            string pass = textBox2.Text;

            button1.Enabled = false; // Khóa nút khi đang xử lý

            // Sử dụng singleton instance
            bool success = await ApiService.Instance.Login(user, pass);

            button1.Enabled = true; // Mở lại nút

            if (success)
            {
                // MessageBox.Show("Đăng nhập thành công!");

                // 👇 2. SỬA LỖI: Truyền biến 'user' vào trong ngoặc
                // Vì MainForm yêu cầu phải có tên người dùng mới chịu mở
                MainForm main = new MainForm(user);

                this.Hide();
                main.ShowDialog();
                this.Show(); // Hiện lại Login khi Main đóng (Logout)
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
            }
        }

        // Các hàm thừa có thể để trống
        private void label4_Click(object sender, EventArgs e)
        {
            SignUpForm frm = new SignUpForm();
            frm.ShowDialog();
        }
        private void LoginForm_Load(object sender, EventArgs e) { }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUpForm signUpForm = new SignUpForm();
            signUpForm.ShowDialog();
        }
    }
}