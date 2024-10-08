﻿using System.ComponentModel.DataAnnotations;

namespace EndProject.Models.ViewModels
{
    public class UpdateChooseVM
    {
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        public IFormFile? Image { get; set; }
        public string? ImageUrl { get; set; }
    }
}
