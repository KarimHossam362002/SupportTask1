using Shop.Models;

namespace Shop.ViewModel
{
    public class ProductViewModel
    {
        public Product product { get; set; }
        public List<Company> companies { get; set; }
    }
}
