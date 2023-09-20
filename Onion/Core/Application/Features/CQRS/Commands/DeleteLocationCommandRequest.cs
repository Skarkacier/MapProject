using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Commands
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
