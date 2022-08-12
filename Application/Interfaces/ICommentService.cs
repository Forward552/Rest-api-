using Application.Dto;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICommentService
    {
        IEnumerable<CommentsDto> GetAllComments();
        CommentsDto GetCommentByIdComments(int id);
        CommentsDto GetCommentByIdPost(int id);
        CommentsDto NewComment(CreateCommentDto newComment);
        void Update(UpdateCommentsDto updateComments);
        void DeleteComment(int id);
    }
}
