namespace MyMapProject.Core.Domain
{
    public class Location
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
