namespace Web.Areas.Admin.Models
{
    public class NewsViewModel
    {
        public Guid? Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Content { get; set; }
        public string? Picture { get; set; }
        public string? KeyWord { get; set; } //keyword
    }
}
