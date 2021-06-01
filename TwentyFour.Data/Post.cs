using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyFour.Data
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public Guid AuthorId { get; set; }
        public int CommentId { get; set; }
        [ForeignKey(nameof(CommentId))]
        public virtual List<Comment> Comments { get; set; }
        public int LikeId { get; set; }
        [ForeignKey(nameof(LikeId))]

        public virtual List<Like> Likes { get; set; }

    }
}
