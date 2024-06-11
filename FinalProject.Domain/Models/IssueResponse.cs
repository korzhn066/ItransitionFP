using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Domain.Models
{
    public class IssueResponse
    {
        public string Key { get; set; } = null!;
        public IssueFields Fields { get; set; } = null!;
    }
}
