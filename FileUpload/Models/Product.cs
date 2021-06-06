using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FileUpload.Models
{
    public class Product
    {
        [Key]
        [Required]

        public int Id { get; set; }
        [Required(ErrorMessage ="Name can't be null")]
        [MaxLength(50,ErrorMessage ="Maximum length can be 50 charechter")]

        public string Name { get; set; }
        [Required(ErrorMessage = "Description can't be null")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Price can't be null")]
        public float Price { get; set; }
        [NotMapped]
        public IFormFile Picture { get; set; }
        public string PicturePath { get; set; }
    }
}
