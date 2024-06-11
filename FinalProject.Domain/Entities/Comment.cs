using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Domain.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
    }
}
