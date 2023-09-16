using MediatR;
using MyMapProject.Core.Application.Dto;

namespace MyMapProject.Core.Application.Features.CQRS.Queries
{
    public class GetLocationQueryRequest : IRequest<LocationListDto>
    {
        public int Id { get; set; }
        public GetLocationQueryRequest(int id)
        {
            Id = id;
        }
    }
}
