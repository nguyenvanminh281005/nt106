using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BAI7
{
    public partial class DishItem : UserControl
    {
        public DishItem()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void SetData(MonAn mon)
        {
            // Gán dữ liệu vào các Label
            // LƯU Ý: Các tên lblTenMon, lblGia... phải trùng với bên Design (xem bước 2 dưới đây)
            lblTenMon.Text = mon.TenMonAn;
            lblGia.Text = string.Format("{0:N0} VNĐ", mon.Gia);
            lblDiaChi.Text = mon.DiaChi;
            lblDongGop.Text = mon.NguoiDongGop;

            // Load hình ảnh (nếu có link)
            if (!string.IsNullOrEmpty(mon.HinhAnh))
            {
                try
                {
                    picHinh.LoadAsync(mon.HinhAnh);
                }
                catch { } // Bỏ qua nếu link ảnh lỗi
            }
        }
    }
}
