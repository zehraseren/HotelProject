using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.LoginDto
{
    public class LoginUserDto
    {
        [Required(ErrorMessage = "Kullanıcı adını giriniz.")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Şifreyi giriniz.")]
        public string Password { get; set; } = string.Empty;
    }
}
