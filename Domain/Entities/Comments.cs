using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Comments: AuditableEntity
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Comments() {}
        public Comments(int id, int postId, string name, string title, string content)
        {
            (Id, PostId, Name, Title, Content) = (id, postId, name, title, content);
        }


    }
}
