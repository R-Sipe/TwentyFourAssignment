using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TwentyFour.Models;
using TwentyFour.Services;

namespace TwentyFourAssignment.Controllers
{
    public class CommentController : ApiController
    {
        public IHttpActionResult Get()
        {
            CommentService commentService = CreateCommentService();
            var comments = commentService.GetCommentsByAuthId();
            return Ok(comments);
        }

        [HttpGet]
        public IHttpActionResult Get([FromUri]int Id)
        {
            CommentService commentService = CreateCommentService();
            var comments = commentService.GetCommentsByPostId(Id);
            return Ok(comments);
        }

        public IHttpActionResult Post(CreateComment comment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCommentService();

            if (!service.CreateComment(comment))
                return InternalServerError();

            return Ok("Comment was Created");
        }

        public IHttpActionResult Put(UpdateComment comment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCommentService();

            if (!service.UpdateComments(comment))
                return InternalServerError();

            return Ok($"Comment was updated");
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateCommentService();

            if (!service.DeleteNote(id))
                return InternalServerError();

            return Ok($"Comment with Id #{id} has been deleted");
        }

        private CommentService CreateCommentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var commentService = new CommentService(userId);
            return commentService;
        }

    }
}
