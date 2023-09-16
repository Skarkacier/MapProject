namespace MyMapProject.Core.Domain
{
    public class UserRole
    {
        public int Id { get; set; }
        public string? Definition { get; set; }
        public List<User>? Users { get; set; }
    }
}
