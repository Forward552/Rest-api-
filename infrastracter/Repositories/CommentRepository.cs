using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastracter.Repositories
{
    public class CommentRepository : ICommentsRepository
    {
        private static readonly ISet<Comments> _comments = new HashSet<Comments>()
        {
            new Comments(1,1,"Tomek","niby fajne","Tresc komentarza")

        };

        public IEnumerable<Comments> GetAll()
        {
            return _comments;
        }

        public Comments GetById(int id)
        {
            return _comments.SingleOrDefault(p => p.Id == id);
        }
        public Comments GetByIdPost(int id)
        {
            return (Comments)_comments.Where(p => p.PostId == id);
        }
        public Comments Add(Comments comments)
        {
            comments.Id = _comments.Count() + 1;
            comments.Created = DateTime.Now;
            _comments.Add(comments);
            return comments;
        }
        public void Update(Comments comments) 
        {
            comments.LastModified = DateTime.Now;
        }
        public void Delete(Comments comments)
        {
            _comments.Remove(comments);
        }
    }
}
