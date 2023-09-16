namespace MyMapProject.Core.Domain
{
    public class Category
    {
        public int Id { get; set; }
        public string? Definition { get; set; }
        public List<Location>? Locations { get; set; }
    }
}
