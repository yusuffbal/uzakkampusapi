using Core.Dtos;
using Core.Entities;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ForumService(
        IGenericRepository<Forums> _forumService,
        IGenericRepository<ForumParticipants> _forumParticipantsRepository,
        IGenericRepository<ForumPosts> _forumPostsRepository,
        IGenericRepository<Users> _userRepository,
        IUnitOfWork unitOfWork

        ) : IForumService
    {
        public async Task<Response<CreateForumDto>> CreateForum(CreateForumDto createForum)
        {
            

            var newForum = new Forums
            {
                Description = createForum.Description,
                Title = createForum.Title,
            };

            var forum = await _forumService.AddAsync(newForum);
            await unitOfWork.CommmitAsync();

            foreach (var forumParticipant in createForum.ForumParticipant)
            {
                var participant = new ForumParticipants
                {
                    ForumId = forum.Id,
                    UserId = forumParticipant.UserId,
                    Type = 1
                };

                await _forumParticipantsRepository.AddAsync(participant);
            }

            await unitOfWork.CommmitAsync();

            return Response<CreateForumDto>.Success("Forum oluşturuldu, Katılımcılar başarıyla eklendi.", 200);
        }

        public async Task<Response<ForumDetailDto>> CreatePosts(CreatePostDto createPost)
        {
            try
            {
                var forum = await _forumService.GetByIdAsync(createPost.ForumId);
                if (forum == null)
                {
                    var errorDto = new ErrorDto("Forum bulunamadı.", true);
                    return Response<ForumDetailDto>.Fail(errorDto, 404);
                }

                var author = await _userRepository.GetByIdAsync(createPost.AuthorId);
                if (author == null)
                {
                    var errorDto = new ErrorDto("Yazar bulunamadı.", true);
                    return Response<ForumDetailDto>.Fail(errorDto, 404);
                }

                var newPost = new ForumPosts
                {
                    ForumId = createPost.ForumId,
                    AuthorId = createPost.AuthorId,
                    Title = createPost.title,
                    Description = createPost.description,
                    Image = createPost.image,
                    DateOfCreated = DateTime.UtcNow
                };

                await _forumPostsRepository.AddAsync(newPost);
                await unitOfWork.CommmitAsync();

                return await ForumById(createPost.ForumId);
            }
            catch (Exception ex)
            {
                var errorDto = new ErrorDto($"Post kaydedilirken bir hata oluştu: {ex.Message}", true);
                if (ex.InnerException != null)
                {
                    errorDto.Errors.Add($"Inner Exception: {ex.InnerException.Message}");
                }
                return Response<ForumDetailDto>.Fail(errorDto, 500);
            }
        }





        public async Task<Response<ForumDetailDto>> ForumById(int forumId)
        {
            var forum = await _forumService.GetByIdAsync(forumId);
            if (forum == null)
            {
                var errorDto = new ErrorDto("Kayıt bulunamadı.", true);
                var response = Response<ForumDetailDto>.Fail(errorDto, 404);
            }

            var forumPosts = await _forumPostsRepository.GetListByExpAsync(
                post => post.ForumId == forumId,
                include: query => query.Include(p => p.Forums)
                                       .Include(p => p.Author)
            );

            var forumPostsDtoList = forumPosts.Select(post => new ForumPostDto
            {
                PostId = post.Id,
                PostTitle = post.Title,
                PostDescription = post.Description,
                PostImage = post?.Image,
                AuthorName = post.Author.Name,
                AuthorSurname = post.Author.Surname,
                DateOfCreated = post.DateOfCreated
            }).ToList();

            var forumDetailDto = new ForumDetailDto
            {
                ForumId = forum.Id,
                ForumTitle = forum.Title,
                ForumDescription = forum.Description,
                Posts = forumPostsDtoList
            };

            return Response<ForumDetailDto>.Success(forumDetailDto, 200);

        }


        public async Task<Response<List<ForumInfoDto>>> ForumUserById(int userId)
        {
            var userForums = await _forumParticipantsRepository.GetListByExpAsync(
              sc => sc.UserId == userId
          );

            var forumId = userForums.Select(sc => sc.ForumId).ToList();

            var forums = await _forumService.Where(c => forumId.Contains(c.Id)).ToListAsync();

            var forumsInfoDtoList = forums.Select(forum => new ForumInfoDto
            {
                Id = forum.Id,
                Title = forum.Title,
                Description = forum.Description
            }).ToList();

            return Response<List<ForumInfoDto>>.Success(forumsInfoDtoList, 200);
        }
    }
}
