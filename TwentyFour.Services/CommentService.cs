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

        public bool CreateComment(CreateComment comment)
        {
            var entity =
                new Comment()
                { 
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

        public IEnumerable<GetAllComments> GetCommentsByPostId(int postId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Comments
                    .Where(e => e.PostId == postId)
                    .Select(
                        e =>
                        new GetAllComments
                        {
                            PostId = e.PostId,
                            Id = e.Id,
                            Text = e.Text
                        });

                return query.ToArray();
            }
        }

        public IEnumerable<GetAllComments> GetCommentsByAuthId()
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
                            PostId = e.PostId,
                            Id = e.Id,
                            Text = e.Text
                        });

                return query.ToArray();
            }
        }

        public bool UpdateComments(UpdateComment model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.AuthorId == _userId &&  e.PostId == model.PostId);

                entity.PostId = model.PostId;
                entity.Text = model.Text;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteNote(int commentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.Id == commentId && e.AuthorId == _userId);

                ctx.Comments.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}