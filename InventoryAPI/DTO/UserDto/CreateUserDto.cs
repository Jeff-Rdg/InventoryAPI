using System.ComponentModel.DataAnnotations;

namespace InventoryAPI.DTO.UserDto
{
    public class CreateUserDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(100)]
        public string FullName { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Phone(ErrorMessage = "O campo {0} está em formato inválido")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "As senhas não conferem")]
        public string ConfirmPassword { get; set; }
        public bool IsAdmin { get; set; } = false;
    }
}
