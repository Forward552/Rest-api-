using Application.Dto;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CommentsService : ICommentService
    {
        private readonly ICommentsRepository _commentRepository;
        private readonly IMapper _mapper;
        public CommentsService(ICommentsRepository commentsRepository, IMapper mapper)
        {
            _commentRepository = commentsRepository;
            _mapper = mapper;
        }


        public IEnumerable<CommentsDto> GetAllComments()
        {
            var comments = _commentRepository.GetAll();
            return _mapper.Map<IEnumerable<CommentsDto>>(comments);
        }

        public CommentsDto GetCommentByIdComments(int id)
        {
            var comments = _commentRepository.GetById(id);
            return _mapper.Map<CommentsDto>(comments);
        }

        public CommentsDto GetCommentByIdPost(int id)
        {
            var comment = _commentRepository.GetById(id);
            return _mapper.Map<CommentsDto>(comment);
        }

        public CommentsDto NewComment(CreateCommentDto newComment)
        {
            if (string.IsNullOrEmpty(newComment.Title))
            {
                throw new Exception("Brak Tytułu komentarza");
            }
            if (string.IsNullOrEmpty(newComment.Name))
            {
                throw new Exception("Brak Nazwy Użytkownika przy komentarzu.");
            }
            var comment = _mapper.Map<Comments>(newComment);
            _commentRepository.Add(comment);
            return _mapper.Map<CommentsDto>(comment);
        }

        public void Update(UpdateCommentsDto updateComments)
        {
            var existingComment = _commentRepository.GetById(updateComments.Id);
            var comment = _mapper.Map(updateComments, existingComment);
            _commentRepository.Update(comment);
        }

        public void DeleteComment(int id)
        {
            var comment = _commentRepository.GetById(id);
            _commentRepository.Delete(comment);
        }

    }
}
