using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwentyFour.Data;
using TwentyFour.Models;

namespace TwentyFour.Services
{
    public class PostService
    {
        private readonly Guid _userId;

        public PostService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePost(PostCreate post)
        {
            var entity =
                new Post()
                {
                    Title = post.Title,
                    Text = post.Text,
                    AuthorId = _userId,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<GetAllPost> GetPosts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Posts
                    .Where(e => e.AuthorId == _userId)
                    .Select(
                        e =>
                        new GetAllPost
                        {
                            PostId = e.Id,
                            Title = e.Title,
                            Text = e.Text
                        }
                        );

                return query.ToArray();
            }
        }

        public PostDetail GetPostById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Posts
                    .Single(e => e.Id == id && e.AuthorId == _userId);
                return
                    new PostDetail
                    {
                        PostId = entity.Id,
                        Title = entity.Title,
                        Text = entity.Text
                    };
            }
        }

        public bool UpdatePost(PostEdit edit)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Posts
                    .Single(e => e.Id == edit.PostId && e.AuthorId == _userId);
                entity.Title = edit.Title;
                entity.Text = edit.Text;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePost(int postId)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Posts
                    .Single(e => e.Id == postId && e.AuthorId == _userId);

                ctx.Posts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
