namespace Web.Areas.Admin.Models
{
    public class MemberViewModel
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? LoginName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? Picture { get; set; }
        public Guid? GroupId { get; set; }
    }
}
