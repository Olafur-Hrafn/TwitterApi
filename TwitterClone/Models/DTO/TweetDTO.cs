using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TwitterClone.Models.DTO
{
    public class TweetDTO
    {
        public TweetDTO()
        {
            //   Users = new List<User>();
           
        }


        public int TweetId { get; set; }

        public String TweetText { get; set; }
        public int RetweetId { get; set; }
        public int Likes { get; set; }
        public DateTime? DateOfPost { get; set; }
        public String UserHandle { get; set; }
        public String UserName { get; set; }
        public String UserAvatar { get; set; }
        public int UserId { get; set; }
        public User user { get; set; }


        public List<Reply> Replies { get; set; } = new List<Reply>();

        //public List<User> Users { get; set; }
    }
}
