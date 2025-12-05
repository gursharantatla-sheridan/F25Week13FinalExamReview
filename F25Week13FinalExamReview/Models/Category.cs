namespace F25Week13FinalExamReview.Models
{
    public class Category
    {
        // scalar
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }

        // navigation
        public ICollection<Product>? Products { get; set; }
    }
}
