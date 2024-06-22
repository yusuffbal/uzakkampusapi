using Core.Dtos;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Services;

namespace WebAPI.Controllers
{
    [Route("api/forums")]
    [ApiController]
    public class ForumController(IForumService forumService) : CustomBaseController
    {
        [HttpPost]
        [Route("ForumUserById")]
        public async Task<IActionResult> ForumUserById(int Id)
        {
            var result = await forumService.ForumUserById(Id);
            return ActionResultInstance(result);
        }

        [HttpPost]
        [Route("ForumById")]
        public async Task<IActionResult> ForumById(int Id)
        {
            var result = await forumService.ForumById(Id);
            return ActionResultInstance(result);
        }

        [HttpPost]
        [Route("CreatePost")]
        public async Task<IActionResult> CreatePost(CreatePostDto createPost)
        {
            var result = await forumService.CreatePosts(createPost);
            return ActionResultInstance(result);
        }

        [HttpPost]
        [Route("CreateForum")]
        public async Task<IActionResult> CreateForum(CreateForumDto createForum)
        {
            var result = await forumService.CreateForum(createForum);
            return ActionResultInstance(result);
        }

        
    }
}
