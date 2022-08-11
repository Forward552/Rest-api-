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
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        public PostService(IPostRepository postPepository, IMapper mapper)
        {
             _postRepository = postPepository;
            _mapper = mapper;
        }


        public IEnumerable<PostDto> GetAllPosts()
        {
            var posts = _postRepository.GetAll();
            return _mapper.Map<IEnumerable<PostDto>>(posts);
        }

        public PostDto GetPostById(int id)
        {
            var post = _postRepository.GetById(id);
           return _mapper.Map<PostDto>(post);
        }
        public PostDto AddNewPost(CreatePostDto newpost)
        {
            if (string.IsNullOrEmpty(newpost.Title))
            {
                throw new Exception("Brak tytułu");
            }    
            var post = _mapper.Map<Post>(newpost);
            _postRepository.Add(post);
            return _mapper.Map<PostDto>(post);
        }

        public void UpdatePost(UpdatePostDto updatePost)
        {
            var existingPost = _postRepository.GetById(updatePost.Id);
            var post = _mapper.Map(updatePost, existingPost);
            _postRepository.Update(post);
        }

        public void DeletePost(int id)
        {
            var post = _postRepository.GetById(id);
            _postRepository.Delete(post);
        }
    }
}
