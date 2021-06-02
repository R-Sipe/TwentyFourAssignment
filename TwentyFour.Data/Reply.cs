using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyFour.Data
{
    public class Reply
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public Guid AuthorId { get; set; }
        public int CommentId { get; set; }

        [ForeignKey(nameof(CommentId))]
        public virtual Comment Comment { get; set; }
    }
}
