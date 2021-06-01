using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwentyFour.Data;
using TwentyFour.Models;

namespace TwentyFour.Services
{
    public class CommentService
    {
        private readonly Guid _userId;

        public CommentService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateComment(CommentCreate comment)
        {
            var entity =
                new Comment()
                {
                    ReplyId = comment.ReplyId,
                    PostId = comment.PostId,
                    Text = comment.Text,
                    AuthorId = _userId,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<GetAllComments> GetComments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Comments
                    .Where(e => e.AuthorId == _userId)
                    .Select(
                        e =>
                        new GetAllComments
                        {
                            //PostId = e.PostId,
                            //ReplyId = e.ReplyId,
                            Text = e.Text
                        }
                        );

                return query.ToArray();
            }
        }
    }
}