using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyFour.Models
{
    public class UpdateComment
    {
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        public int? PostId { get; set; }
    }
}
