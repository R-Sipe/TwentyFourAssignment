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
                            Title = e.Title,
                            Text = e.Text
                        }
                        );

                return query.ToArray();
            }
        }
    }
}
