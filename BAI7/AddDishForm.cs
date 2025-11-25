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

        ApiService api = new ApiService();
        public AddDishForm()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private async  void button2_Click(object sender, EventArgs e)
        {
            try
            {
                MonAn mon = new MonAn()
                {
                    TenMonAn = textBox1.Text,
                    Gia = decimal.Parse(textBox2.Text),
                    DiaChi = textBox3.Text,
                    HinhAnh = textBox4.Text,
                    MoTa = textBox5.Text
                };

                bool result = await api.AddDish(mon);
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
                MessageBox.Show($"Vui lòng kiểm tra lại dữ liệu nhập! Chi tiết: {ex.Message}");
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
