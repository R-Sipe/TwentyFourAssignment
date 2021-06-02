using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwentyFour.Data;

namespace TwentyFour.Models
{
    public class GetAllComments
    {
        public string Text { get; set; }

        public int? ReplyId { get; set; }

        [ForeignKey(nameof(ReplyId))]
        public virtual List<Reply> Replies { get; set; }

        public int? PostId { get; set; }

        [ForeignKey(nameof(PostId))]
        public virtual Post Post { get; set; }
    }
}