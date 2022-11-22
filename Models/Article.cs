using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorWeb.Models
{    
    public class Article
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Column(TypeName = "nvarchar")]
        public string Title { get; set; }


        [DataType(DataType.Date)]
        [Required]
        public DateTime Created { get; set; }

        [Column(TypeName = "ntext")]
        public string Content { get; set; }
    }
}
