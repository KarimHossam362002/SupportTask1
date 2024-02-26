using Shop.Utilities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models
{
	public class Product
	{

        [Key]
        [Required]
        public int Id { get; set; }
        [Required (ErrorMessage ="You must enter the name of the product")]
        [DeniedValues("AAA" , "BBB")]
        [Length(1 ,10)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Range(1000,10000)]
        [MaxPriceForCompany(5000)]
        public float Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        
        public bool EnableSize { get; set; }
        [Required]
        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company? company { get; set; }
    }
}
