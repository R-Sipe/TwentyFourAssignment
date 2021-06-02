using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwentyFour.Data;
using TwentyFour.Models;

namespace TwentyFour.Services
{
    public class LikeService
    {
        private readonly Guid _userId;

        public LikeService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateLike(LikeCreate like)
        {
            var entity =
                new Like()
                {
                    PostId = like.PostId,
                    OwnerId = _userId,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Likes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<GetAllLikes> GetLikesByPostId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Likes
                    .Where(e => e.OwnerId == _userId && e.PostId == id)
                    .Select(
                        e =>
                        new GetAllLikes
                        {
                           PostId = e.PostId,
                           Post = e.Post
                        }
                        );

                return query.ToArray();
            }
        }



    }
}
