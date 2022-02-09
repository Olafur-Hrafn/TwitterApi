using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TwitterClone.Models
{
    public class Tweet
    {
        public Tweet()
        {
          //  Users = new List<User>(); 
        }


        public int TweetId { get; set; }

        [Required]
        [MaxLength(180)]
        public String TweetText { get; set; }
        public int RetweetId { get; set; }
        public int Likes { get; set; }
      //  [DataType(DataType.Date)]
       // [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
       public DateTime? DateOfPost { get; set; }
        public String UserHandle { get; set; }
        public String UserName { get; set; }


        public String UserAvatar { get; set; }

        public User user { get; set; }
        public List<Reply> Replies { get; set; } = new List<Reply>();
        //public List<User> Users { get; set; }
    }
}
