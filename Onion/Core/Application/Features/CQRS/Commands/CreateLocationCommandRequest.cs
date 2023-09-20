using Application.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Commands
{
    public class CreateLocationCommandRequest : IRequest<CreatedLocationDto?>
    {
        public string? Name { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public int CategoryId { get; set; }
    }
}
