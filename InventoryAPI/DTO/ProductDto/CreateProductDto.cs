﻿using InventoryAPI.DTO.ProductTypeDto;
using InventoryAPI.Model;
using System.ComponentModel.DataAnnotations;

namespace InventoryAPI.DTO
{
    public class CreateProductDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int ProductTypeId { get; set; }

    }
}
