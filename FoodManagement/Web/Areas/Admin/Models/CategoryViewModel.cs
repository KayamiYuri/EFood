namespace Web.Areas.Admin.Models
{
    public class CategoryViewModel
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public Guid? ParentId { get; set; }
    }
}
