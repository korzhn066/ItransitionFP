using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Features.Comment.Commands
{
    public class AddComment : IRequest
    {
        public int ItemId { get; set; }
        public string Comment { get; set; }
    }
}
