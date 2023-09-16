using MediatR;

namespace MyMapProject.Core.Application.Features.CQRS.Commands
{
    public class DeleteLocationCommandRequest : IRequest
    {
        public int Id { get; set; }
        public DeleteLocationCommandRequest(int id)
        {
            Id = id;
        }
    }
}
