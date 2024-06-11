using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Features.Item.Queries
{
    public class GetItemsByContainText : IRequest<List<Domain.Entities.Item>>
    {
        public int Count { get; set; }
        public string Text { get; set; } = null!;
    }
}
