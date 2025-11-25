using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BAI7;

namespace BAI7
{
    public partial class MainForm : Form
    {
        // 1. KHAI BÁO BIẾN
        ApiService api = new ApiService();
        int currentPage = 1;
        int pageSize = 10; // Số lượng món mỗi trang

        // Lưu tên người dùng hiện tại để lọc "Món của tôi"
        string currentUsername = "";

        // Lưu danh sách tạm để dùng cho chức năng Random
        List<MonAn> currentListCache = new List<MonAn>();

        // 2. SỬA HÀM KHỞI TẠO (Constructor)
        // Bắt buộc phải nhận tham số 'username' từ LoginForm truyền sang
        public MainForm(string username)
        {
            InitializeComponent();

            // Lưu username vào biến toàn cục để dùng ở chỗ khác
            this.currentUsername = username;

            // Hiển thị lời chào
            lblWelcome.Text = "Welcome, " + username;
        }

        // 3. SỰ KIỆN KHI FORM LOAD
        private async void MainForm_Load(object sender, EventArgs e)
        {
            await LoadDataAll(); // Mặc định tải tab "Tất cả"
        }

        // 4. HÀM TẢI DỮ LIỆU TAB "TẤT CẢ" (CỘNG ĐỒNG)
        private async Task LoadDataAll()
        {
            flowPanelAll.Controls.Clear();

            // Gọi API lấy dữ liệu
            var result = await api.GetDishes(currentPage, pageSize);

            if (result != null && result.Data != null)
            {
                currentListCache = result.Data; // Lưu cache để random

                foreach (var item in result.Data)
                {
                    DishItem dishControl = new DishItem();
                    dishControl.SetData(item);
                    flowPanelAll.Controls.Add(dishControl);
                }
            }
        }

        // 5. HÀM TẢI DỮ LIỆU TAB "CỦA TÔI"
        private async Task LoadDataMe()
        {
            flowPanelMe.Controls.Clear();

            // Mẹo: Lấy số lượng lớn (100) để về lọc phía Client
            // Vì API Lab thường chưa có chức năng lọc theo User
            var result = await api.GetDishes(1, 100);

            if (result != null && result.Data != null)
            {
                // Lọc những món có NguoiDongGop trùng với user hiện tại
                var myDishes = result.Data.Where(d => d.NguoiDongGop == currentUsername).ToList();

                // Cập nhật cache (để nếu bấm Random ở tab này thì chỉ random món của mình)
                currentListCache = myDishes;

                if (myDishes.Count == 0)
                {
                    Label lbl = new Label() { Text = "Bạn chưa đóng góp món nào!", AutoSize = true, Font = new Font("Arial", 12) };
                    flowPanelMe.Controls.Add(lbl);
                }

                foreach (var item in myDishes)
                {
                    DishItem dishControl = new DishItem();
                    dishControl.SetData(item);
                    flowPanelMe.Controls.Add(dishControl);
                }
            }
        }

        // 6. XỬ LÝ CHUYỂN TAB
        private async void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1) 
            {
                await LoadDataAll();
            }
            else if (tabControl1.SelectedTab == tabPage2) 
            {
                await LoadDataMe();
            }
        }

        // 7. NÚT "THÊM MÓN ĂN" 
        private async void button2_Click(object sender, EventArgs e)
        {
            AddDishForm frm = new AddDishForm();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (tabControl1.SelectedTab == tabPage1) await LoadDataAll();
                else await LoadDataMe();
            }
        }

        // 8. NÚT "ĂN GÌ GIỜ?" (RANDOM) 
        private void button1_Click(object sender, EventArgs e)
        {
            if (currentListCache != null && currentListCache.Count > 0)
            {
                Random rnd = new Random();
                int index = rnd.Next(currentListCache.Count);
                MonAn selectedDish = currentListCache[index];

                RandomDishForm frm = new RandomDishForm(selectedDish);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Không có món ăn nào để chọn!");
            }
        }

        // 9. NÚT LOGOUT
        private void lnkLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close(); 
        }

        private void tabPage2_Click(object sender, EventArgs e) { }
        private void tabPage1_Click(object sender, EventArgs e) { }
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void MainForm_Load_1(object sender, EventArgs e) { }
    }
}