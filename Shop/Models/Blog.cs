using Shop.Utilities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [TitleValidation(ErrorMessage ="You can use letters to represent the title")]
        public string Title { get; set; }
        [Required]
        public string Detail { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category category{ get; set; }
    }
}
