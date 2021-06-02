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
                    //Title = like.Title,
                    //Text = like.Text,
                   
                    OwnerId = _userId,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Likes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<GetAllLikes> GetLikes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Likes
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new GetAllLikes
                        {
                            //Title = e.Title,
                            //Text = e.Text
                            
                        }
                        );

                return query.ToArray();
            }
        }



    }
}
