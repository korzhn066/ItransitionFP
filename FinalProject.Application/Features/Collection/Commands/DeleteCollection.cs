using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Features.Collection.Commands
{
    public class DeleteCollection : IRequest
    {
        public int Id { get; set; }
    }
}
