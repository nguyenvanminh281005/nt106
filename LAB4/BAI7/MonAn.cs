using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BAI7
{
    public class MonAn
    {
        public int Id { get; set; } // Hoặc string tùy API
        public string TenMonAn { get; set; } = string.Empty;
        public decimal Gia { get; set; }
        public string DiaChi { get; set; } = string.Empty;
        public string HinhAnh { get; set; } = string.Empty; // URL hình ảnh
        public string MoTa { get; set; } = string.Empty;
        public string NguoiDongGop { get; set; } = string.Empty;
    }
    public class PageResult<T>
    {
        [JsonProperty("data")]
        public List<T> Data { get; set; } = new List<T>();

        [JsonProperty("total")]
        public int TotalRecords { get; set; }

        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("pageSize")]
        public int PageSize { get; set; }
    }

    public class UserRegister
    {
        [JsonProperty("username")]
        public string username { get; set; } = string.Empty;

        [JsonProperty("password")]
        public string password { get; set; } = string.Empty;

        [JsonProperty("email")]
        public string email { get; set; } = string.Empty;

        [JsonProperty("first_name")]
        public string first_name { get; set; } = string.Empty;

        [JsonProperty("last_name")]
        public string last_name { get; set; } = string.Empty;

        [JsonProperty("phone")]
        public string phone { get; set; } = string.Empty;

        [JsonProperty("sex")]
        public int sex { get; set; } // 0 = Female, 1 = Male

        [JsonProperty("birthday")]
        public string birthday { get; set; } = string.Empty; // yyyy-MM-dd

        [JsonProperty("language")]
        public string language { get; set; } = string.Empty;
    }
}
