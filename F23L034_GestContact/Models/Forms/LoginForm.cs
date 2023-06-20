using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace F23L034_GestContact.Models.Forms
{
#nullable disable
    public class LoginForm
    {
        [Required]
        [EmailAddress]
        [StringLength(384, MinimumLength = 1)]
        [DisplayName("Email : ")]
        public string Email { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 8)]
        [DataType(DataType.Password)]
        [DisplayName("Mot de passe : ")]
        public string Passwd { get; set; }
    }
}
