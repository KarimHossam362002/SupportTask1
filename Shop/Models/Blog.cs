using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category category{ get; set; }
    }
}
