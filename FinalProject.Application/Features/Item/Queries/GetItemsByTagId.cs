using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Features.Item.Queries
{
    public class GetItemsByTagId : IRequest<List<Domain.Entities.Item?>>
    {
        public int TagId { get; set; }
    }
}
