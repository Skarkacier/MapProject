using MediatR;

namespace MyMapProject.Core.Application.Features.CQRS.Commands
{
    public class UpdateLocationCommandRequest : IRequest
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public int CategoryId { get; set; }
    }
}
