using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class CommentsDto
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string Name { get; set; }
        public string  Title { get; set; }
        public string Content { get; set; }

    }
}
