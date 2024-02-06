namespace Shop.Models
{
    public class Blog
    {
        
        public int Id { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public Category category{ get; set; }
    }
}
