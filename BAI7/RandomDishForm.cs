using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Windows.Forms;
using Newtonsoft.Json; 

namespace BAI7

{
    public partial class RandomDishForm : Form
    {
        public RandomDishForm(MonAn monan)
        {
            InitializeComponent();
            if (label1 != null) label1.Text = monan.TenMonAn;
            if (label2 != null) label2.Text = $"{monan.Gia:N0}";
            if (label3 != null) label3.Text = monan.DiaChi;
            if (!string.IsNullOrEmpty(monan.HinhAnh) && pictureBox1 != null)
            {
                try
                {
                    pictureBox1.LoadAsync(monan.HinhAnh);
                }
                catch { }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void RandomDishForm_Load(object sender, EventArgs e)
        {

        }

      
    }
}
