using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace BAI7
{
    public static class UserStorage
    {
        private static readonly string FilePath = "users.json";

        public static void SaveUser(UserRegister user)
        {
            var users = LoadUsers();
            users.Add(user);
            File.WriteAllText(FilePath, JsonConvert.SerializeObject(users));
        }

        public static List<UserRegister> LoadUsers()
        {
            if (!File.Exists(FilePath))
                return new List<UserRegister>();
            var json = File.ReadAllText(FilePath);
            return JsonConvert.DeserializeObject<List<UserRegister>>(json) ?? new List<UserRegister>();
        }

        public static bool ValidateUser(string username, string password)
        {
            var users = LoadUsers();
            return users.Exists(u => u.username == username && u.password == password);
        }
    }
}
