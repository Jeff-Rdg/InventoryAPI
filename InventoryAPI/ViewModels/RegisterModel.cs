using System.ComponentModel.DataAnnotations;

namespace InventoryAPI.ViewModels
{
    public class RegisterModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "A {0} deve ter no minimo {2} e no máximo {1} caracteres.", MinimumLength = 10)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirma senha")]

        [Compare("Password", ErrorMessage ="Senhas não conferem")]
        public string ConfirmPassword { get; set; }
    }
}
