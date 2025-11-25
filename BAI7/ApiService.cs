using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BAI7
{
    public class ApiService
    {
        private static readonly HttpClient client = new HttpClient();
        private string BASE_URL = "https://nt106.uitiot.vn/api"; // URL API của thầy

        // Biến lưu token dùng chung
        public static string AccessToken = "";

        // 1. HÀM LOGIN
        public async Task<bool> Login(string username, string password)
        {
            // Kiểm tra đăng nhập với tài khoản đã lưu
            if (UserStorage.ValidateUser(username, password))
                return true;

            try
            {
                var loginData = new { username = username, password = password };
                var content = new StringContent(JsonConvert.SerializeObject(loginData), Encoding.UTF8, "application/json");

                var response = await client.PostAsync($"{BASE_URL}/auth/login", content);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    dynamic? result = JsonConvert.DeserializeObject(jsonString);
                    AccessToken = result?.access_token ?? string.Empty;

                    // Gắn Token vào Header để dùng cho các lệnh sau
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
                    return true;
                }
            }
            catch { }
            return false;
        }

        // 2. HÀM LẤY DANH SÁCH MÓN (GetDishes ĐÂY RỒI!)
        // gọi API lấy dữ liệu về
        public async Task<PageResult<MonAn>> GetDishes(int page, int pageSize)
        {
            try
            {
                // Gọi API lấy dữ liệu theo trang
                var response = await client.GetAsync($"{BASE_URL}/monan?page={page}&pageSize={pageSize}");

                if (response.IsSuccessStatusCode)
                {
                    // Đọc kết quả trả về
                    var jsonString = await response.Content.ReadAsStringAsync();
                    // Chuyển đổi từ chuỗi JSON sang danh sách món ăn
                    return JsonConvert.DeserializeObject<PageResult<MonAn>>(jsonString) ?? new PageResult<MonAn>();
                }
            }
            catch { }
            return new PageResult<MonAn>(); // Trả về object rỗng nếu lỗi
        }

        // 3. HÀM THÊM MÓN
        public async Task<bool> AddDish(MonAn monAn)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(monAn), Encoding.UTF8, "application/json");
                var response = await client.PostAsync($"{BASE_URL}/monan", content);
                return response.IsSuccessStatusCode;
            }
            catch { return false; }
        }


        public async Task<bool> Register(UserRegister user)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

                var response = await client.PostAsync($"{BASE_URL}/v1/user/signup", content);

                if (response.IsSuccessStatusCode)
                {
                    UserStorage.SaveUser(user);
                    return true;
                }
                else
                {
                    // Đọc lỗi từ server để hiển thị cho người dùng
                    var errorContent = await response.Content.ReadAsStringAsync();
                    System.Diagnostics.Debug.WriteLine($"Registration failed: {response.StatusCode} - {errorContent}");
                    
                    // Ném exception với thông tin lỗi chi tiết
                    throw new Exception($"Server trả về lỗi: {response.StatusCode}. {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Lỗi kết nối mạng: {ex.Message}");
            }
            catch (Exception)
            {
                // Ném lại exception để SignUpForm xử lý và hiển thị
                throw;
            }
        }
    }
}