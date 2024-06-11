using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Features.Item.Queries
{
    public class GetItemsByCollectionId : IRequest<List<Domain.Entities.Item>>
    {
        public int CollectionId { get; set; }
        public int Count { get; set; }
        public int Page { get; set; }
    }
}
