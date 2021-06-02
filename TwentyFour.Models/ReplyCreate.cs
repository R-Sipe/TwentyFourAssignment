using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwentyFour.Data;

namespace TwentyFour.Models
{
    public class ReplyCreate
    {
        [Required]
        public string Text { get; set; }

        public int? CommentId { get; set; }

        //[ForeignKey(nameof(CommentId))]
        public virtual Comment Comment { get; set; }
    }
}
