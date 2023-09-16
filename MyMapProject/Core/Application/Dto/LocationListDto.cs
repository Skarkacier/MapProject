namespace MyMapProject.Core.Application.Dto
{
    public class LocationListDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public int CategoryId { get; set; }
    }
}
