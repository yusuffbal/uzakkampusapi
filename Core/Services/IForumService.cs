using Core.Dtos;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IForumService
    {
        public Task<Response<List<ForumInfoDto>>> ForumUserById(int userId);
        public Task<Response<ForumDetailDto>> ForumById(int forumId);
        public Task<Response<ForumDetailDto>> CreatePosts(CreatePostDto createPost);

        public Task<Response<CreateForumDto>> CreateForum(CreateForumDto createForum);



    }
}
