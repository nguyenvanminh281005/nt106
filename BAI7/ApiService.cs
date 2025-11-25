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

        // Biến lưu token dùng chung - Static để chia sẻ giữa các instance
        public static string AccessToken = "";
        
        // Flag để biết đang dùng local mode hay API mode
        public static bool IsLocalMode = false;
        
        // Danh sách món ăn local (khi không có API)
        private static List<MonAn> localDishes = new List<MonAn>();

        // Singleton instance
        private static ApiService? _instance;
        public static ApiService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ApiService();
                return _instance;
            }
        }

        // 1. HÀM LOGIN
        public async Task<bool> Login(string username, string password)
        {
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
                    IsLocalMode = false;
                    
                    System.Diagnostics.Debug.WriteLine($"Login successful! Token: {AccessToken.Substring(0, Math.Min(20, AccessToken.Length))}...");
                    return true;
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    System.Diagnostics.Debug.WriteLine($"Login failed: {response.StatusCode} - {errorContent}");
                    
                    // Nếu login API thất bại, thử kiểm tra local storage
                    if (UserStorage.ValidateUser(username, password))
                    {
                        IsLocalMode = true;
                        System.Diagnostics.Debug.WriteLine("Login with local storage - Using local mode!");
                        return true;
                    }
                }
            }
            catch (Exception ex) 
            {
                System.Diagnostics.Debug.WriteLine($"Login exception: {ex.Message}");
                
                // Nếu có lỗi, thử local storage
                if (UserStorage.ValidateUser(username, password))
                {
                    IsLocalMode = true;
                    System.Diagnostics.Debug.WriteLine("Login with local storage - Using local mode!");
                    return true;
                }
            }
            return false;
        }

        // 2. HÀM LẤY DANH SÁCH MÓN (GetDishes ĐÂY RỒI!)
        // gọi API lấy dữ liệu về
        public async Task<PageResult<MonAn>> GetDishes(int page, int pageSize)
        {
            // Nếu đang dùng local mode, trả về dữ liệu local
            if (IsLocalMode)
            {
                var skip = (page - 1) * pageSize;
                var data = localDishes.Skip(skip).Take(pageSize).ToList();
                return new PageResult<MonAn>
                {
                    Data = data,
                    Page = page,
                    PageSize = pageSize,
                    TotalRecords = localDishes.Count
                };
            }
            
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
        public async Task<bool> AddDish(MonAn monAn, string? imagePath = null)
        {
            try
            {
                // Nếu đang dùng local mode, lưu vào danh sách local
                if (IsLocalMode)
                {
                    // Lưu hình ảnh local
                    if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                    {
                        monAn.HinhAnh = imagePath; // Lưu đường dẫn file
                    }
                    
                    // Tạo ID mới
                    monAn.Id = localDishes.Count > 0 ? localDishes.Max(m => m.Id) + 1 : 1;
                    
                    localDishes.Add(monAn);
                    System.Diagnostics.Debug.WriteLine($"Added dish to local storage. Total: {localDishes.Count}");
                    return true;
                }
                
                // Kiểm tra xem có token không (khi dùng API mode)
                if (string.IsNullOrEmpty(AccessToken))
                {
                    System.Diagnostics.Debug.WriteLine("Error: No access token! User must login first.");
                    throw new Exception("Bạn cần đăng nhập với tài khoản API trước khi thêm món ăn!");
                }

                // Nếu có hình ảnh, chuyển thành base64
                if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                {
                    byte[] imageBytes = File.ReadAllBytes(imagePath);
                    string base64String = Convert.ToBase64String(imageBytes);
                    
                    // Lấy extension để gửi kèm
                    var extension = Path.GetExtension(imagePath).ToLower();
                    string mimeType = "image/jpeg";
                    switch (extension)
                    {
                        case ".png": mimeType = "image/png"; break;
                        case ".gif": mimeType = "image/gif"; break;
                        case ".bmp": mimeType = "image/bmp"; break;
                    }
                    
                    // Format: data:image/jpeg;base64,/9j/4AAQ...
                    monAn.HinhAnh = $"data:{mimeType};base64,{base64String}";
                }
                
                System.Diagnostics.Debug.WriteLine($"Sending request with token: {AccessToken.Substring(0, Math.Min(20, AccessToken.Length))}...");
                System.Diagnostics.Debug.WriteLine($"Request data: {JsonConvert.SerializeObject(monAn).Substring(0, 200)}...");
                
                var content = new StringContent(JsonConvert.SerializeObject(monAn), Encoding.UTF8, "application/json");
                var response = await client.PostAsync($"{BASE_URL}/monan", content);
                
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    System.Diagnostics.Debug.WriteLine($"Add dish failed: {response.StatusCode} - {errorContent}");
                    throw new Exception($"API trả về lỗi: {response.StatusCode}. Chi tiết: {errorContent}");
                }
                
                System.Diagnostics.Debug.WriteLine("Add dish successful!");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Exception in AddDish: {ex.Message}");
                throw; // Ném lại để AddDishForm bắt và hiển thị
            }
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