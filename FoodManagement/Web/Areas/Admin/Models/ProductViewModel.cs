namespace Web.Areas.Admin.Models
{
    public class ProductViewModel
    {
        public Guid? Id { get; set; }
        public string? Title { get; set; }
        public string? Intro { get; set; }
        public string? Content { get; set; }
        public double? Price { get; set; }
        public string? Picture { get; set; }
        public Guid? CategoryId { get; set; }
    }
}
