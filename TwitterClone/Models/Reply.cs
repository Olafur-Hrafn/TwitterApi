using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TwitterClone.Models
{
    public class Reply
    {
        public Reply()
        {
              
        }

        public int Id { get; set; }
        [Required]
        [MaxLength(180)]
        public String ReplyContent { get; set; }
        public int TweetId { get; set; }
        public Tweet tweet { get; set; }
        public int UserId { get; set; }
        //public String UserName { get; set; }
    }
}
