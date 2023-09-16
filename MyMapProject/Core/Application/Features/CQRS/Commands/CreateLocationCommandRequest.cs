using MediatR;

namespace MyMapProject.Core.Application.Features.CQRS.Commands
{
    public class CreateLocationCommandRequest : IRequest
    {
        public string? Name { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public int CategoryId { get; set; }
    }
}
