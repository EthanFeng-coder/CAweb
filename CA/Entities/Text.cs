using System;
using System.ComponentModel.DataAnnotations;

namespace CA.Entities
{
    public class Text
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Category { get; set; }
    }

}

