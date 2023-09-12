using Azure.Identity;

namespace NhanSuAPI.Models
{
    public class User
    {
        public string Username {get; set;} = string.Empty;
        public byte[] PasswordHash { get; set;}
        public byte[] PasswordSalt { get; set;}
    }
}
