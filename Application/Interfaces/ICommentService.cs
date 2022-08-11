using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    internal interface ICommentService
    {
        IEnumerable<CommentsDto> GetAllComments();
        CommentsDto GetCommentByIdComments(int id);
        CommentsDto GetCommentByIdPost(int id);
        CommentsDto NewComment(CreateCommentDto newComment);
        void Update(UpdateComments updateComments);
        void DeleteComment(int id);
    }
}
