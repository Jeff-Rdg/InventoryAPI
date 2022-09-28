﻿using System.ComponentModel.DataAnnotations;

namespace InventoryAPI.DTO.UserDto
{
    public class CreateUserDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        
        public bool IsAdmin { get; set; } = false;
    }
}
