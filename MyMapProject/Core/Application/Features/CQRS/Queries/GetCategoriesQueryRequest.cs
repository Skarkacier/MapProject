using MediatR;
using MyMapProject.Core.Application.Dto;

namespace MyMapProject.Core.Application.Features.CQRS.Queries
{
    public class GetCategoriesQueryRequest : IRequest<List<CategoryListDto>>
    {
    }
}
