using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace F23L034_GestContact.Models.Forms
{
#nullable disable
    public class RegisterForm
    {
        [Required]
        [StringLength(50, MinimumLength = 1)]
        [DisplayName("Nom : ")]
        public string Nom { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1)]
        [DisplayName("Prénom : ")]
        public string Prenom { get; set; }
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
        [Compare(nameof(Passwd))]
        [DataType(DataType.Password)]
        [DisplayName("Confirmation : ")]
        public string Confirm { get; set; }
    }
}
