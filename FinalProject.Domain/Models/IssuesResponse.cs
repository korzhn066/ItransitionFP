using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Domain.Models
{
    public class IssuesResponse
    {
        public List<IssueResponse> Issues { get; set; } = new List<IssueResponse>();
    }
}
