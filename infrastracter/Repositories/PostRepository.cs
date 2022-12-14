using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;

namespace infrastracter.Repositories
{
    public class PostRepository : IPostRepository
    {
        private static readonly ISet<Post> _posts = new HashSet<Post>()
        {
            new Post(1, "tytuł 1", "Treść 1"),
            new Post(2, "tytuł 2", "Treść 2"),
            new Post(3, "tytuł 3", "Treść 3"),
            new Post(4, "tytuł 4", "Treść 4"),
            new Post(5, "tytuł 5", "Treść 5"),
            new Post(6, "tytuł 6", "Treść 6"),
            new Post(7, "tytuł 7", "Treść 7")
        };

        public IEnumerable<Post> GetAll()
        {
            return _posts;
        }

        public Post GetById(int id)
        {
            return _posts.SingleOrDefault(p => p.Id == id);
        }

        public Post Add(Post post)
        {
            post.Id = _posts.Count()+1;
            post.Created = DateTime.Now;
            _posts.Add(post);
            return post;
        }

        public void Update(Post post)
        {
            post.LastModified = DateTime.Now;
        }

        public void Delete(Post post)
        {
            _posts.Remove(post);
        }

    }
}
